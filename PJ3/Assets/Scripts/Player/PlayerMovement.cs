using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [HideInInspector] public float moveSpeed;
    public float walkSpeed;
    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

   

    [Header("Keybinds")]

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    Vector3 moveDirection;

    Rigidbody rb;


    public AudioClip walking;

    public AudioClip walkingOnCarpet;

    private AudioSource audioPlayer;

    private bool isColliding;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        moveSpeed = walkSpeed;
        startYScale = transform.localScale.y;
        audioPlayer = GetComponent<AudioSource>();
        isColliding = false;
    }

    private void Update()
    {
        
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    void OnCollisionEnter(Collision collision){
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name.Contains("Carpet")){
            audioPlayer.clip = walkingOnCarpet;
        }else if(collision.gameObject.name.Contains("floor")){
            audioPlayer.clip = walking;
        }
        isColliding = true;
    }
    void OnCollisionExit(Collision collision){
        isColliding = false;
    }

    public void MovePlayer(float horizontalInput, float verticalInput)
    {
        SpeedControl();
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded){
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            if(!audioPlayer.isPlaying && !isColliding){
                
                audioPlayer.Play();
            }
         
        }
        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void Jump()
    {
        if(readyToJump && grounded){
            // reset y velocity
            readyToJump = false; 
            grounded = false;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void ResetJump()
    {
        readyToJump = true;        
    }

    public void CrouchPlayer(){
        transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        moveSpeed = crouchSpeed;
    }

    public void UncrouchPlayer(){
        transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        moveSpeed = walkSpeed;
    }
}
