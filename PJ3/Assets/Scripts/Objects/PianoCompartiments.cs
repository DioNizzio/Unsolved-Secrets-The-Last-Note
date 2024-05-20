using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoCompartiments : MonoBehaviour, IInteractable
{
    public bool Interact(GameObject currentObj)
    {
        transform.parent.GetComponent<IInteractable>().Interact(currentObj);
        return false;
    }
}
