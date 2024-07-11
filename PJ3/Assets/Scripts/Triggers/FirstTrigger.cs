using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTrigger : MonoBehaviour
{

    public UIManager uIManager;
    void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Player")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            GetComponent<BoxCollider>().enabled = false;
            uIManager.ShowDialogue("Pufff... Finally I got in, now it's time to find out what really happened! I have my notepad and my uv light lantern with me, just like in the good old days. If you were involved I will find out about it Emrick!");
        }
    }
}
