using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeOtherPart : MonoBehaviour, IInteractable
{
    public Globe globe;

    public bool Interact(GameObject currentObj)
    {
        return globe.Interact(currentObj);
    }
}
