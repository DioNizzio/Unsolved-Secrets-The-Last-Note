using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CypherWheelParts : MonoBehaviour, IInteractable
{
    public CypherWheel cypher;

    public bool Interact(GameObject currentObj)
    {
        if(name.Contains("2")){
            cypher.PlayAnimations(3);
        }else  if(name.Contains(value: "1")){
            cypher.PlayAnimations(2);
        }else{
            cypher.PlayAnimations(1);
        }
        return false;
    }
}
