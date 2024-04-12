using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject[] inventorySlots = new GameObject[10];

    private int currentItem = 0;

    private bool canAdd = false;

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
            inventorySlots[currentItem] = go;
            holdCurrentObject(go);
        }
        else{
            canAdd = false;
        }
    }

    public void ClearItem(){
        inventorySlots[currentItem] = null;
        uIManager.clearSlots(inventorySlots);
        
    }

    public void NextItem(){
        SetCurrentItem(1);
        holdCurrentObject(GetCurrentItem());
    }

    public void LastItem(){
        SetCurrentItem(-1);
        holdCurrentObject(GetCurrentItem());
    }

    public void holdCurrentObject(GameObject go){
        uIManager.CheckCurrentObject(currentItem);
        uIManager.LoadObjectImages(inventorySlots);
        interactionsManager.HoldObject(go);
    }

    public void DropCurrentObject(){
        interactionsManager.Droping();
        ClearItem();
    }


    public GameObject GetCurrentItem(){
        return inventorySlots[currentItem];
    }

    public int GetCurrentItemInt(){
        return currentItem;
    }

    public void SetCurrentItem(int i){
        if (currentItem == 8 && i == 1){
            currentItem = 0;
        }else if (currentItem==0 && i == -1){
            currentItem = 8;
        }
        else{
            currentItem += i;
        }
    }

}
