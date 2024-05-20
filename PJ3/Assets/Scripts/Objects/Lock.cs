using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, IInteractable
{

    public bool cameraActive;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;

    public bool isUnlocked = false;
    public bool IsUnlocked(){
        return isUnlocked;
    }

    public bool Interact(GameObject currentObj)
    {
        cameraActive = true;
        GetComponent<BoxCollider>().enabled = false;
        return false;
    }

    public void ExitCameraLock(){
        cameraActive = false;
        GetComponent<BoxCollider>().enabled = true;
    }
}
