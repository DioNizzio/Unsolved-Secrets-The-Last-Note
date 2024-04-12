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
    public Camera cam;

    public GameObject player;

    private  Rigidbody playerRB;

    private PostProcessVolume ppVolume;

    public Transform inspectPos;

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
        playerRB = player.GetComponent<Rigidbody>();
        ppVolume = cam.GetComponent<PostProcessVolume>();
        uIManager = gameObject.AddComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inspectObj != null){
            inspectObj.transform.position = inspectPos.transform.position;

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
        playerRB.isKinematic = true;
        ppVolume.enabled = true;
        //go.GetComponent<Rigidbody>().isKinematic = false;
        Cursor.lockState = CursorLockMode.None;
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
            inspectObjRb = go.GetComponent<Rigidbody>(); //assign Rigidbody
            inspectObjRb.isKinematic = true;
            inspectObjRb.transform.parent = inspectPos.transform; //parent object to holdposition
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
        playerRB.isKinematic = false;
        ppVolume.enabled = false;
        if(inspectObj!=null){
            inspectObj.layer = 0;
            inspectObjRb.isKinematic = false;
            inspectObj.transform.parent = null;
            inspectObj = null;
        }
        barrier = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(Texture2D.blackTexture, new Vector2(0,0), CursorMode.ForceSoftware);
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