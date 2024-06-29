using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Piano : MonoBehaviour, IInteractable
{
    public bool cameraActive;

    private List<string> pianoNotes;

    public GameObject drawer;

    private AudioSource audioPlayer;
   
    // Start is called before the first frame update
    void Start()
    {
        cameraActive = false;
        pianoNotes = new List<string>();
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool Interact(GameObject currentObj)
    {
        cameraActive = true;
        //GetComponent<BoxCollider>().enabled = false;
        return false;
    }

    public void ExitCameraPiano(){
        cameraActive = false;
        //GetComponent<BoxCollider>().enabled = true;
        ResetPianoNotes();
    }

    public void ResetPianoNotes(){
        pianoNotes.Clear();
    }

    public void AddtoPianoNotes(string s){
        pianoNotes.Add(s);
    }

    public List<string> GetPianoNotes(){
        return pianoNotes;
    }

    public void OpenDrawer(){
        drawer.GetComponent<Animator>().SetTrigger("OpenDrawer");
    }

    public void PlayNote(AudioClip note){
        audioPlayer.clip = note;
        audioPlayer.Play();
    }

}
