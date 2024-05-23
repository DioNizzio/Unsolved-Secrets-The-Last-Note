using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour, IInteractable
{
    
    public GameObject door;
    public GameObject drawer;

    public AudioClip music; 

    private AudioSource audioPlayer;

    

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.transform.parent.transform.parent.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public bool Interact(GameObject currentObj)
    {
        if(music!=null){
            audioPlayer.clip = music;
            audioPlayer.Play();
        }
        transform.parent.GetComponent<Animator>().SetTrigger("OpenBox");
        door.GetComponent<Animator>().SetTrigger("OpenBox");
        drawer.GetComponent<Animator>().SetTrigger("OpenBox");
        return false;

    }
}
