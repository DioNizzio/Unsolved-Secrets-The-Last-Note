using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
// using UnityEngine.UIElements;

public class InspectionManager : MonoBehaviour
{
    UIManager uIManager;
    public Transform inspectPos;

    public Transform readPos;

    public Transform holdPos;

    private GameObject inspectObj;

    private Rigidbody inspectObjRb;


    private float rotationX;
    private float rotationY;

    // Used to continue in inspection even if there is no item in a slot
    // forces the player to exit inspection
    private bool barrier = false;
    
    // Start is called before the first frame update
    void Start()
    {
        uIManager = gameObject.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inspectObj != null){
            if(inspectObj.tag.Contains("Readable")){
                inspectObj.transform.position = readPos.transform.position;
            }
            else{
                inspectObj.transform.position = inspectPos.transform.position;
            }

            var x = Input.GetAxis("Mouse X");
            var y = Input.GetAxis("Mouse Y");

            if (-x < 0)
            {
                x += 360;
            }
            if (y < 0)
            {
                y += 360;
            }
            rotationX += x;
            rotationY += y;
            inspectObj.transform.rotation = Quaternion.Euler(rotationY*4, rotationX*4, 0);
        }
    }

    public void InspectItem(GameObject go){
        uIManager.ActivateBlur(true);
        uIManager.HideCrossair();
        if(go!=null){
            if(inspectObj!=null){
                inspectObj.gameObject.SetActive(false);
                inspectObjRb.isKinematic = false;
                inspectObj.transform.parent = holdPos.transform;
                inspectObj = null;
            }
            inspectObj = go; //assign heldObj to the object that was hit by the raycast (no longer == null) 
            //inspectObj.layer = 0;        
            inspectObj.gameObject.SetActive(true);
            //inspectObj.AddComponent<EventTrigger>();
            if(inspectObj.tag.Contains("Readable")){
                inspectObjRb = go.GetComponentInChildren<Rigidbody>(); //assign Rigidbody
                inspectObjRb.isKinematic = true;
                inspectObjRb.transform.parent = readPos.transform;
            }
            else{
                inspectObjRb = go.GetComponent<Rigidbody>(); //assign Rigidbody
                inspectObjRb.isKinematic = true;
                inspectObjRb.transform.parent = inspectPos.transform;
            }
            
        }
        else{
            if(inspectObj!=null){
                inspectObj.gameObject.SetActive(false);
                inspectObjRb.isKinematic = false;
                inspectObj.transform.parent = holdPos.transform;
                inspectObj = null;
            }
            barrier = true;
        }
    }

    public void ExitInspection(){
        uIManager.ActivateBlur(false);
        uIManager.HideCrossair();
        if(inspectObj!=null){
            inspectObj.layer = 0;
            inspectObjRb.isKinematic = false;
            inspectObj.transform.parent = null;
            inspectObj = null;
        }
        barrier = false;
    }


    public bool IsInspecting(){
        if(inspectObj!=null){
            return true;
        }
        if(barrier!=false){
            return true;
        }
        return false;
    }
}