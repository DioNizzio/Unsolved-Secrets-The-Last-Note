using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour, IInteractable
{
    
    public GameObject door;
    public GameObject drawer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public bool Interact(GameObject currentObj)
    {
        transform.parent.GetComponent<Animator>().SetTrigger("OpenBox");
        door.GetComponent<Animator>().SetTrigger("OpenBox");
        drawer.GetComponent<Animator>().SetTrigger("OpenBox");
        return false;

    }
}
