using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalBook : MonoBehaviour, IInteractable
{
    public SoundManager soundManager;
    public Pedestal pedestal;
    public bool Interact(GameObject currentObj)
    {
        pedestal.UpNumber(name);
        soundManager.Play("bookSliding");
        return false;
    }
    
    
}
