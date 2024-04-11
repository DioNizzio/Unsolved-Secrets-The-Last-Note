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
            inventorySlots[currentItem] = go;
            holdCurrentObject(go);
        }
        else{
            canAdd = false;
        }
    }

    public void ClearItem(){
        inventorySlots[currentItem] = null;
        if (inventorySlots[0]== null){
            slot0.sprite = null;
        }
        if (inventorySlots[1]== null){
            slot1.sprite = null;
        }
        if (inventorySlots[2]== null){
            slot2.sprite = null;
        }
        if (inventorySlots[3]== null){
            slot3.sprite = null;
        }
        if (inventorySlots[4]== null){
            slot4.sprite = null;
        }
        if (inventorySlots[5]== null){
            slot5.sprite = null;
        }
        if (inventorySlots[6]== null){
            slot6.sprite = null;
        }
        if (inventorySlots[7]== null){
            slot7.sprite = null;
        }
        if (inventorySlots[8]== null){
            slot8.sprite = null;
        }
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
        CheckCurrentObject();
        LoadObjectImages();
        interactionsManager.HoldObject(go);
    }

    public void DropCurrentObject(){
        interactionsManager.Droping();
        ClearItem();
    }


    public GameObject GetCurrentItem(){
        return inventorySlots[currentItem];
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

    public void CheckCurrentObject(){
        if(currentItem == 0){
            slot0.color = new Color32(0, 0,255,255);
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
    public void LoadObjectImages(){
        if(inventorySlots[0] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[0]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot0.sprite = mySprite;
        }
        if(inventorySlots[1] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[1]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot1.sprite = mySprite;
        }
        if(inventorySlots[2] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[2]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot2.sprite = mySprite;
        }
        if(inventorySlots[3] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[3]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot3.sprite = mySprite;
        }
        if(inventorySlots[4] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[4]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot4.sprite = mySprite;
        }
        if(inventorySlots[5] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[5]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot5.sprite = mySprite;
        }
        if(inventorySlots[6] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[6]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot6.sprite = mySprite;
        }
        if(inventorySlots[7] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[7]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot7.sprite = mySprite;
        }
        if(inventorySlots[8] != null){
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[8]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            slot8.sprite = mySprite;
        }
    }

    public Texture2D GetNewTexture(Texture2D myTexture2D){
        var grey = new Color32(82,82,82,255);
        Texture2D newTexture = new(myTexture2D.width, myTexture2D.height, TextureFormat.RGBA32, true);
        var aaa = myTexture2D.GetPixels32();
        for(int i = 0; i < aaa.Length; i++){
            if(aaa[i].Equals(grey)){
                aaa[i].a = 0;
            }
        }
        newTexture.SetPixels32(aaa);
        newTexture.Apply(true);
        return newTexture;

    }
}
