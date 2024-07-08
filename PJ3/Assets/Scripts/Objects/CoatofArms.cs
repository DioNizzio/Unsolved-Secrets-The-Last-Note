using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoatofArms : MonoBehaviour, IInteractable
{

    public GameObject topPart;

    public GameObject bottomPart;

    public GameObject pearl;

    public GameObject door;

    public Material correctMaterial;

    public bool Interact(GameObject currentObj)
    {
        if(currentObj!=null){
            if(pearl.GetComponent<MeshRenderer>().material.name.Contains("invisible") && currentObj.name.Contains("Pearl")){
                if (!topPart.GetComponent<MeshRenderer>().material.name.Contains("invisible") && !bottomPart.GetComponent<MeshRenderer>().material.name.Contains("invisible")){
                    pearl.GetComponent<MeshRenderer>().material = correctMaterial;
                    Destroy(currentObj);
                    return true;
                }
            }
            else if(bottomPart.GetComponent<MeshRenderer>().material.name.Contains("invisible") && currentObj.name.Contains("Sharp Object")){
                bottomPart.GetComponent<MeshRenderer>().material = correctMaterial;
                Destroy(currentObj);
                return true;
            }
            else if(topPart.GetComponent<MeshRenderer>().material.name.Contains("invisible") && currentObj.name.Contains("Round Object")){
                topPart.GetComponent<MeshRenderer>().material = correctMaterial;
                Destroy(currentObj);
                return true;
            }
        }
        return false;
        
    }

    public void PlayAnimation(){
        door.GetComponent<Animator>().SetTrigger("Open");
        door.GetComponent<AudioSource>().Play();
    }
}
