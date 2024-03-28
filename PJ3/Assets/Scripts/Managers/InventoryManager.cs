using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private GameObject[] inventorySlots = new GameObject[10];

    private int currentItem = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(GameObject go){
        for(int i = 1; i < 10; i++){
            if(inventorySlots[i] == null){
                inventorySlots[i] = go;
                break;
            }
        }

    }

    public void NextItem(){
        if (currentItem == 9){
            currentItem = 0;
        }
        else{
            currentItem++;
        }
    }

    public void LastItem(){
        if (currentItem>0){
            currentItem--;
        }
    }

    public GameObject GetCurrentItem(){
        return inventorySlots[currentItem];
    }
}
