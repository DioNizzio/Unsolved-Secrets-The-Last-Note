using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    PlayerMovement playerMove;

    InteractionsManager interactionsManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMovement>();
        interactionsManager = player.GetComponent<InteractionsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walking
        if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f){
            playerMove.MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        //Jumping
        if(Input.GetKey(playerMove.jumpKey)){
            playerMove.Jump();
        }
        //Crouching
        if(Input.GetKeyDown(playerMove.crouchKey)){
            playerMove.CrouchPlayer();
        }
        //Uncrouching
        if(Input.GetKeyUp(playerMove.crouchKey)){
            playerMove.UncrouchPlayer();
        }
        //Interacting with objects
        if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)){
            interactionsManager.Interaction();
        }
    }
}
