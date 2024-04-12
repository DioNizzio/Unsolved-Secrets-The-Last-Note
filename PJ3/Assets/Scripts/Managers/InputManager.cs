using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    PlayerMovement playerMove;

    public Camera Cam;

    MoveCamera moveCamera;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.C;
    public KeyCode interactKey = KeyCode.E;

    public KeyCode pickupKey = KeyCode.F;

    public KeyCode dropKey = KeyCode.G;

    public KeyCode inspectKey = KeyCode.Q;

    public KeyCode rotateInspectKey = KeyCode.Mouse0;

    public KeyCode exitKey = KeyCode.Escape;


    InteractionsManager interactionsManager;

    InventoryManager inventoryManager;

    InspectionManager inspectionManager;

    UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMovement>();
        moveCamera = Cam.GetComponent<MoveCamera>();
        interactionsManager = gameObject.GetComponent<InteractionsManager>();
        inventoryManager = gameObject.GetComponent<InventoryManager>();
        inspectionManager = gameObject.GetComponent<InspectionManager>();
        uIManager = gameObject.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Walking
        if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f){
            playerMove.MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        //Cam Rotation
        if((Input.GetAxisRaw("Mouse X")!=0f||Input.GetAxisRaw("Mouse Y")!=0f) && inspectionManager.IsInspecting() == false){
            moveCamera.CameraRotation(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
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
        if(Input.GetKeyDown(interactKey)){
            interactionsManager.Interaction();
        }
        // Pick-Up Objects
        if(Input.GetKeyDown(pickupKey)){
            interactionsManager.Picking_Up();
        }
        // Drop Object
        if(Input.GetKeyDown(dropKey) && inspectionManager.IsInspecting() == false){
            interactionsManager.Droping();
        }
        // Move Up in the inventory
        if(Input.GetAxis("Mouse ScrollWheel")>0){
            if(inspectionManager.IsInspecting()==true){
                inventoryManager.SetCurrentItem(1);
                //inspectionManager.ExitInspection();
                inspectionManager.InspectItem(inventoryManager.GetCurrentItem());
                uIManager.CheckCurrentObject(inventoryManager.GetCurrentItemInt());
            }else{
                inventoryManager.NextItem();
            }
        }
        // Move Down in the inventory
        if(Input.GetAxis("Mouse ScrollWheel")<0){
            if(inspectionManager.IsInspecting()==true){
                inventoryManager.SetCurrentItem(-1);
                //inspectionManager.ExitInspection();
                inspectionManager.InspectItem(inventoryManager.GetCurrentItem());
                uIManager.CheckCurrentObject(inventoryManager.GetCurrentItemInt());
            }else{
                inventoryManager.LastItem();
            }
        }
        // Inspect Object
        if(Input.GetKeyDown(inspectKey) && interactionsManager.IsHolding() == true){
            inspectionManager.InspectItem(inventoryManager.GetCurrentItem());
        }

        // Exit Inspection
        if(Input.GetKeyDown(exitKey) && inspectionManager.IsInspecting() == true){
            inspectionManager.ExitInspection();
            interactionsManager.HoldObject(inventoryManager.GetCurrentItem());
        }
    }
}
