using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalBook : MonoBehaviour, IInteractable
{
    public Pedestal pedestal;
    public bool Interact(GameObject currentObj)
    {
        pedestal.UpNumber(name);
        return false;
    }

    
}
