using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject key;
    public GameObject door;
    private bool locked;

    public UIManager uIManager;

    void Start()
    {
        locked = true;   
    }
    public bool Interact(GameObject currentObj)
    {
        if(currentObj!=null){
            if (currentObj.name.Contains("key")){
                key.SetActive(true);
                Destroy(currentObj);
                locked = false;
                return true;
            }
            else{
                uIManager.ShowDialogue("Seems locked, I need to find a key somewhere.");
            }
        }
        else{
            if(locked==false){
                door.GetComponent<Animator>().SetTrigger("Open");
                uIManager.ShowDialogue("Nice, there we go.");
            }
            else{
                uIManager.ShowDialogue("Seems locked, I need to find a key somewhere.");
            }
        }
        return false;
    }
}
