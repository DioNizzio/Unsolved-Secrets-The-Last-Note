using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PaintingSpot : MonoBehaviour, IInteractable
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0,0.01064183f,0);

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