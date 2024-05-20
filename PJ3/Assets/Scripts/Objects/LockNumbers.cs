using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockNumbers : MonoBehaviour, IInteractable
{
    public bool Interact(GameObject currentObj)
    {
        GetComponent<Animator>().SetTrigger("Rotate");
        return false;
    }
}

