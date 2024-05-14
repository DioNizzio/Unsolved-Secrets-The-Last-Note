using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PianoKey : MonoBehaviour, IInteractable
{
    public Piano piano;

    public AudioClip note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool Interact(GameObject currentObj)
    {
        if(note!=null){
            piano.PlayNote(note);
        }
        transform.parent.GetComponent<Animator>().SetTrigger("Interact");
        piano.AddtoPianoNotes(transform.parent.name);
        return false;
    }

}
