using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject SoundOrigin;
    AudioSource audioSource;

    public AudioClip pickKeys;

    public AudioClip pickup;

    public AudioClip drop;

    public AudioClip placeItem;

    public AudioClip bookSliding;

    public AudioClip dialogue;

    public AudioClip page;

    public AudioClip journal;

    public AudioClip notepad;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = SoundOrigin.GetComponent<AudioSource>();
    }


    public void Play(string clip){
        if(!audioSource.isPlaying){
            if(clip.Contains("drop")){
                audioSource.clip = drop;
            }
            else if(clip.Contains("pickKeys")){
                audioSource.clip = pickKeys;
            }
            else if(clip.Contains("pickup")){
                audioSource.clip = pickup;
            } 
            else if(clip.Contains("placeItem")){
                audioSource.clip = placeItem;
            }
            else if(clip.Contains("bookSliding")){
                audioSource.clip = bookSliding;
            }
            else if(clip.Contains("dialogue")){
                audioSource.clip = dialogue;
            }
            else if(clip.Contains("page")){
                audioSource.clip = page;
            }
            else if(clip.Contains("journal")){
                audioSource.clip = journal;
            }
            else if(clip.Contains("notepad")){
                audioSource.clip = notepad;
            }
            audioSource.Play();
        }
    }
}
