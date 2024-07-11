using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{

    public GameObject lantern;

    public GameObject wallBooks;

    public GameObject wallDesk;
    public GameObject wallDesk2;


    public GameObject clockBell1;


    public GameObject clockBell2;

    public GameObject clockBell3;

    public Material wallB1;
    public Material wallB2;

    public Material wallD1;
    public Material wallD2;
    public Material wallD3;
    public Material bells;

    public Material bells2;
    InteractionsManager interactionsManager;

    PlayerandCameraHolders playerandCameraHolders;

    UIManager uIManager;

    AudioSource audioSource;

    public AudioClip on;
    public AudioClip off;

    // Start is called before the first frame update
    void Start()
    {
        interactionsManager = gameObject.GetComponent<InteractionsManager>();
        uIManager = gameObject.GetComponent<UIManager>();
        playerandCameraHolders = gameObject.GetComponent<PlayerandCameraHolders>();
        audioSource = lantern.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsUsingLantern()){
            RaycastHit hit;
            if (Physics.Raycast(lantern.transform.position, lantern.transform.forward*-1, out hit, 10))
            {
                GameObject target = hit.transform.gameObject;
                if (target != null)
                {

                    if(target.name == "relogio"){
                        clockBell1.GetComponent<MeshRenderer>().material = bells2;
                        clockBell2.GetComponent<MeshRenderer>().material = bells2;
                        clockBell3.GetComponent<MeshRenderer>().material = bells2;
                    }
                    else{
                        clockBell1.GetComponent<MeshRenderer>().material = bells;
                        clockBell2.GetComponent<MeshRenderer>().material = bells;
                        clockBell3.GetComponent<MeshRenderer>().material = bells;
                    }
                    // if(target==clockBell1){
                    //     clockBell1.GetComponent<MeshRenderer>().material = bells2;
                    // }
                    // if(target==clockBell2){
                    //     clockBell2.GetComponent<MeshRenderer>().material = bells2;
                    // }
                    // if(target==clockBell3){
                    //     clockBell3.GetComponent<MeshRenderer>().material = bells2;
                    // }
                    if(target==wallBooks){
                        wallBooks.GetComponent<MeshRenderer>().material = wallB2;
                    }else{
                        wallBooks.GetComponent<MeshRenderer>().material = wallB1;
                    }
                    if(target==wallDesk){
                        wallDesk.GetComponent<MeshRenderer>().material = wallD1;
                    }else if(target==wallDesk2){
                        wallDesk2.GetComponent<MeshRenderer>().material = wallD2;
                    }
                    else{
                        wallDesk.GetComponent<MeshRenderer>().material = wallD3;
                        wallDesk2.GetComponent<MeshRenderer>().material = wallD3;
                    }
                }
                else{
                    clockBell1.GetComponent<MeshRenderer>().material = bells;
                    clockBell2.GetComponent<MeshRenderer>().material = bells;
                    clockBell3.GetComponent<MeshRenderer>().material = bells;
                    wallBooks.GetComponent<MeshRenderer>().material = wallB1;
                    wallDesk.GetComponent<MeshRenderer>().material = wallD3;
                    wallDesk2.GetComponent<MeshRenderer>().material = wallD3;

                }
            }
        }
        else{
            clockBell1.GetComponent<MeshRenderer>().material = bells;
            clockBell2.GetComponent<MeshRenderer>().material = bells;
            clockBell3.GetComponent<MeshRenderer>().material = bells;
            wallBooks.GetComponent<MeshRenderer>().material = wallB1;
            wallDesk.GetComponent<MeshRenderer>().material = wallD3;
            wallDesk2.GetComponent<MeshRenderer>().material = wallD3;
        }
    }

    public void ActivateLantern(){
        if(!lantern.activeSelf){
            wallBooks.GetComponent<BoxCollider>().enabled=true;
            clockBell1.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled=true;
            if(interactionsManager.IsHolding()){
                interactionsManager.ClearHeldObj();
                lantern.SetActive(true);
                uIManager.HideCrossair(true);
            }
            else{
                lantern.SetActive(true);
                uIManager.HideCrossair(true);
            }
            audioSource.clip = on;
            audioSource.Play();
        }
        else{
            audioSource.clip = off;
            audioSource.Play();
            wallBooks.GetComponent<BoxCollider>().enabled=false;
            clockBell1.transform.parent.transform.parent.GetComponent<BoxCollider>().enabled=false;
            lantern.SetActive(false);
            uIManager.HideCrossair(false);
        }
    }
    
    public bool IsUsingLantern(){
        if (lantern.activeSelf){
            return true;
        }
        return false;
    }
}
