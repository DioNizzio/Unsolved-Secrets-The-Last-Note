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
    public KeyCode crouchKey = KeyCode.LeftControl;
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
    public KeyCode readKey = KeyCode.R;

    public Clock clock;


    InteractionsManager interactionsManager;

    InventoryManager inventoryManager;

    InspectionManager inspectionManager;

    UIManager uIManager;

    CameraSwitcher cameraSwitcher;

    LanternManager lanternManager;

    HelpsManager helpsManager;

    PlayerandCameraHolders playerandCameraHolders;

    TutorialManager tutorialManager;

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
        tutorialManager= gameObject.GetComponent<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Walking
        if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f){
            if(Cam.activeSelf==true){
                playerMove.MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                tutorialManager.TutorialNext(2);
            }
        }
        //Cam Rotation
        if((Input.GetAxisRaw("Mouse X")!=0f||Input.GetAxisRaw("Mouse Y")!=0f) && inspectionManager.IsInspecting() == false){
            if (Cam.activeSelf==true && uIManager.notePad.activeSelf == false && uIManager.PauseMenu.activeSelf == false && uIManager.Options.activeSelf == false){
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
            tutorialManager.TutorialNext(3);
        }
        //Crouching
        if(Input.GetKeyDown(crouchKey)){
            playerMove.CrouchPlayer();
            tutorialManager.TutorialNext(4);
        }
        //Uncrouching
        if(Input.GetKeyUp(crouchKey)){
            playerMove.UncrouchPlayer();
        }
        //Interacting with objects
        if(Input.GetKeyDown(interactKey) && !lanternManager.IsUsingLantern()){
            interactionsManager.Interaction();
            tutorialManager.TutorialNext(11);
        }
        if(Input.GetMouseButtonDown(0)){
            if(Cursor.lockState == CursorLockMode.Locked){
                interactionsManager.Interaction();
                tutorialManager.TutorialNext(11);
            }
            else if(Cursor.lockState == CursorLockMode.None && Cam.activeSelf!=true ){
                interactionsManager.CloseUpInteraction();
            }
            // else if(Cursor.lockState == CursorLockMode.None && uIManager.notePad.activeSelf == true){
            //     interactionsManager.CloseUpInteraction();
            // }
            else{
                //interactionsManager.CloseUpInteraction();
                Ray r = Cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out RaycastHit hitInfo, 0.1f)){
                    // tutorialManager.TutorialNext(6);
                }
            }
        }
        // Pick-Up Objects
        if(Input.GetKeyDown(pickupKey)){
            if(!inspectionManager.IsInspecting() && !inspectionManager.IsReading()){
                if(!lanternManager.IsUsingLantern()){
                    tutorialManager.TutorialNext(9);
                    interactionsManager.Picking_Up();
                }else{
                    tutorialManager.TutorialNext(9);
                    interactionsManager.Picking_Up();
                    if(inventoryManager.GetCurrentItem() != null){
                        lanternManager.ActivateLantern();
                    }
                }
            }
            
            
        }
        // Drop Object
        if(Input.GetKeyDown(dropKey) && inspectionManager.IsInspecting() == false){
            interactionsManager.Droping();
            tutorialManager.TutorialNext(13);
        }
        // Move Up in the inventory
        if(Input.GetAxis("Mouse ScrollWheel")>0 && !inspectionManager.IsReading()){
            if(inspectionManager.IsInspecting()==true){
                inventoryManager.SetCurrentItem(1);
                //inspectionManager.ExitInspection();
                inspectionManager.InspectItem(inventoryManager.GetCurrentItem());
                uIManager.CheckCurrentObject(inventoryManager.GetCurrentItemInt());
                uIManager.UpdateInspectionMenu(inventoryManager.GetCurrentItem());
            }else{
                if(!inspectionManager.IsReading()){
                    inventoryManager.NextItem();
                }
            }
        }
        // Move Down in the inventory
        if(Input.GetAxis("Mouse ScrollWheel")<0 && !inspectionManager.IsReading()){
            if(inspectionManager.IsInspecting()==true){
                inventoryManager.SetCurrentItem(-1);
                //inspectionManager.ExitInspection();
                inspectionManager.InspectItem(inventoryManager.GetCurrentItem());
                uIManager.CheckCurrentObject(inventoryManager.GetCurrentItemInt());
                uIManager.UpdateInspectionMenu(inventoryManager.GetCurrentItem());
                tutorialManager.TutorialNext(12);
            }else{
                if(!inspectionManager.IsReading()){
                    inventoryManager.LastItem();
                    tutorialManager.TutorialNext(12);
                }
            }
        }
        // Inspect Object
        if(Input.GetKeyDown(inspectKey) && interactionsManager.IsHolding() == true){
            tutorialManager.TutorialNext(10);
            inspectionManager.InspectItem(inventoryManager.GetCurrentItem());
            uIManager.ActivateInspectionMenu(inventoryManager.GetCurrentItem());
        }

        // Exit Inspection
        if(Input.GetKeyDown(exitKey) ){
            if(inspectionManager.IsInspecting() == true && inspectionManager.IsReading()==false){
                inspectionManager.ExitInspection();
                uIManager.DeactivateInspectionMenu();
                interactionsManager.HoldObject(inventoryManager.GetCurrentItem());
            } else if(inspectionManager.IsReading()==true){
                inspectionManager.Unread();
                uIManager.ReadPages();
            } else if(Cam.activeSelf==false){
                cameraSwitcher.ExitCurrentCamera();
            } else if(uIManager.notePad.activeSelf == true){
                tutorialManager.TutorialNext(7);
                uIManager.ActivateNotePad(false);
            }else if(uIManager.IsPaused() && uIManager.Options.activeSelf==false && uIManager.ExitPanel.activeSelf==false){
                playerandCameraHolders.PlayerCanMove(true);
                uIManager.HidePause();
            }
            else if(uIManager.IsPaused() && uIManager.Options.activeSelf==true){
                uIManager.Options.SetActive(false);
                uIManager.ShowPause();
            }
            else if(uIManager.IsPaused() && uIManager.ExitPanel.activeSelf==true){
                uIManager.ExitPanel.SetActive(false);
                uIManager.ShowPause();
            }else{
                playerandCameraHolders.PlayerCanMove(false);
                uIManager.ShowPause();
            } 
        }

        if(Input.GetKeyDown(KeyCode.Tab) && !lanternManager.IsUsingLantern() && uIManager.notePad.activeSelf == false && uIManager.PauseMenu.activeSelf == false && inspectionManager.IsInspecting() == false && inspectionManager.IsReading() == false){
            uIManager.ActivateNotePad(true);
            tutorialManager.TutorialNext(6);
        }

        if(Input.GetKeyDown(lanternKey) && uIManager.notePad.activeSelf == false && uIManager.PauseMenu.activeSelf == false && inspectionManager.IsInspecting() == false && inspectionManager.IsReading() == false){
            if(inventoryManager.GetCurrentItem()!=null){
                interactionsManager.HoldObject(null);
                uIManager.CheckCurrentObject(10);
            }
            lanternManager.ActivateLantern();
            tutorialManager.TutorialNext(8);
        }

        if(Input.GetKeyDown(helpKey)){
            helpsManager.AskForHelp();
            helpsManager.HideHelpAvailable();
        }
        if (Input.GetKeyDown(rotateRightKey) && Cam.activeSelf==false){
            clock.RotateHands(1);
        }
        if (Input.GetKeyDown(key: rotateLeftKey)  && Cam.activeSelf==false){
            clock.RotateHands(-1);
        }

        if (Input.GetKeyDown(readKey)){
            if (inspectionManager.IsInspecting() == true && (inventoryManager.GetCurrentItem().name.Contains("Page") || inventoryManager.GetCurrentItem().name.Contains("Diary"))){
                inspectionManager.Read();
                uIManager.ReadPages(inventoryManager.GetCurrentItem());
            }
            else if(inspectionManager.IsReading() == true){
                inspectionManager.Read();
                uIManager.ReadPages(inventoryManager.GetCurrentItem());
            }
        }


    }
}
