using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] public UnityEngine.UI.Image slot0;
    [SerializeField] public UnityEngine.UI.Image slot1;
    [SerializeField] public UnityEngine.UI.Image slot2;
    [SerializeField] public UnityEngine.UI.Image slot3;
    [SerializeField] public UnityEngine.UI.Image slot4;
    [SerializeField] public UnityEngine.UI.Image slot5;
    [SerializeField] public UnityEngine.UI.Image slot6;
    [SerializeField] public UnityEngine.UI.Image slot7;
    [SerializeField] public UnityEngine.UI.Image slot8;

    private GameObject[] inventorySlots = new GameObject[10];

    private int currentItem = 0;

    private bool canAdd = false;

    InteractionsManager interactionsManager;
    // Start is called before the first frame update


    void Start()
    {
        interactionsManager = gameObject.GetComponent<InteractionsManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddItem(GameObject go){
        for(int i = 0; i < 9; i++){
            if(inventorySlots[i] == null){
                canAdd = true;
                inventorySlots[i] = go;
                if(i!=currentItem){
                    currentItem = i;
                }
                holdCurrentObject(go);
                break;
            }
        }
        
        if (canAdd == false){
            DropCurrentObject();
            holdCurrentObject(go);
            inventorySlots[currentItem] = go;
        }
        else{
            canAdd = false;
        }
        // for(int i = 0; i < 9; i++){
        //     if(inventorySlots[i] != null){
        //         Debug.Log(i + ": " + inventorySlots[i]);
        //     }
        // }
    }

    public void ClearItem(){
        inventorySlots[currentItem] = null;
    }

    public void NextItem(){
        if (currentItem == 8){
            currentItem = 0;
        }
        else{
            currentItem++;
        }
        holdCurrentObject(GetCurrentItem());
    }

    public void LastItem(){
        if (currentItem>0){
            currentItem--;
        }
        else{
            currentItem = 8;
        }
        holdCurrentObject(GetCurrentItem());
    }

    public void holdCurrentObject(GameObject go){
        CheckCurrentObject();
        interactionsManager.HoldObject(go);
    }

    public void DropCurrentObject(){
        interactionsManager.Droping();
        ClearItem();
    }


    public GameObject GetCurrentItem(){
        return inventorySlots[currentItem];
    }

    public void CheckCurrentObject(){
        if(currentItem == 0){
            slot0.color = new Color32(255,145,145,255);
        }
        else{
            slot0.color = Color.white;
        }
        if(currentItem == 1){
            slot1.color = new Color32(255,145,145,255);
        }
        else{
            slot1.color = Color.white;
        }
        if(currentItem == 2){
            slot2.color = new Color32(255,145,145,255);
        }
        else{
            slot2.color = Color.white;
        }
        if(currentItem == 3){
            slot3.color = new Color32(255,145,145,255);
        }
        else{
            slot3.color = Color.white;
        }
        if(currentItem == 4){
            slot4.color = new Color32(255,145,145,255);
        }
        else{
            slot4.color = Color.white;
        }
        if(currentItem == 5){
            slot5.color = new Color32(255,145,145,255);
        }
        else{
            slot5.color = Color.white;
        }
        if(currentItem == 6){
            slot6.color = new Color32(255,145,145,255);
        }
        else{
            slot6.color = Color.white;
        }
        if(currentItem == 7){
            slot7.color = new Color32(255,145,145,255);
        }
        else{
            slot7.color = Color.white;
        }
        if(currentItem == 8){
            slot8.color = new Color32(255,145,145,255);
        }
        else{
            slot8.color = Color.white;
        }
    }
}
