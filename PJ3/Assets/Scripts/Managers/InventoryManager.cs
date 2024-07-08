using System;
using System.Collections;
using System.Collections.Generic;
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
        ReSortItems();
        uIManager.clearSlots(inventorySlots);
        uIManager.CheckCurrentObject(currentItem);
        holdCurrentObject(inventorySlots[currentItem]);
        
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
        uIManager.LoadObjectImages(inventorySlots);
        uIManager.CheckCurrentObject(currentItem);
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
        if(i==10){
            currentItem = 10;
        }else if (currentItem == 10 && i == 1){
            currentItem = 1;
        }else if (currentItem==10 && i == -1){
            currentItem = 8;
        }
        else if (currentItem == 8 && i == 1){
            currentItem = 0;
        }else if (currentItem==0 && i == -1){
            currentItem = 8;
        }
        else{
            currentItem += i;
        }
    }


    public void ReSortItems(){
        for(int i = 0; i < inventorySlots.Length;i++){
            if (inventorySlots[i]==null){
                for(int k = 0; k < inventorySlots.Length-1;k++){
                    if(k>=i){
                        inventorySlots[k] = inventorySlots[k+1];
                    }
                }
                inventorySlots[^1] = null;
                
            }
        }
        if(inventorySlots[currentItem]==null && currentItem>0){
            currentItem--;
        }
    }


    public GameObject[] GetAllItems(){
        return inventorySlots;
    }
}
