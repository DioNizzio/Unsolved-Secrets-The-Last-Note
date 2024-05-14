using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockDoor : MonoBehaviour, IInteractable
{

    private Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    public bool Interact(GameObject currentObj)
    {
        animator.SetTrigger("OpenDoor");
        return false;
    }

}
