using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskComponents : MonoBehaviour, IInteractable
{
       private Animator animator;
       public Lock deskLock;

       bool open=false;
       AudioSource audioSource;

       public AudioClip openD;

       public AudioClip close;

    // Start is called before the first frame update
    void Start()
    {
        if(name.Contains("1")){
            animator = transform.parent.GetComponent<Animator>();
        }
        else{
            animator = transform.GetComponent<Animator>();
        }
        audioSource = GetComponent<AudioSource>();
    }

    public bool Interact(GameObject currentObj)
    {
        if(name.Contains("Cube")){
            if(deskLock.IsUnlocked()==true){
                animator.SetTrigger("Open");
                open=!open;
                audioSource.clip = openD;
                audioSource.Play();
            }
        }
        else{
            open=!open;
            animator.SetTrigger("Open");
            if(open){
                audioSource.clip = openD;
                audioSource.Play();
            }
            else{
                audioSource.clip = close;
                audioSource.Play();
            }
            
        }
        return false;
    }

}
