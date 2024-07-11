using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Closet : MonoBehaviour, IInteractable
{
    public Lock locky;

    public GameObject wall;
    public UIManager uIManager;
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
                uIManager.ShowDialogue("OMG!!!! This guy is a freak!!! I need to find a way out of here. What the Hell!!!");
                wall.SetActive(true);
                wall.GetComponent<AudioSource>().Play();

            }
        }
        return false;
    }
}
