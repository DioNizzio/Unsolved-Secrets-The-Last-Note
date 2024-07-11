using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MusicBox : MonoBehaviour, IInteractable
{
    
    public GameObject door;
    public GameObject drawer;


    public AudioClip music; 

    private AudioSource audioPlayer;

    public bool cameraActive;

    private bool openned;

    public UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        cameraActive = false;
        audioPlayer = gameObject.transform.parent.transform.parent.gameObject.GetComponent<AudioSource>();
        openned = false;
    }

    // Update is called once per frame
    public bool Interact(GameObject currentObj)
    {
        if(cameraActive){
            if(music!=null){
                audioPlayer.clip = music;
                audioPlayer.Play();
            }
            transform.parent.GetComponent<Animator>().SetTrigger("OpenBox");
            door.GetComponent<Animator>().SetTrigger("OpenBox");
            drawer.GetComponent<Animator>().SetTrigger("OpenBox");
            openned = true;
            uIManager.ShowDialogue("This sounds like the song he played in the beggining. I miss you.");
        }
        else{
            cameraActive=true;
            GetComponent<BoxCollider>().enabled = false;
        }
        
        return false;

    }

    public void ExitCameraMusicBox(){
        cameraActive = false;
        if(!openned){
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}
