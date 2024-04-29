using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{

    public GameObject lantern;
    InteractionsManager interactionsManager;

    UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        interactionsManager = gameObject.GetComponent<InteractionsManager>();
        uIManager = gameObject.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void ActivateLantern(){
        if(!lantern.activeSelf){
            if(interactionsManager.IsHolding()){
                interactionsManager.ClearHeldObj();
                lantern.SetActive(true);
                uIManager.HideCrossair();
            }
            else{
                lantern.SetActive(true);
                uIManager.HideCrossair();
            }
        }
        else{
            lantern.SetActive(false);
            uIManager.HideCrossair();
        }
    }

    public bool IsUsingLantern(){
        if (lantern.activeSelf){
            return true;
        }
        return false;
    }
}
