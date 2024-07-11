using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Sprite move;
    public Sprite jump;
    public Sprite uvLantern;
    public Sprite Notepad;
    public Sprite Read;
    public Sprite Interact;
    public Sprite Grab;
    public Sprite Drop;
    public Sprite Inspect;
    public Sprite Crouch;
    public Sprite Arrows;
    public Sprite ESC;

    public Sprite Scroll;

    public Sprite Drag;

    public GameObject ShowingImage;
    public GameObject ShowingImageSmall1;
    public GameObject ShowingImageSmall2;

    bool jumpfirst = true;
    bool uvLanternfirst = true;
    bool Notepadfirst = true;
    bool Interactfirst = true;
    bool Grabfirst = true;
    bool Dropfirst = true;
    bool Inspectfirst = true;
    bool Crouchfirst = true;
    bool ESCfirst = true;

    bool Dragfirst = true;

    bool ScrollFirst = true;

    Animator animator;

    UnityEngine.UI.Image show;

    UnityEngine.UI.Image showSmall1;
    UnityEngine.UI.Image showSmall2;

    public int helper;

    InventoryManager inventoryManager;

    CameraSwitcher cameraSwitcher;

    UIManager uIManager;

    InspectionManager inspectionManager;

    void Start(){
        animator = ShowingImage.GetComponent<Animator>();
        show = ShowingImage.GetComponent<UnityEngine.UI.Image>();
        showSmall1 = ShowingImageSmall1.GetComponent<UnityEngine.UI.Image>();
        showSmall2 = ShowingImageSmall2.GetComponent<UnityEngine.UI.Image>();
        helper = 2;
        inventoryManager = gameObject.GetComponent<InventoryManager>();
        cameraSwitcher = gameObject.GetComponent<CameraSwitcher>();
        uIManager = gameObject.GetComponent<UIManager>();
        inspectionManager = gameObject.GetComponent<InspectionManager>();
    }

    void Update(){
        if(ShowingImage.activeSelf==false){
            if(uIManager.notePad.activeSelf==true ){
                DisplayESC();
                DisplayDrag();
            }else if(cameraSwitcher.GetCurrentCamera().transform.parent.name!="CameraHolder"){
                DisplayESC();
                DisplayArrows();
            }
            else if(inspectionManager.IsInspecting()){
                DisplayESC();
                DisplayInspect();
            }else if(inventoryManager.GetCurrentItem()!=null){
                DisplayInteract();
                //ClearSecond();
            }else{
                uIManager.HideActiveSlotsandFixesSlots(false);
                uIManager.HideCrossair(false);
                ClearInfoImages();
            }
        }
    }
    public void TutorialNext(int i){
        // if(movefirst && i == helper){
        //     show.sprite=move;
        //     movefirst=false;
        //     helper++;
        // } 
        // else 
        if(jumpfirst && i == helper){
            jumpfirst=false;
            show.sprite=jump;
            helper++;
        }
        else if(Crouchfirst && i == helper){
            Crouchfirst=false;
            show.sprite=Crouch;
            helper++;
        }
        else if(Notepadfirst && i == helper){
            Notepadfirst=false;
            show.sprite=Notepad;
            helper+=2;
        }
        else if(!Dragfirst && i == helper){
            Dragfirst=false;
            show.sprite=Drag;
            helper++;
        }
        else if(ESCfirst && i == helper){
            ESCfirst=false;
            show.sprite=ESC;
            helper++;
        }
        else if(uvLanternfirst && i == helper){
            ESCfirst=false;
            uvLanternfirst=false;
            show.sprite=uvLantern;
            helper++;
        }
        else if(Grabfirst && i == helper){
            Grabfirst=false;
            show.sprite=Grab;
            helper++;
        }
        else if(Inspectfirst && i == helper){
            Inspectfirst=false;
            show.sprite=Inspect;
            helper++;
        }
        else if(Interactfirst && i == helper){
            Interactfirst=false;
            show.sprite=Interact;
            helper++;
        }
        else if(ScrollFirst && i == helper){
            ScrollFirst=false;
            show.sprite=Scroll;
            helper++;
        }
        else if(Dropfirst && i == helper){
            Dropfirst=false;
            show.sprite=Drop;
            helper++;
        }
        else if(i == 13 && i == helper){
            ShowingImage.SetActive(false);
        }
    }
    public void DisplayInteract(){
        if(!Inspectfirst){
            ShowingImageSmall1.SetActive(true);
            showSmall1.sprite = Inspect;
            if(inventoryManager.GetAllItems().Distinct().Count()>2){
                ShowingImageSmall2.SetActive(true);
                showSmall2.sprite = Scroll;
            }
        }
    }
    public void DisplayInspect(){
        if(inventoryManager.GetCurrentItem().name.Contains("Page")|| inventoryManager.GetCurrentItem().name.Contains("Diary")){
            ShowingImageSmall2.SetActive(true);
            showSmall2.sprite = Read;
        }else{
            ShowingImageSmall2.SetActive(false);
        }
    }

    public void DisplayESC(){
        if(!ESCfirst){
            ShowingImageSmall1.SetActive(true);
            showSmall1.sprite = ESC;
        }
    }

    // public void DisplayScroll(){        
    //     ShowingImageSmall2.SetActive(true);
    //     showSmall2.sprite = Scroll;
        
    // }

    public void DisplayArrows(){
        if(cameraSwitcher.GetCurrentCamera().transform.parent.name=="no faces on clock"){
            ShowingImageSmall2.SetActive(true);
            showSmall2.sprite = Arrows;
        }else{
            ShowingImageSmall2.SetActive(false);
        }
    }

    public void DisplayDrag(){
        if(uIManager.notePad.activeSelf){
            ShowingImageSmall2.SetActive(true);
            showSmall2.sprite = Drag;
        }else{
            ShowingImageSmall2.SetActive(false);
        }
    }

    public void ClearInfoImages(){
        ShowingImageSmall1.SetActive(false);
        ShowingImageSmall2.SetActive(false);
    }
    public void ClearSecond(){
        ShowingImageSmall2.SetActive(false);
    }
}
