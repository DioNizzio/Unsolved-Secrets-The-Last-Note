using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    PlayerMovement playerMove;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.C;
    public KeyCode interactKey = KeyCode.E;

    public KeyCode pickupKey = KeyCode.F;

    public KeyCode dropKey = KeyCode.G;


    InteractionsManager interactionsManager;

    InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMovement>();
        interactionsManager = gameObject.GetComponent<InteractionsManager>();
        inventoryManager = gameObject.GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walking
        if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f){
            playerMove.MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        //Jumping
        if(Input.GetKey(jumpKey)){
            playerMove.Jump();
        }
        //Crouching
        if(Input.GetKeyDown(crouchKey)){
            playerMove.CrouchPlayer();
        }
        //Uncrouching
        if(Input.GetKeyUp(crouchKey)){
            playerMove.UncrouchPlayer();
        }
        //Interacting with objects
        if(Input.GetKeyDown(interactKey) || Input.GetMouseButtonDown(0)){
            interactionsManager.Interaction();
        }
        // Pick-Up Objects
        if(Input.GetKeyDown(pickupKey)){
            interactionsManager.Picking_Up();
        }
        if(Input.GetKeyDown(dropKey)){
            interactionsManager.Droping();
        }
        if(Input.GetAxis("Mouse ScrollWheel")>0){
            inventoryManager.NextItem();
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0){
            inventoryManager.LastItem();
        }
    }
}
