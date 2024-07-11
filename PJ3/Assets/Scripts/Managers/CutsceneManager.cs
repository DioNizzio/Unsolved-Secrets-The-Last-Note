using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{

    VideoPlayer videoPlayer;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time>videoPlayer.clip.length){
            SceneManager.LoadScene(0);
        }
    }

    
}
