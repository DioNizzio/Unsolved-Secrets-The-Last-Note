using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

// Every interactable object has to have this interface implemented
interface IInteractable{
    public void Interact();
}

public class InteractionsManager : MonoBehaviour
{
    // Origin Point of the interaction: our player
    public Transform interactorSource;

    // distance to which he can interact
    public float interactRange;

    public Camera cam;

    public void Interaction(){
        // Interaction ray
        Ray r = new Ray(interactorSource.position, cam.transform.forward);
        // If the ray catches anything in the range, it will try to interact with it
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange)){
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)){
                interactObj.Interact();
            }
        }
    }
}
