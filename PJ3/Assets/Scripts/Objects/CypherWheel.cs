using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CypherWheel : MonoBehaviour, IInteractable
{
    public GameObject wheelInside;
    public GameObject wheelMid;
    public GameObject wheelOutside;
    public GameObject fireplace;

    public bool cameraActive;

    // Start is called before the first frame update
    void Start()
    {
        cameraActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimations(int i){
        if(i==1){
            wheelOutside.GetComponent<Animator>().SetTrigger("Spin");
        }else if(i==2){
            wheelOutside.GetComponent<Animator>().SetTrigger("SpinBack");
            wheelMid.GetComponent<Animator>().SetTrigger("Spin");
        }else if(i==3){
            wheelOutside.GetComponent<Animator>().SetTrigger("SpinBack2");
            wheelMid.GetComponent<Animator>().SetTrigger("SpinBack");
            wheelInside.GetComponent<Animator>().SetTrigger("Spin");
        }
        else{
            fireplace.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    public bool Interact(GameObject currentObj)
    {
        cameraActive = true;
        GetComponent<BoxCollider>().enabled = false;
        return false;
    }

    public void ExitCameraCypher(){
        cameraActive = false;
        GetComponent<BoxCollider>().enabled = true;
    }
}
