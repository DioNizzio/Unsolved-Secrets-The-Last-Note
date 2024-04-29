using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PaintingSpot : MonoBehaviour, IInteractable
{

    public Camera cam;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool Interact(GameObject currentObj)
    {
        if(currentObj != null && currentObj.name.Contains("Painting")){
            currentObj.transform.parent = transform;
            return true;
        }
        return false;
    }
}