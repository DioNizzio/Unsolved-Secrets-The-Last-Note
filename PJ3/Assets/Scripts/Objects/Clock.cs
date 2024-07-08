using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
    public bool cameraActive;

    private string bellSequence;

    public GameObject drawer;

    public ClockHands hours;
    public ClockHands minutes;

    private AudioSource audioSource;
    
    public AudioClip bells;
    public AudioClip ticking;

    public AudioClip correct;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraActive = false;
        bellSequence = "";
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public bool Interact(GameObject currentObj)
    {
        cameraActive = true;
        GetComponent<BoxCollider>().enabled = false;
        return false;
    }
    
    public void ExitCameraClock(){
        cameraActive = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void AddToBellSequence(string s){
        if(bellSequence.Length==3){
            bellSequence = "";
        }
        bellSequence += s;
        audioSource.clip = bells;
        audioSource.Play();
    }

    public string GetBellSequence(){
        return bellSequence;
    }

    public void OpenDrawer(){
        drawer.GetComponent<Animator>().SetTrigger("OpenGaveta");
        audioSource.clip = correct;
        audioSource.Play();
    }

    public void RotateHands(int angle){
        hours.Rotate(angle);
        minutes.Rotate(angle);
        audioSource.clip = ticking;
        audioSource.Play();
    }
}
