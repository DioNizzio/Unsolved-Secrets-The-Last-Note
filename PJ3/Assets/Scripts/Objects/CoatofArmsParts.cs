using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoatofArmsParts : MonoBehaviour, IInteractable
{
    public GameObject coatOfArms;

    public bool Interact(GameObject currentObj)
    {
        return coatOfArms.GetComponent<CoatofArms>().Interact(currentObj);
    }
}
