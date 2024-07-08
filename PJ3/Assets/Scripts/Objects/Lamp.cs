using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    public GameObject lampLight;

    public AudioClip on;
    public AudioClip off;

    AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public bool Interact(GameObject currentObj)
    {
        if(lampLight.activeSelf==false){
            lampLight.SetActive(true);
            audioSource.clip = on;
        }
        else{
            lampLight.SetActive(false);
            audioSource.clip = off;
        }
        audioSource.Play();
        return false;
    }
}
