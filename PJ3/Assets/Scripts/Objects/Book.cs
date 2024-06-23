using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

    public bool left;

    public bool Interact(GameObject currentObj)
    {
        if(left){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.44f);
            left = false;
        }
        else{
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.44f);
            left = true;
        }
        return false;
    }

    void Start()
    {
        if (transform.position.z < 12){
            left = true;
        }
        else{
            left = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
