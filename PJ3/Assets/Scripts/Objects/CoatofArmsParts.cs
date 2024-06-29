using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoatofArmsParts : MonoBehaviour, IInteractable
{
    

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
        return gameObject.transform.parent.GetChild(3).gameObject.GetComponent<CoatofArms>().Interact(currentObj);
    }
}
