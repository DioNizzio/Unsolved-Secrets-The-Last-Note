using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    public GameObject lampLight;

    public bool Interact(GameObject currentObj)
    {
        if(lampLight.activeSelf==false){
            lampLight.SetActive(true);
        }
        else{
            lampLight.SetActive(false);
        }
        return false;
    }
}
