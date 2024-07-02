using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UIManager : MonoBehaviour
{

    PlayerandCameraHolders plandc;
    
    [SerializeField] public UnityEngine.UI.Image image0;
    [SerializeField] public UnityEngine.UI.Image image1;
    [SerializeField] public UnityEngine.UI.Image image2;
    [SerializeField] public UnityEngine.UI.Image image3;
    [SerializeField] public UnityEngine.UI.Image image4;
    [SerializeField] public UnityEngine.UI.Image image5;
    [SerializeField] public UnityEngine.UI.Image image6;
    [SerializeField] public UnityEngine.UI.Image image7;
    [SerializeField] public UnityEngine.UI.Image image8;

    public GameObject fixedInventory;

    public GameObject slot0;

    public GameObject slot1;

    public GameObject slot2;

    public GameObject slot3;

    public GameObject slot4;

    public GameObject slot5;

    public GameObject slot6;

    public GameObject slot7;

    public GameObject slot8;

    public GameObject hud;

    public GameObject inspectionMenu;
    public TMP_Text gameObjectName;

    public GameObject notePad;

    public TMP_Text dialogueText;

    public GameObject dialogueMenu;

    public GameObject crosshair;

    public Texture2D cursorClose;

    public GameObject PauseMenu;
    

    private List<string> textToShow;



    private PostProcessVolume ppVolume;

    private  Rigidbody playerRB;

    Color32 current;

    Color32 empty;

    InventoryManager inventoryManager;

    private float time;

    private bool firstDialogue;

    private bool playerMove;

    // Start is called before the first frame update
    void Start()
    {
        plandc = GetComponent<PlayerandCameraHolders>();
        current = new Color32(255,145,145,255);
        empty = new Color32(255,145,145,0);
        ppVolume = plandc.Camera.GetComponent<PostProcessVolume>();
        playerRB = plandc.Player.GetComponent<Rigidbody>();
        inventoryManager = gameObject.GetComponent<InventoryManager>();
        textToShow = new List<string>();
        time = Time.deltaTime;
        firstDialogue = true;
        playerMove = true;      
    }

    // Update is called once per frame
    void Update()
    {
        if(textToShow.Count>0){
            time+=Time.deltaTime;
            if(time>10){
                time=0;
                ChangeCurrentDialogue();
            }
        }
        else{
            if(dialogueMenu==null){
                time=0;
            }else{
                time+=Time.deltaTime;
                if(time>10 && dialogueMenu!=null){
                    time=0;
                    ResetDialogue();    
                }
            }
            

        }
        
    }

    public void ChangeCursor(string cursor){
        if(cursor=="close"){
            Cursor.SetCursor(cursorClose, Vector2.zero, CursorMode.ForceSoftware);
            Cursor.lockState = CursorLockMode.None;
        }
        else if(cursor=="locked"){
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void clearSlots(GameObject[] inventorySlots){
        if (inventorySlots[0]== null){
            image0.sprite = null;
            slot0.SetActive(false);
        }
        if (inventorySlots[1]== null){
            image1.sprite = null;
            slot1.SetActive(false);
        }
        if (inventorySlots[2]== null){
            image2.sprite = null;
            slot2.SetActive(false);
        }
        if (inventorySlots[3]== null){
            image3.sprite = null;
            slot3.SetActive(false);
        }
        if (inventorySlots[4]== null){
            image4.sprite = null;
            slot4.SetActive(false);
        }
        if (inventorySlots[5]== null){
            image5.sprite = null;
            slot5.SetActive(false);
        }
        if (inventorySlots[6]== null){
            image6.sprite = null;
            slot6.SetActive(false);
        }
        if (inventorySlots[7]== null){
            image7.sprite = null;
            slot7.SetActive(false);
        }
        if (inventorySlots[8]== null){
            image8.sprite = null;
            slot8.SetActive(false);
        }
    }

    public void CheckCurrentObject(int currentItem){
        if (image0.sprite != null){
            if(currentItem == 0){
                image0.color = current;
            }
            else{ 
                image0.color = Color.white;
            }
        }
        else{
            image0.color = empty;
        }
        if (image1.sprite != null){
            if(currentItem == 1){
                image1.color = current;
            }
            else{ 
                image1.color = Color.white;
            }
        }
        else{
            image1.color = empty;
        }
        if (image2.sprite != null){
            if(currentItem == 2){
                image2.color = current;
            }
            else{ 
                image2.color = Color.white;
            }
        }
        else{
            image2.color = empty;
        }
        if (image3.sprite != null){
            if(currentItem == 3){
                image3.color = current;
            }
            else{ 
                image3.color = Color.white;
            }
        }
        else{
            image3.color = empty;
        }
        if (image4.sprite != null){
            if(currentItem == 4){
                image4.color = current;
            }
            else{ 
                image4.color = Color.white;
            }
        }
        else{
            image4.color = empty;
        }
        if (image5.sprite != null){
            if(currentItem == 5){
                image5.color = current;
            }
            else{ 
                image5.color = Color.white;
            }
        }
        else{
            image5.color = empty;
        }
        if (image6.sprite != null){
            if(currentItem == 6){
                image6.color = current;
            }
            else{ 
                image6.color = Color.white;
            }
        }
        else{
            image6.color = empty;
        }
        if (image7.sprite != null){
            if(currentItem == 7){
                image7.color = current;
            }
            else{ 
                image7.color = Color.white;
            }
        }
        else{
            image7.color = empty;
        }
        if (image8.sprite != null){
            if(currentItem == 8){
                image8.color = current;
            }
            else{ 
                image8.color = Color.white;
            }
        }
        else{
            image8.color = empty;
        }
    }

    public void LoadObjectImages(GameObject[] inventorySlots){
        if(inventorySlots[0] != null){
            slot0.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[0]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image0.sprite = mySprite;
        }
        if(inventorySlots[1] != null){
            slot1.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[1]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image1.sprite = mySprite;
        }
        if(inventorySlots[2] != null){
            slot2.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[2]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image2.sprite = mySprite;
        }
        if(inventorySlots[3] != null){
            slot3.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[3]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image3.sprite = mySprite;
        }
        if(inventorySlots[4] != null){
            slot4.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[4]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image4.sprite = mySprite;
        }
        if(inventorySlots[5] != null){
            slot5.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[5]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image5.sprite = mySprite;
        }
        if(inventorySlots[6] != null){
            slot6.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[6]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image6.sprite = mySprite;
        }
        if(inventorySlots[7] != null){
            slot7.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[7]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image7.sprite = mySprite;
        }
        if(inventorySlots[8] != null){
            slot8.SetActive(value: true);
            var myTexture2D = UnityEditor.AssetPreview.GetAssetPreview(inventorySlots[8]);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image8.sprite = mySprite;
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

    public void ActivateInspectionMenu(GameObject go){
        inspectionMenu.SetActive(true);
        gameObjectName.text = go.name;
    }

    public void UpdateInspectionMenu(GameObject go){
        if(go!=null){
            gameObjectName.text = go.name;
        }   
    }

    public void ActivateNotePad(bool activate){
        ActivateBlur(activate);
        notePad.SetActive(activate);
        HideActiveSlotsandFixesSlots(activate);
        HideCrossair();
        if(activate){
            ChangeCursor("close");
        }
        else{
            ChangeCursor("locked");
        }
    }

    public void HideActiveSlotsandFixesSlots(bool activate){
        GameObject[] inventorySlots = inventoryManager.GetAllItems();
        if(inventorySlots[0]!=null){
            slot0.SetActive(!activate);
            if(inventorySlots[1]!=null){
                slot1.SetActive(!activate);
                if(inventorySlots[2]!=null){
                    slot2.SetActive(!activate);
                    if(inventorySlots[3]!=null){
                        slot3.SetActive(!activate);
                        if(inventorySlots[4]!=null){
                            slot4.SetActive(!activate);
                            if(inventorySlots[5]!=null){
                                slot5.SetActive(!activate);
                                if(inventorySlots[6]!=null){
                                    slot6.SetActive(!activate);
                                    if(inventorySlots[7]!=null){
                                        slot7.SetActive(!activate);
                                        if(inventorySlots[8]!=null){
                                            slot8.SetActive(!activate);
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                }
            }
        }
        fixedInventory.SetActive(!activate);
    }



    public void DeactivateInspectionMenu(){
        inspectionMenu.SetActive(false);
    }

    public void HideUI(bool hide){
        if(hide){
            hud.SetActive(false);
        }
        else{
            hud.SetActive(true);
        }
    }


    public void ActivateBlur(bool activate){
        playerRB.isKinematic = activate;
        ppVolume.enabled = activate;
    }

    public void HideCrossair(){
        if(crosshair.activeSelf){
            crosshair.SetActive(false);
        }
        else{
            crosshair.SetActive(true);
        }
    }

    public void ShowDialogue(string s){
        if(s.Length/120>1){
            textToShow.Add(s[..120]);
            s.Remove(0,120);
            ShowDialogue(s);
        }
        else{
            textToShow.Add(s);
        }
        if(firstDialogue){
            ChangeCurrentDialogue();
        }

    }

    public void ChangeCurrentDialogue(){
        if(textToShow.Count>0){
            dialogueMenu.SetActive(true);
            dialogueText.text = textToShow[0];
            textToShow.RemoveAt(0);
        }
    }

    public void ResetDialogue(){
        if(dialogueMenu.activeSelf==true){
            dialogueText.text = "";
            dialogueMenu.SetActive(false);
        }
    }
    public void ShowPause(){
        playerMove = false;
        PauseMenu.SetActive(true);
        ActivateBlur(true);
        HideCrossair();
        ChangeCursor("close");
    }

    public void HidePause(){
        playerMove = true;
        PauseMenu.SetActive(false);
        ActivateBlur(false);
        HideCrossair();
        ChangeCursor("locked");
    }

    public bool IsPaused(){
        if (playerMove){
            return false;
        }else{
            return true;
        }
    }

}
