using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBells : MonoBehaviour, IInteractable
{
    
    private Animator animator;

    public Clock clock;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public bool Interact(GameObject currentObj)
    {
        animator.SetTrigger("Interact");
        clock.AddToBellSequence(name.ToCharArray()[name.Length-1].ToString());
        return false;
    }
}
