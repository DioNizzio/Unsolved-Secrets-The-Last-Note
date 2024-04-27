using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IInteractable
{

    public Safe safe;
    public bool Interact(GameObject currentObj)
    {
        //Debug.Log(name);
        if(name.Contains("Box")){
            safe.SetNeedsCheck();
        }
        else{
            safe.AddToCode(name);
        }
        
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(safe.hideNums==true){
            if(!name.Contains("Box")){
                gameObject.SetActive(false);
            }
        }
        
    }
}
