using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceOrnaments : MonoBehaviour, IInteractable
{
    
    public Material correctMaterial;

    
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(GameObject currentObj)
    {
        if(currentObj!=null){
            if(GetComponent<MeshRenderer>().material.name.Contains("invisible") && currentObj.name.Contains("Ornament")){
                GetComponent<MeshRenderer>().material = correctMaterial;
                Destroy(currentObj);
                return true;
            }
        }
        // else{
        //     if(name.Contains("Ornament") || GetComponent<MeshRenderer>().material.name.Contains("invisible")){
        //         return false;
        //     }
        //     else{
        //         if(note!=null){
        //             piano.PlayNote(note);
        //         }
        //         transform.parent.GetComponent<Animator>().SetTrigger("Interact");
        //         piano.AddtoPianoNotes(transform.parent.name);   
        //     }   
            
        // }
        return false;
        
    }
}
