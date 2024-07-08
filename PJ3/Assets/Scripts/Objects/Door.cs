using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject key;
    public GameObject door;
    private bool locked;

    AudioSource audioSource;

    public AudioClip NotOpen;

    public AudioClip Open;

    public UIManager uIManager;

    void Start()
    {
        locked = true;
        audioSource = GetComponent<AudioSource>();
    }
    public bool Interact(GameObject currentObj)
    {
        if(currentObj!=null){
            if (currentObj.name.Contains("Key")){
                key.SetActive(true);
                Destroy(currentObj);
                locked = false;
                return true;
            }
            else{
                if(locked==false){
                    door.GetComponent<Animator>().SetTrigger("Open");
                    uIManager.ShowDialogue("Nice, there we go.");
                    audioSource.clip = Open;
                    audioSource.Play();
                }
            }
        }
        else{
            if(locked==false){
                door.GetComponent<Animator>().SetTrigger("Open");
                uIManager.ShowDialogue("Nice, there we go.");
                audioSource.clip = Open;
                audioSource.Play();
            }
            else{
                uIManager.ShowDialogue("Seems locked, I need to find a key somewhere.");
                audioSource.clip = NotOpen;
                audioSource.Play();
            }
        }
        return false;
    }
}
