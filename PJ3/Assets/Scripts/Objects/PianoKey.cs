using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PianoKey : MonoBehaviour, IInteractable
{
    public Piano piano;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool Interact(GameObject currentObj)
    {
        transform.parent.GetComponent<Animator>().SetTrigger("Interact");
        piano.AddtoPianoNotes(transform.parent.name);
        return false;
    }

}
