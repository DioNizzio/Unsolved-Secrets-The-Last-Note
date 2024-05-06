using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
    public bool cameraActive;

    private string bellSequence;

    public GameObject drawer;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraActive = false;
        bellSequence = "";
    }

    // Update is called once per frame
    public bool Interact(GameObject currentObj)
    {
        cameraActive = true;
        GetComponent<BoxCollider>().enabled = false;
        return false;
    }
    
    public void ExitCameraClock(){
        cameraActive = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void AddToBellSequence(string s){
        if(bellSequence.Length==3){
            bellSequence = "";
        }
        bellSequence += s;
        Debug.Log(bellSequence);
    }

    public string GetBellSequence(){
        return bellSequence;
    }

    public void OpenDrawer(){
        drawer.GetComponent<Animator>().SetTrigger("OpenGaveta");
    }
}
