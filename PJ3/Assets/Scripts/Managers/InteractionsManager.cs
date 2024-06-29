using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security;
using UnityEngine;

// Every interactable object has to have this interface implemented
interface IInteractable{

    
    public bool Interact(GameObject currentObj);
}

public class InteractionsManager : MonoBehaviour
{
    // Origin Point of the interaction: our player
    public Transform interactorSource;

    // distance to which he can interact
    public float interactRange;

    private Camera cam;

    public Transform holdPosPainting;

    public Transform holdPosNormal;

    private Transform holdPos = null;

    public float throwForce = 200f; 
    
    private GameObject heldObj;

    private Rigidbody heldObjRb; //rigidbody of object we pick up

    InventoryManager inventoryManager;

    CameraSwitcher cameraSwitcher;
    void Start(){
        inventoryManager = gameObject.GetComponent<InventoryManager>();
        cameraSwitcher = gameObject.GetComponent<CameraSwitcher>();
        cam = cameraSwitcher.GetCurrentCamera().GetComponent<Camera>();
        holdPos = holdPosNormal;
    }

    void Update(){
        cam = cameraSwitcher.GetCurrentCamera().GetComponent<Camera>();
        //keep object position the same as the holdPosition position
        if (heldObj != null){
            
            heldObj.transform.position = holdPos.transform.position;
            heldObj.transform.eulerAngles = holdPos.transform.eulerAngles;            
        } 
    }

    public void Interaction(){
        // Interaction ray
        Ray r = new Ray(cam.transform.position, cam.transform.forward);
        // If the ray catches anything in the range, it will try to interact with it
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange)){
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)){
                if(inventoryManager.GetCurrentItem()!=null){
                    if(interactObj.Interact(inventoryManager.GetCurrentItem()) == true){
                        //heldObj.SetActive(false);
                        heldObj.layer = 0;
                        ClearHeldObj();
                        inventoryManager.ClearItem();
                    }                    
                }
                else{
                    if(interactObj.Interact(currentObj: null)==true){
                        ClearHeldObj();
                        inventoryManager.ClearItem();
                    }
                }
            }            
        }
    }

    public void Picking_Up(){
        Ray r = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            
            //make sure pickup tag is attached
            GameObject interactObj = hitInfo.collider.gameObject;
            // if (hitInfo.collider.gameObject.TryGetComponent(out GameObject interactObj))
            // {
            //pass in object hit into the PickUpObject function
            if (interactObj.GetComponent<Rigidbody>() && (interactObj.tag == "Pickable" || interactObj.tag == "Readable")) //make sure the object has a RigidBody
            {
                inventoryManager.AddItem(interactObj);
                //HoldObject(interactObj);
            }
            //Debug.Log("Picked up: " + heldObj.name);
            //}
        }
    }

    public void HoldObject(GameObject holdObj){
        if(holdObj != null){
            if(heldObj != null){
                
                    if(holdObj.name.Contains("Painting")){
                        holdPos = holdPosPainting;
                    }
                    else{
                        holdPos = holdPosNormal;
                    }
                    heldObj.gameObject.SetActive(false);
                    heldObj = holdObj; //assign heldObj to the object that was hit by the raycast (no longer == null)         
                    heldObj.gameObject.SetActive(true);
                    heldObjRb = holdObj.GetComponent<Rigidbody>(); //assign Rigidbody
                    heldObjRb.isKinematic = true;
                    heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
                    heldObj.layer = 7; //change the object layer to the holdLayer
                    //make sure object doesnt collide with player, it can cause weird bugs
                    Physics.IgnoreCollision(collider1: heldObj.GetComponent<Collider>(), interactorSource.gameObject.GetComponent<Collider>(), true);
                
                
            }
            else{
                 
                    if(holdObj.name.Contains("Painting")){
                        holdPos = holdPosPainting;
                    }
                    else{
                        holdPos = holdPosNormal;
                    }
                    heldObj = holdObj; //assign heldObj to the object that was hit by the raycast (no longer == null)         
                    heldObj.gameObject.SetActive(true);
                    heldObjRb = holdObj.GetComponent<Rigidbody>(); //assign Rigidbody
                    heldObjRb.isKinematic = true;
                    heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
                    heldObj.layer = 7; //change the object layer to the holdLayer
                    //make sure object doesnt collide with player, it can cause weird bugs
                    Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), interactorSource.gameObject.GetComponent<Collider>(), true);
                
            }
        }
        else{
            if (heldObj != null){
                heldObj.gameObject.SetActive(false);
                heldObj = null; //assign heldObj to the object that was hit by the raycast (no longer == null)         
                
            }
        }
    }

    

    public void CloseUpInteraction(){
        Ray r = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange)){
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)){
                interactObj.Interact(null);
            }
        }
    }

    public void Droping(){
        if (heldObj != null){
            var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
            //have to use RaycastAll as object blocks raycast in center screen
            //RaycastAll returns array of all colliders hit within the cliprange
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, cam.transform.forward, clipRange);
            //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
            if (hits.Length > 1)
            {
                //change object position to camera position 
                heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
                //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
            }
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), interactorSource.GetComponent<Collider>(), false);
            heldObj.layer = 0;
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null;
            heldObjRb.AddForce(cam.transform.forward * throwForce);
            heldObj = null;
            inventoryManager.ClearItem();
        }
    }


    public bool IsHolding(){
        if(heldObj!=null){
            return true;
        }
        return false;
    }

    public void ClearHeldObj(){
        //heldObj.SetActive(false);
        heldObj = null;
    }
}
