using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Video;

public class VisionsManager : MonoBehaviour
{

    private float globalTime = 0.0f;
    public VideoClip hour1;
    // public Image hour2;
    // public Image hour3;
    public GameObject imageShowing;
    public VideoPlayer videoPlayer;

    CameraSwitcher cameraSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        //imageShowing = showing.GetComponent<Image>();
        cameraSwitcher = gameObject.GetComponent<CameraSwitcher>();
        globalTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.clip != null){
            globalTime += Time.deltaTime;
            if (globalTime>videoPlayer.clip.length){
                globalTime = 0.0f;
                imageShowing.SetActive(false);
                videoPlayer.clip = null;
            }
        }
    }

    public void ShowImage(string s){
        if(s.Contains("1")){    
            imageShowing.SetActive(true);
            videoPlayer.clip = hour1;
            videoPlayer.Play();
            cameraSwitcher.ExitCurrentCamera();
        }

        if(s.Contains("2")){    
            imageShowing.SetActive(true);
            //videoPlayer.clip = hour2;
            videoPlayer.Play();
            cameraSwitcher.ExitCurrentCamera();
        }

        if(s.Contains("3")){    
            imageShowing.SetActive(true);
            //videoPlayer.clip = hour3;
            videoPlayer.Play();
            cameraSwitcher.ExitCurrentCamera();
        }
    }
}
