using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeManager : MonoBehaviour
{

    public Slider volumeController;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("MasterVolume") !=0){
            volumeController.value = PlayerPrefs.GetFloat("MasterVolume");
        }
        
    }

    public void ChangeMasterVolume(){
        AudioListener.volume = volumeController.value;
        PlayerPrefs.SetFloat("MasterVolume", volumeController.value);
    }
}
