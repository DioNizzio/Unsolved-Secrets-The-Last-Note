using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour, IInteractable, IPickable, IInspectable
{
    public UIManager uIManager;
    public bool Interact(GameObject currentObj)
    {
        if(name.Contains("LockedDoor")){
            uIManager.ShowDialogue("I can't leave yet, I need to know what happened. I need to find more clues about this case.");
            gameObject.transform.parent.GetComponent<AudioSource>().Play();
        }
        else if(name.Contains("Telephone")){
            uIManager.ShowDialogue("Landline seems to have been cut off...");
        }
        else if(name.Contains("Coat")){
            uIManager.ShowDialogue("Interesting Jacket...");
        }
        else if(name.Contains("Entrance Closet")){
            uIManager.ShowDialogue("Can't open it, the doors are jammed.");
        }
        else if(name.Contains(value: "Music Box")){
            uIManager.ShowDialogue("My wife loved these things. She was so joyful when we played our music box to little Timmy... Nowadays, she is not so happy and is always in bed... It's been a year, but it feels like it was yesterday.");
        }
        else if(name.Contains(value: "Radio")){
            uIManager.ShowDialogue("This radio doesn't seem to work");
        }
        else if(name.Contains(value: "Gramophone")){
            uIManager.ShowDialogue("Seems to be broken.");
        }
        else if(name.Contains(value: "Typewriter")){
            uIManager.ShowDialogue("Emrick had a nice typewriter.");
        }
        else if(name.Contains(value: "Feather Pen")){
            uIManager.ShowDialogue("Who even still uses feather pens?");
        }
        else{
            if(!(gameObject.tag=="Pickable" || gameObject.tag=="Readable")){
                uIManager.ShowDialogue(s: "Not really important.");
            }
        }
        return false;
    }

    public void Pickup()
    {
        if(name.Contains("Ornament")){
            uIManager.ShowDialogue("What is this for?");
        }
        else if(name.Contains("Page 5")){
            if(transform.localScale.x<25){
                transform.localScale = new Vector3(transform.localScale.x*1.9f,transform.localScale.y*1.9f,transform.localScale.z*1.9f);
            }
        }
        else if(name.Contains("Newspaper")){
            if(transform.localScale.x<25){
                transform.localScale = new Vector3(transform.localScale.x*1.5f,transform.localScale.y*1.5f,transform.localScale.z*1.5f);
            }
        }
        else if(name.Contains("Key")){
            uIManager.ShowDialogue("This key must be important.");
        }
        else if(name.Contains(value: "Pearl")||name.Contains(value: "Round Object")||name.Contains(value: "Sharp Object")){
            uIManager.ShowDialogue("What is this for?");
        }
        else if(name.Contains(value: "Bach")){
            uIManager.ShowDialogue("I know this guy. Good symphonies.");
        }
        else if(name.Contains(value: "Mozart")){
            uIManager.ShowDialogue("This was Timmy's favourite.");
        }
        else if(name.Contains(value: "Piano Key")){
            uIManager.ShowDialogue("Why is this key here?");
        }
        else if(name.Contains(value: "Dagger")){
            uIManager.ShowDialogue("This dagger seems familiar... Timmy? Was it you?");
        }
        else if(name.Contains(value: "Page 9")){
            uIManager.ShowDialogue("Haven't seen you in a year. I miss you boy...");
        }
        else if(name.Contains(value: "Small Ripped Paper")){
            uIManager.ShowDialogue("He got to you boy... I'm sorry I couldn't save you Timmy... I will avenge you son!");
        }
        else if(name.Contains(value: "Crumbled Paper")){
            uIManager.ShowDialogue("He was really messy, so much paper");
        }
        else if(name.Contains(value: "Compass")){
            uIManager.ShowDialogue("Why would he need a compass?");
        }
        else{
            if(!gameObject.tag.Contains("Readable")){
                uIManager.ShowDialogue(s: "Not really important.");
            }
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
    //28.83186
}
