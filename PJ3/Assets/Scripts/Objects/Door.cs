using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject key;
    public GameObject door;
    private bool locked;

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
        }
        else{
            if(locked==false){
                door.GetComponent<Animator>().SetTrigger("Open");
            }
        }
        return false;
    }
}
