using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Safe : MonoBehaviour, IInteractable
{
    public bool cameraActive;

    private string code;

    private bool needsCheck;

    public GameObject trincos;

    public GameObject door;

    public GameObject handle;

    public bool hideNums;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraActive = false;
        needsCheck = false;
        hideNums = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(GameObject currentObj)
    {
        cameraActive = true;
        GetComponent<BoxCollider>().enabled = false;
        return false;
    }

    public void PlayAnimations(){
        trincos.GetComponent<Animator>().SetTrigger("RightCode");
        handle.GetComponent<Animator>().SetTrigger("RightCode");
        door.GetComponent<Animator>().SetTrigger("RightCode");
        hideNums = true;
    }


    public void AddToCode(string i){
        code += i;
    }

    public void ResetCode(){
        code = "";
    }

    public string GetCode(){
        return code;
    }

    public void SetNeedsCheck(){
        needsCheck = !needsCheck;
    }

    public bool GetNeedsCheck(){
        return needsCheck;
    }

}
