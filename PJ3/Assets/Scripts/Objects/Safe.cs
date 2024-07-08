using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Safe : MonoBehaviour, IInteractable
{
    public bool cameraActive;

    private string code;

    private bool needsCheck;

    public GameObject trincos;

    public GameObject door;

    public GameObject handle;

    public bool hideNums;

    public AudioClip b1;
    public AudioClip b2;
    public AudioClip b3;
    public AudioClip b4;
    public AudioClip b5;
    public AudioClip fail;
    public AudioClip success;

    private AudioSource audioSource;

    

    // Start is called before the first frame update
    void Start()
    {
        cameraActive = false;
        needsCheck = false;
        hideNums = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(GameObject currentObj)
    {
        cameraActive = true;
        GetComponent<BoxCollider>().enabled = false;
        return false;
    }

    public void PlayAnimations(bool right){
        if (right){
            trincos.GetComponent<Animator>().SetTrigger("RightCode");
            handle.GetComponent<Animator>().SetTrigger("RightCode");
            door.GetComponent<Animator>().SetTrigger("RightCode");
            hideNums = true;
            audioSource.clip = success;
        }
        else{
            handle.GetComponent<Animator>().SetTrigger("WrongCode");
            audioSource.clip = fail;
        }
        audioSource.Play();
    }

    public void ExitCameraSafe(){
        cameraActive = false;
        GetComponent<BoxCollider>().enabled = true;
    }


    public void AddToCode(string i){
        code += i;
        if(i.Contains("1") || i.Contains("6")){
            audioSource.clip = b1;
        }
        else if(i.Contains("2") || i.Contains("7")){
            audioSource.clip = b2;
        }
        else if(i.Contains("3") || i.Contains("8")){
            audioSource.clip = b3;
        }
        else if(i.Contains("4") || i.Contains("9")){
            audioSource.clip = b4;
        }
        else if(i.Contains("5") || i.Contains("0")){
            audioSource.clip = b5;
        }
        audioSource.Play();
    }

    public void ResetCode(){
        code = "";
    }

    public string GetCode(){
        return code;
    }

    public void SetNeedsCheck(){
        needsCheck = !needsCheck;
    }

    public bool GetNeedsCheck(){
        return needsCheck;
    }

}
