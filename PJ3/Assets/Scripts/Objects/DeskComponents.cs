using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskComponents : MonoBehaviour, IInteractable
{
       private Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
        if(name.Contains("1")){
            animator = transform.parent.GetComponent<Animator>();
        }
        else{
            animator = transform.GetComponent<Animator>();
        }
    }

    public bool Interact(GameObject currentObj)
    {
        animator.SetTrigger("Open");
        return false;
    }

}
