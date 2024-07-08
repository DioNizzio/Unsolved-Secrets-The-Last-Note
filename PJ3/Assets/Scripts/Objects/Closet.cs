using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Closet : MonoBehaviour, IInteractable
{
    public Lock locky;
    public bool Interact(GameObject currentObj)
    {
        
        if(name.Contains("drawer")){
            GetComponent<Animator>().SetTrigger("Open");
            GetComponent<AudioSource>().Play();
        }
        else{
            if(locky.IsUnlocked()){
                transform.parent.GetComponent<Animator>().SetTrigger("Open");
                GetComponent<AudioSource>().Play();
            }
        }
        return false;
    }
}
