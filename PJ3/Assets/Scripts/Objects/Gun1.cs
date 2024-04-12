using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(gameObject.name);
    }

}
