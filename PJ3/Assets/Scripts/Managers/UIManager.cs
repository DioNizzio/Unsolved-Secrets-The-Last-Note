using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

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

    public Texture2D grabHand;

    public Texture2D lupa;

    public GameObject PauseMenu;

    public GameObject Options;

    public GameObject ExitPanel;

    public TMP_Text readPages;
    

    private List<string> textToShow;

    private int diary = 1;

    private PostProcessVolume ppVolume;

    private  Rigidbody playerRB;

    Color32 current;

    Color32 empty;

    InventoryManager inventoryManager;

    SoundManager soundManager;

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
        soundManager = gameObject.GetComponent<SoundManager>();    
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
            if(dialogueMenu.activeSelf==false){
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
        else if(cursor=="grab"){
            Cursor.SetCursor(grabHand, Vector2.zero, CursorMode.ForceSoftware);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(cursor=="lupa"){
            Cursor.SetCursor(lupa, Vector2.zero, CursorMode.ForceSoftware);
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
            // string[] assetPaths = AssetDatabase.GetAllAssetPaths();
            // if (!AssetDatabase.IsValidFolder("Assets/Previews2"))
            // {
            //     AssetDatabase.CreateFolder("Assets", "Previews2");
            // }
            // foreach (string assetPath in assetPaths)
            // {
            //     if(assetPath.Contains(".fbx")){
            //         Debug.Log("" + assetPath);
            //         UnityEngine.Object asset = AssetDatabase.LoadMainAssetAtPath(assetPath);
            //         if (asset != null)
            //         {
            //             Texture2D preview = AssetPreview.GetAssetPreview(asset);
            //             if (preview != null)
            //             {
            //                 byte[] bytes = preview.EncodeToPNG();
            //                 string previewPath = Path.Combine("Assets/Previews2", asset.name + "_preview.png");
            //                 File.WriteAllBytes(previewPath, bytes);
            //             }
            //         }
            //     }
                
            // }

            // AssetDatabase.Refresh();
            byte[] img;
            if(inventorySlots[0].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[0].gameObject.name+"_preview.png"));
            }else if(inventorySlots[0].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image0.sprite = mySprite;
        }
        if(inventorySlots[1] != null){
            slot1.SetActive(value: true);
            byte[] img;
            if(inventorySlots[1].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[1].gameObject.name+"_preview.png"));
            }else if(inventorySlots[1].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image1.sprite = mySprite;
        }
        if(inventorySlots[2] != null){
            slot2.SetActive(value: true);
            byte[] img;
            if(inventorySlots[2].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[2].gameObject.name+"_preview.png"));
            }else if(inventorySlots[2].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image2.sprite = mySprite;
        }
        if(inventorySlots[3] != null){
            slot3.SetActive(value: true);
            byte[] img;
            if(inventorySlots[3].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[3].gameObject.name+"_preview.png"));
            }else if(inventorySlots[3].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image3.sprite = mySprite;
        }
        if(inventorySlots[4] != null){
            slot4.SetActive(value: true);
            byte[] img;
            if(inventorySlots[4].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[4].gameObject.name+"_preview.png"));
            }else if(inventorySlots[4].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image4.sprite = mySprite;
        }
        if(inventorySlots[5] != null){
            slot5.SetActive(value: true);
            byte[] img;
            if(inventorySlots[5].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[5].gameObject.name+"_preview.png"));
            }else if(inventorySlots[5].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image5.sprite = mySprite;
        }
        if(inventorySlots[6] != null){
            slot6.SetActive(value: true);
            byte[] img;
            if(inventorySlots[6].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[6].gameObject.name+"_preview.png"));
            }else if(inventorySlots[6].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image6.sprite = mySprite;
        }
        if(inventorySlots[7] != null){
            slot7.SetActive(value: true);
            byte[] img;
            if(inventorySlots[7].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[7].gameObject.name+"_preview.png"));
            }else if(inventorySlots[7].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);
            var mySprite = Sprite.Create(GetNewTexture(myTexture2D), new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            image7.sprite = mySprite;
        }
        if(inventorySlots[8] != null){
            slot8.SetActive(value: true);
            byte[] img;
            if(inventorySlots[8].gameObject.name!=null){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, inventorySlots[8].gameObject.name+"_preview.png"));
            }else if(inventorySlots[8].gameObject.name.Contains("Lighter")){
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Lighter_preview.png"));
            }
            else {
                img = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "Diary_preview.png"));
            }
            Texture2D myTexture2D = new Texture2D(128, 128);
            myTexture2D.LoadImage(img);
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
        HideCrossair(true);
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
        HideCrossair(true);
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
        HideCrossair(false);
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

    public void HideCrossair(bool hide){
        if(hide){
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
        soundManager.Play("dialogue");
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
        HideCrossair(true);
        ChangeCursor("close");
    }

    public void HidePause(){
        playerMove = true;
        PauseMenu.SetActive(false);
        ActivateBlur(false);
        HideCrossair(true);
        ChangeCursor("locked");
    }

    public bool IsPaused(){
        if (playerMove){
            return false;
        }else{
            return true;
        }
    }

    public void ReadPages(GameObject current = null){
        if(current==null){

        }
        else if(current.name.Contains("2")){
            readPages.text = "May 15th\n\nRain again today. As the drops patter against the window, my thoughts drift to Salisbury, a place forever etched in my heart. The town, so rich with history, brimmed with music at every corner, an ever-present serenade that now, in this quieter setting, I find myself longing for deeply.\nHere, the nights unfold in silence—a stark contrast to those vibrant Salisbury evenings where the air was alive with the hum of piano keys and spirited conversations. I often found myself amidst groups of music lovers, debating the merits of compositions old and new, quietly ranking our favorite masters in a game of shared admiration.\nThere were many a night when Mozart's melodies would spark lively debates, or when Beethoven's powerful sonatas filled our hearts with awe. Sergei's compositions often whispered into our evening gatherings, his pieces painting sorrow and ecstasy with such raw beauty. And of course, Bach's structured fugues provided a foundation for many arguments on musical theory and the beauty of order.";
        }
        else if(current.name.Contains("3")){
            readPages.text = "September 21st\n\nThere's a peculiar stillness in Williamsburg at 7:30 in the morning, a quiet that feels foreign to me. The first light of dawn barely touches the old brick buildings, casting long shadows that stretch across the cobblestone streets. I often find myself wandering these paths, avoiding the sun's first rays, as the world around me begins to stir.\nIn Salisbury, mornings were a prelude to the day's symphony, a time of anticipation. Here, the air is thick with humidity, and the only sounds are the distant calls of birds and the occasional footsteps of early risers. The charm of this place lies in its history, yet it lacks the vibrant spirit that once filled my mornings with joy.\nAs I walk through the city, I think of those precious moments back in Salisbury—the bustle of 7:30 am when the town came alive, each day a new composition waiting to be played. Here, I move through the quiet streets of Williamsburg, a silent observer in a world that feels strangely apart from my own. The longing for my true home grows with each passing dawn, a melody of memories that plays endlessly in my heart.";
        }
        else if(current.name.Contains("4")){
            readPages.text = "even the smallest details can hold great significance.\ntoday, as i walked through the gardens, i noticed the  first blooms of spring beginning to emerge. the delicate petals, unfurling in the morning light, reminded me that <b>R</b>enewal is a constant part of life. it’s easy to overlook these moments in the rush of our daily routines, but they are the ones that bring color and meaning to our existence.\nthis morning, i took the time to enjoy a quiet cup of  tea before the day’s demands set in. the simple act of sitting in stillness, watching the steam rise and feeling the warmth of the cup in my hands, grounded <b>M</b>e. it’s moments like these that remind us to breathe, to pause, and to appreciate the present.\nas you go about your day, <b>T</b>ake a moment to notice the world around you. listen to the rustle of leaves in the breeze, feel the texture of the earth beneath your feet, and let the small wonders of life fill you with a sense of peace. these are the moments that sustain us, that give us strength and clarity.\nmay you find <b>J</b>oy in the simplest things.\n\n-emrick godfrey";
        }
        else if(current.name.Contains("5")){
            readPages.text = "Title: 'Happy Birthday' or is it?\nOrder:\n\n- 3g (2x) - 3g# - 3g - 4c - 3b\n\n- 3g (2x) - 3g# - 3g - 4d - 4c\n\n- 3g (2x) - 4g - 4e - 4c - 3b - 3g#\n\n- 4f (2x) - 4e - 4c# - 4d - 4c";
        }
        else if(current.name.Contains("6")){
            readPages.text = "   2        3       4\n\n ABC  DEF  GHI\n   5        6         7\n\n JKL  MNO  PQRS\n   8          9\n TUV  WXYZ";
        }
        else if(current.name.Contains("7")){
            readPages.text = "October 10th, 1999\n\nToday, young Lisa did not show up for her lesson. I hope everything is alright at home. She has been progressing so well, and it would be a shame for her to fall behind. I'll give her parents a call this evening to check in and offer to reschedule her session. Every child's musical journey is important, and I want to ensure she doesn't miss out on the joy and discipline that music brings.\n\nOctober 14th, 1999\n\nAndrew arrived on time today and played beautifully. His progress is truly remarkable. I'm so proud of his dedication and hard work. His parents have every reason to be proud as well. I'll send them a note this evening to share my praise and encourage them to continue supporting his practice at home. Positive reinforcement is key to fostering a lifelong love of music.";
        }
        else if(current.name.Contains("8")){
            readPages.text = "7th January, 1999\nIt's always so dark in here. Today, during our piano lesson, Timmy tried to open the curtains to let in some sunlight. I thought the bright light might help us read the sheet music better.\nBut, as soon as he started pulling them back, the professor shouted at him. He looked really angry, more than I've ever seen him before. He rushed over and yanked the curtains closed again, muttering something under his breath. I don't understand why he's so strict about keeping the room dark all the time. It's not like a little sunlight would hurt anything, right? Anyway, we'll just have to get used to playing in the dim light.";
        }
        else if(current.name.Contains("9")){
            readPages.text = "I only saw these stories with my dad, but he's gotta be a vampire. There's no other option. Those teeth, the shortage of light, and he still looks young for such a serious person. He never comes outside during the day, and he got really upset when Andrew tried to open the curtains. I even saw him avoid garlic last week. Everything fits the stories Dad told me.\nI'll see tomorrow. Dad, I'm gonna solve this case.\nJust like you do!";
        }
        else if(current.name.Contains("9")){
            readPages.text = "I only saw these stories with my dad, but he's gotta be a vampire. There's no other option. Those teeth, the shortage of light, and he still looks young for such a serious person. He never comes outside during the day, and he got really upset when Andrew tried to open the curtains. I even saw him avoid garlic last week. Everything fits the stories Dad told me.\nI'll see tomorrow. Dad, I'm gonna solve this case.\nJust like you do!";
        }
        else if(current.name.Contains("10")){
            readPages.text = "Those were the days when music felt like the very  pulse of existence, a sentiment sorely missing where  I now reside. The absence of this musical  communion has left a quiet void in my evenings. I sometimes indulge in the memory of those discussions, each note and nuance, and wonder if such richness will ever grace my days again.\nFor now, these memories must suffice, as I sit in the solitude of my current retreat, the rain's rhythm a faint echo of piano keys from a world away. Maybe tomorrow will carry a melody, a whisper of the past, or perhaps a promise of a return to the music-filled streets of Salisbury.\nThere was a certain magic to 11:45 in Salisbury. It was the time when the sun began its gentle descent, casting a golden glow over the town, and the streets would fill with the soft murmur of people coming together. Here, this time is just another minute, but in Salisbury, it was a moment of pure enchantment.\nUntil then, this diary shall hold my confessions, my silent songs of yearning for a city that sang to the very beat of my soul.";
        }
        else if(current.name.Contains("11")){
            readPages.text = "May 9th, 2000\nIt's been an exhausting night. It's 3:15 and I feel utterly drained and can barely keep my eyes open. I need to replenish my energy soon. Thankfully, I have those bottles, full of their blood, ready for just such an occasion. They always give me the strength I need to carry on, especially after nights like this.\nThe events with Timmy have taken a toll on me. I must remain vigilant and ensure no more slip-ups occur. But first,I need to regain my strength. A quick drink should do the trick.";
        }
        else if(current.name.Contains("Newspaper")){
            readPages.text = "Salisbury Journal\nVolume 36, Issue 7 October 1952\nBodies Found: Mass Murderer or Animal Revenge? the dense, shadowy depths of Pinewood Forest, a chilling discovery was made that left the local community in a state of shock and fear. Over the span of several weeks, the bodies of seven hikers were found scattered in various locations within the forest. Each body bore signs of a violent end, but the exact cause of death remained shrouded in mystery. The initial examinations revealed deep gashes and fang-like marks on the victims, raising the terrifying question of whether these unfortunate souls had fallen prey to a vicious animal or something more sinister. The police is putting every resoure possible into finding who or what is responsible for these acts and to put a stop to it. The local authorities, baffled by the gruesome findings, launched an extensive investigation, calling in forensic experts and wildlife specialists to help unravel the enigma. The presence of large predators in the area, such as bears or mountain lions, made the animal attack theory plausible. However, certain inconsistencies in the injuries and the distribution of the bodies suggested that a human element might be involved. The lack of definitive evidence pointing conclusively to either scenario left the investigators in a perplexing quandary, unable to rule out the possibility of a deranged individual lurking in the forest. If these attacks were done by a human being, he is most likely long gone from Salisbury, although the authorities fear he is still in town. More to come on this story in the next editions.";
        }
        else if(current.name.Contains("Diary")){
            if(diary==1){
                readPages.text = "April 16th, 2000\n\nThis Timmy seems to be noticing some things. I have to be careful not to commit the same mistake again. Today, he tried to open the curtains during our piano lesson. The moment the sunlight started to filter in, I felt a surge of panic. I couldn't let him see my reaction, but I know I was too harsh when I shouted at him. His eyes widened in surprise and maybe even a bit of fear. I must remember to stay calm and composed, no matter what.\nHe's a clever boy, always asking questions and observing everything around him. Last week, he noticed my aversion to garlic when he brought a snack to class. I had to make up a quick excuse about allergies.\nAnd just yesterday, he commented on how he's never seen me during the day outside of our lessons. I laughed it off, saying I'm a night owl, but I could tell he wasn't entirely convinced.\nI can't afford to be careless. The last thing I need is for Timmy—or anyone else—to discover my true nature. I'll have to keep a close watch on Timmy. He's perceptive, and his curiosity could be dangerous. For now, I'll continue to play the part of the strict, eccentric piano teacher. But, I must stay vigilant. One slip-up could unravel everything.\n1/2";
                diary=2;
            }else if(diary==2){
                readPages.text = "May 8th, 2000\n\nCrap, that Timmy noticed the other kid's notebook. I shouldn't have rampaged out. My teeth were out, maybe now he knows too much.\nIt all happened so quickly. Timmy had finished his lesson and was gathering his things when he spotted a notebook left behind by one of my other students. I didn't think much of it until I saw the look of curiosity in his eyes as he flipped through the pages. Then, he found the note about the dark room and my odd behavior.\nIn a moment of panic, I snatched the notebook from his hands, I saw the shock on his face as my teeth extended just for a split second, but long enough for him to see. He backed away, fear and confusion mingling in his wide eyes. I quickly composed myself, but the damage was done.\nI made up a flimsy excuse about needing privacy and that the notebook contained personal information, but I could see he wasn't convinced. Timmy is smart, too smart. He'll start putting the pieces together if he hasn't already.\nI need to handle this situation carefully, but one thing is certain, I must be more vigilant than ever. I can't afford any more mistakes\n2/2.";
                diary=1;
            }
        }
        else{
            readPages.text="";
            readPages.gameObject.SetActive(false);
        }
        if(current==null){
            readPages.gameObject.SetActive(false);
        }else{
            readPages.gameObject.SetActive(true);
        }
        //readPages.gameObject.SetActive(!readPages.gameObject.activeSelf);
        //enabled = true;
    }

}
