using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockNumbers : MonoBehaviour, IInteractable
{

    public AudioClip clip;
    public bool Interact(GameObject currentObj)
    {
        GetComponent<Animator>().SetTrigger("Rotate");
        transform.parent.GetComponent<AudioSource>().clip=clip;
        transform.parent.GetComponent<AudioSource>().Play();
        return false;
    }
}

