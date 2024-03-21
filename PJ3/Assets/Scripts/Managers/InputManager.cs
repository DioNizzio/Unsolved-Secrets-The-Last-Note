using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f){
            playerMove.MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        if(Input.GetKey(playerMove.jumpKey)){
            playerMove.Jump();
        }
        if(Input.GetKeyDown(playerMove.crouchKey)){
            playerMove.CrouchPlayer();
        }
        if(Input.GetKeyUp(playerMove.crouchKey)){
            playerMove.UncrouchPlayer();
        }
    }
}
