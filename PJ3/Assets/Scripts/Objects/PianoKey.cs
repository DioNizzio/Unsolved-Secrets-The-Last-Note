using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PianoKey : MonoBehaviour, IInteractable
{
    public Piano piano;

    public AudioClip note;

    public Material correctMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool Interact(GameObject currentObj)
    {
        if(currentObj!=null){
            Debug.Log(currentObj.name);
            if(GetComponent<MeshRenderer>().material.name.Contains("invisible") && currentObj.name.Contains("Piano Key")){
                GetComponent<MeshRenderer>().material = correctMaterial;
                Destroy(currentObj);
                return true;
            }
        }
        else{
            if(name.Contains("Piano Key") || GetComponent<MeshRenderer>().material.name.Contains("invisible")){
                return false;
            }
            else{
                if(note!=null){
                    piano.PlayNote(note);
                }
                transform.parent.GetComponent<Animator>().SetTrigger("Interact");
                piano.AddtoPianoNotes(transform.parent.name);   
            }   
            
        }
        return false;
        
    }

}
