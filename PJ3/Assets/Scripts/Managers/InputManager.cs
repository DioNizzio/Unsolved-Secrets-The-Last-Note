using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    PlayerMovement playerMove;

    public GameObject Cam;
    public GameObject Cam2;

    MoveCamera moveCamera;
    MoveCamera moveCamera2;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.C;
    public KeyCode interactKey = KeyCode.E;

    public KeyCode pickupKey = KeyCode.F;

    public KeyCode dropKey = KeyCode.G;

    public KeyCode inspectKey = KeyCode.Q;

    public KeyCode rotateInspectKey = KeyCode.Mouse0;

    public KeyCode exitKey = KeyCode.Escape;

    public KeyCode lanternKey = KeyCode.V;

    public KeyCode helpKey = KeyCode.H;

    public KeyCode rotateRightKey = KeyCode.RightArrow;

    public KeyCode rotateLeftKey = KeyCode.LeftArrow;

    public Clock clock;


    InteractionsManager interactionsManager;

    InventoryManager inventoryManager;

    InspectionManager inspectionManager;

    UIManager uIManager;

    CameraSwitcher cameraSwitcher;

    LanternManager lanternManager;

    HelpsManager helpsManager;

    PlayerandCameraHolders playerandCameraHolders;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = player.GetComponent<PlayerMovement>();
        moveCamera = Cam.GetComponent<Camera>().GetComponent<MoveCamera>();
        moveCamera2 = Cam2.GetComponent<Camera>().GetComponent<MoveCamera>();
        interactionsManager = gameObject.GetComponent<InteractionsManager>();
        inventoryManager = gameObject.GetComponent<InventoryManager>();
        inspectionManager = gameObject.GetComponent<InspectionManager>();
        uIManager = gameObject.GetComponent<UIManager>();
        cameraSwitcher = gameObject.GetComponent<CameraSwitcher>();
        lanternManager = gameObject.GetComponent<LanternManager>();
        helpsManager = gameObject.GetComponent<HelpsManager>();
        playerandCameraHolders = gameObject.GetComponent<PlayerandCameraHolders>();
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
            if (Cam.activeSelf==true && uIManager.notePad.activeSelf == false){
                Debug.Log("Cam1");
                moveCamera.CameraRotation(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            }
            // else if(Cam2.activeSelf==true){
            //     Debug.Log("Cam2");
            //     moveCamera2.CameraRotation(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            // }
            
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
        if(Input.GetKeyDown(interactKey) && !lanternManager.IsUsingLantern()){
            interactionsManager.Interaction();
        }
        if(Input.GetMouseButtonDown(0)){
            if(Cursor.lockState == CursorLockMode.Locked){
                interactionsManager.Interaction();
            }
            else{
                interactionsManager.CloseUpInteraction();
            }
        }
        // Pick-Up Objects
        if(Input.GetKeyDown(pickupKey) && !lanternManager.IsUsingLantern()){
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
                uIManager.UpdateInspectionMenu(inventoryManager.GetCurrentItem());
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
                uIManager.UpdateInspectionMenu(inventoryManager.GetCurrentItem());
            }else{
                inventoryManager.LastItem();
            }
        }
        // Inspect Object
        if(Input.GetKeyDown(inspectKey) && interactionsManager.IsHolding() == true){
            inspectionManager.InspectItem(inventoryManager.GetCurrentItem());
            uIManager.ActivateInspectionMenu(inventoryManager.GetCurrentItem());
        }

        // Exit Inspection
        if(Input.GetKeyDown(exitKey) ){
            if(inspectionManager.IsInspecting() == true){
                inspectionManager.ExitInspection();
                uIManager.DeactivateInspectionMenu();
                interactionsManager.HoldObject(inventoryManager.GetCurrentItem());
            } else if(Cam.activeSelf==false){
                cameraSwitcher.ExitCurrentCamera();
            } else if(uIManager.notePad.activeSelf == true){
                uIManager.ActivateNotePad(false);
            }else if(uIManager.IsPaused()){
                playerandCameraHolders.PlayerCanMove(true);
                uIManager.HidePause();
            }else{
                playerandCameraHolders.PlayerCanMove(false);
                uIManager.ShowPause();
            } 
        }

        if(Input.GetKeyDown(KeyCode.Tab) && !lanternManager.IsUsingLantern()){
            uIManager.ActivateNotePad(true);
        }

        if(Input.GetKeyDown(lanternKey)){
            lanternManager.ActivateLantern();
        }

        if(Input.GetKeyDown(helpKey)){
            helpsManager.AskForHelp();
            helpsManager.HideHelpAvailable();
        }
        if (Input.GetKeyDown(rotateRightKey)){
            clock.RotateHands(1);
        }
        if (Input.GetKeyDown(key: rotateLeftKey)){
            clock.RotateHands(-1);
        }


    }
}
