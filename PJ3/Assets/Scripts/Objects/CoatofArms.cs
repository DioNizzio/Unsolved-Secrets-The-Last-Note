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
            if(pearl.GetComponent<MeshRenderer>().material.name.Contains("invisible") && currentObj.name.Contains("brasão_LP.005")){
                if (!topPart.GetComponent<MeshRenderer>().material.name.Contains("invisible") && !bottomPart.GetComponent<MeshRenderer>().material.name.Contains("invisible")){
                    pearl.GetComponent<MeshRenderer>().material = correctMaterial;
                    Destroy(currentObj);
                    return true;
                }
            }
            else if(bottomPart.GetComponent<MeshRenderer>().material.name.Contains("invisible") && currentObj.name.Contains("brasão_LP.003")){
                bottomPart.GetComponent<MeshRenderer>().material = correctMaterial;
                Destroy(currentObj);
                return true;
            }
            else if(topPart.GetComponent<MeshRenderer>().material.name.Contains("invisible") && currentObj.name.Contains("brasão_LP.004")){
                topPart.GetComponent<MeshRenderer>().material = correctMaterial;
                Destroy(currentObj);
                return true;
            }
        }
        return false;
        
    }

    public void PlayAnimation(){
        door.GetComponent<Animator>().SetTrigger("Open");
    }
}
