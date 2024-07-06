using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour, IInteractable, IPickable, IInspectable
{
    public UIManager uIManager;
    public bool Interact(GameObject currentObj)
    {
        if(name.Contains("LockedDoor")){
            uIManager.ShowDialogue("I can't leave yet, I need to know what happened. I need to find more clues about this case.");
        }
        return false;
    }

    public void Pickup()
    {
        if(name.Contains("Ornament")){
            uIManager.ShowDialogue("What is this for?");
        }
        if(name.Contains("Key")){
            uIManager.ShowDialogue("This key must be important.");
        }
    }
    public void Inspect()
    {
        if(name.Contains("Lighter")){
            uIManager.ShowDialogue("1712?? What does it mean?");
        }
        if(name.Contains("Ripped Paper")){
            uIManager.ShowDialogue("Why is my name there? Wait... Was this you boy? I miss you... But, why is this paper ripped apart?");
        }
        if(name.Contains("Form")){
            uIManager.ShowDialogue("This was Timmy's friend...");
        }
    }
}
