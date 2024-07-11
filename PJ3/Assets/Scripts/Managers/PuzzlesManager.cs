using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzlesManager : MonoBehaviour
{

    public GameObject paintingMozart;
    public GameObject paintingBeethoven;
    public GameObject paintingRachmaninoff;
    public GameObject paintingBach;

    public GameObject Shelf1;
    public GameObject Shelf2;
    public GameObject Shelf3;
    public GameObject Shelf4;
    public GameObject Shelf5;

    public Safe safe;

    public Clock clock;

    public Piano piano;

    public Lock locky;

    public Lock deskLock;

    public Fireplace fireplace;

    public GameObject locky2;

    public GameObject deskLock2;

    public GameObject bookshelfCompartment1;

    public GameObject bookshelfCompartment2;

    public GameObject keyGlobe;
    public GameObject keyTutorial;

    public GameObject triggerEnd;



    public CoatofArms coatofArms;

    public Pedestal pedestal;

    public CypherWheel cypherWheel;

    public bool paintingsSolved;

    public bool bookshelvesSolved;

    public bool safeSolved;

    public bool clockBellsSolved;

    public bool hour1;

    public bool hour2;

    public bool hour3;

    public bool pianoSolved;

    public bool closetLockSolved;

    public bool fireplaceSolved;

    public bool coatofArmsSolved;

    public bool pedestalSolved;

    public bool deskLockSolved;

    public bool cypherWheelSolved;

    public bool globeSolved;
    public bool tutorialRoomSolved;


    private List<string> pianoSolution;
    

    InventoryManager inventoryManager;

    InteractionsManager interactionsManager;

    VisionsManager visionsManager;

    UIManager uIManager;

    CameraSwitcher cameraSwitcher;
    
    // Start is called before the first frame update
    void Start()
    {
        paintingsSolved = false;
        bookshelvesSolved = false;
        safeSolved = false;
        clockBellsSolved = false;
        hour1 = false;
        hour2 = false;
        hour3 = false;
        pianoSolved = false;
        closetLockSolved = false;
        fireplaceSolved = false;
        coatofArmsSolved = false;
        pedestalSolved = false;
        deskLockSolved = false;
        cypherWheelSolved = false;
        globeSolved = false;
        tutorialRoomSolved = false;
        pianoSolution = new List<string>
        {
            "4g",
            "4g",
            "4g#",
            "4g",
            "5c",
            "5b",
            "4g",
            "4g",
            "4g#",
            "4g",
            "5d",
            "5c",
            "4g",
            "4g",
            "5g",
            "5e",
            "5c",
            "5b",
            "4g#",
            "5f",
            "5f",
            "5e",
            "5c#",
            "5d",
            "5c"
        };
        interactionsManager = gameObject.GetComponent<InteractionsManager>();
        inventoryManager = gameObject.GetComponent<InventoryManager>();
        visionsManager = gameObject.GetComponent<VisionsManager>();
        uIManager = gameObject.GetComponent<UIManager>();
        cameraSwitcher = gameObject.GetComponent<CameraSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!paintingsSolved){
            CheckPaintings();
        }
        if(!bookshelvesSolved){
            CheckBookshelfs();
        }
        if(!safeSolved){
            CheckSafeCode();
        }
        if(!clockBellsSolved){
            CheckBellClockSequence();
        }
        if(!hour1 || !hour2 || !hour3){
            CheckClockHours();
        }
        if(!pianoSolved){
            CheckPianoKeys();
        }
        if(!closetLockSolved){
            CheckClosetLock();
        }
        if(!fireplaceSolved){
            CheckFireplace();
        }
        if(!coatofArmsSolved){
            CheckCoatofArms();
        }
        if(!pedestalSolved){
            CheckPedestalBooks();
        }
        if(!deskLockSolved){
            CheckDeskLock();
        }
        if(!cypherWheelSolved){
            CheckCypherWheel();
        }
        if(!globeSolved){
            if(keyGlobe.activeSelf==true){
                globeSolved=true;
            }
        }
        if(!tutorialRoomSolved){
            if(keyTutorial.activeSelf==true){
                tutorialRoomSolved=true;
            }
        }

    }


    public void CheckPaintings(){
        //Debug.Log(paintingMozart.transform.parent.name);
        if(paintingMozart.transform.parent!=null && paintingBeethoven.transform.parent!=null && paintingRachmaninoff.transform.parent!=null && paintingBach.transform.parent!=null){
            if(paintingMozart.transform.parent.name == "posQuadro1" && paintingBeethoven.transform.parent.name == "posQuadro2" && paintingRachmaninoff.transform.parent.name == "posQuadro3" && paintingBach.transform.parent.name == "posQuadro4"){
                paintingsSolved = true;
                paintingMozart.transform.parent.parent.GetComponent<Animator>().SetTrigger("RightOrder");
                paintingBeethoven.transform.parent.parent.GetComponent<Animator>().SetTrigger("RightOrder");
                paintingRachmaninoff.transform.parent.parent.GetComponent<Animator>().SetTrigger("RightOrder");
                paintingBach.transform.parent.parent.GetComponent<Animator>().SetTrigger("RightOrder");
                paintingMozart.transform.parent.parent.GetComponent<AudioSource>().Play();
                paintingBeethoven.transform.parent.parent.GetComponent<AudioSource>().Play();
                paintingRachmaninoff.transform.parent.parent.GetComponent<AudioSource>().Play();
                paintingBach.transform.parent.parent.GetComponent<AudioSource>().Play();
            }
        }
        
    }

    public void CheckBookshelfs(){
        int[] shelf1 = Shelf1.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf2 = Shelf2.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf3 = Shelf3.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf4 = Shelf4.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf5 = Shelf5.GetComponent<Bookshelf>().CheckBookshelf();
        if(shelf1[0] == 12 && shelf1[1] == 4 && shelf2[0] == 2 && shelf2[1] == 14 && shelf3[0] == 11 && shelf3[1] == 5 && shelf4[0] == 6 && shelf4[1] == 10 && shelf5[0] == 13 && shelf5[1] == 3){
            bookshelvesSolved = true;
            bookshelfCompartment1.GetComponent<Animator>().SetTrigger("Open");
            bookshelfCompartment2.GetComponent<Animator>().SetTrigger("Open");
            bookshelfCompartment1.GetComponent<AudioSource>().Play();
            bookshelfCompartment2.GetComponent<AudioSource>().Play();
        }
    }


    public void CheckSafeCode(){
        if(safe.GetNeedsCheck()==true){
            if(safe.GetCode()=="1712"){
                safeSolved=true;
                safe.PlayAnimations(true);
                cameraSwitcher.ExitCurrentCamera();
                uIManager.ShowDialogue("Nice, I'm always sharp.");
                
            }
            else{
                safe.PlayAnimations(false);
                safe.ResetCode();
                safe.SetNeedsCheck();
            }
        }
    }

    public void CheckBellClockSequence(){
        if(clock.GetBellSequence() == "123"){
            clock.OpenDrawer();
            clockBellsSolved = true;
        }
    }

    public void CheckClockHours(){
        //11:45
        if(clock.minutes.transform.parent.eulerAngles.z > 194 && clock.minutes.transform.parent.eulerAngles.z < 196 && clock.hours.transform.parent.eulerAngles.z < 353 && clock.hours.transform.parent.eulerAngles.z > 352 && hour1 == false){
            hour1 = true;
            visionsManager.ShowImage("hour1");
        }
        //7:30
        if(clock.minutes.transform.parent.eulerAngles.z > 284 && clock.minutes.transform.parent.eulerAngles.z < 286 && clock.hours.transform.parent.eulerAngles.z < 196 && clock.hours.transform.parent.eulerAngles.z > 194 && hour2 == false && bookshelvesSolved==true){
            hour2 = true;
            visionsManager.ShowImage("hour2");
        }
        //3:15
        if (clock.minutes.transform.parent.eulerAngles.z > 13 && clock.minutes.transform.parent.eulerAngles.z < 15 && clock.minutes.transform.parent.eulerAngles.z < 16 && clock.hours.transform.parent.eulerAngles.z > 96 && clock.hours.transform.parent.eulerAngles.z < 98 && hour3 == false && hour1 == true  && hour2 == true){
            hour3 = true;
            visionsManager.ShowImage("hour3");
        }
    }

    public void CheckPianoKeys(){
        var pianoNotes = piano.GetPianoNotes();
        for(int i = 0;i<pianoNotes.Count;i++){
            if(pianoNotes[i]!=pianoSolution[i]){
                piano.ResetPianoNotes();
                break;
            }
        }
        if(pianoNotes.SequenceEqual(pianoSolution)){
            pianoSolved=true;
            piano.OpenDrawer();
        }
    }

    public void CheckClosetLock(){
        Debug.Log(locky.lock1.transform.eulerAngles.y);
        Debug.Log(locky.lock2.transform.eulerAngles.y);
        Debug.Log(locky.lock3.transform.eulerAngles.y);
        Debug.Log(locky.lock4.transform.eulerAngles.y);
        if(locky.lock1.transform.eulerAngles.y > 179 &&  locky.lock1.transform.eulerAngles.y < 181  && locky.lock2.transform.eulerAngles.y > 35 && locky.lock2.transform.eulerAngles.y < 37 && locky.lock3.transform.eulerAngles.y > 143 && locky.lock3.transform.eulerAngles.y < 145 && locky.lock4.transform.eulerAngles.y > 71 && locky.lock4.transform.eulerAngles.y < 73){
            closetLockSolved=true;
            cameraSwitcher.ExitCurrentCamera();
            locky.isUnlocked=true;
            locky.GetComponent<AudioSource>().clip=locky.unlock;
            locky.GetComponent<AudioSource>().Play();
            locky.gameObject.SetActive(false);
            locky2.SetActive(true);
        }
    }

    public void CheckDeskLock(){
        //7529
        // Debug.Log(deskLock.lock1.transform.eulerAngles.z);
        // Debug.Log(deskLock.lock2.transform.eulerAngles.z);
        // Debug.Log(deskLock.lock3.transform.eulerAngles.z);
        // Debug.Log(deskLock.lock4.transform.eulerAngles.z);
        if(deskLock.lock1.transform.eulerAngles.z > -1 &&  deskLock.lock1.transform.eulerAngles.z < 1  && deskLock.lock2.transform.eulerAngles.z > 251 && deskLock.lock2.transform.eulerAngles.z < 253 && deskLock.lock3.transform.eulerAngles.z > 179 && deskLock.lock3.transform.eulerAngles.z < 181 && deskLock.lock4.transform.eulerAngles.z > 107 && deskLock.lock4.transform.eulerAngles.z < 109){
            deskLockSolved=true;
            cameraSwitcher.ExitCurrentCamera();
            deskLock.isUnlocked=true;
            deskLock.GetComponent<AudioSource>().clip=locky.unlock;
            deskLock.GetComponent<AudioSource>().Play();
            deskLock.gameObject.SetActive(value: false);
            deskLock2.SetActive(true);
        }
    }

    public void CheckFireplace(){
        if(!fireplace.ornamentLeft.GetComponent<MeshRenderer>().material.name.Contains("invisible") && !fireplace.ornamentRight.GetComponent<MeshRenderer>().material.name.Contains("invisible")){
            fireplace.PlayAnimation();
            fireplaceSolved=true;
        }
    }

    public void CheckCoatofArms(){
        if(!coatofArms.bottomPart.GetComponent<MeshRenderer>().material.name.Contains("invisible")&&!coatofArms.topPart.GetComponent<MeshRenderer>().material.name.Contains("invisible")&&!coatofArms.pearl.GetComponent<MeshRenderer>().material.name.Contains("invisible")){
            coatofArms.PlayAnimation();
            uIManager.ShowDialogue("This is why the didn't find anything. I'm onto you now Emrick");
            coatofArmsSolved = true;
        }
    }
    
    public void CheckPedestalBooks(){
        if(pedestal.posbook7==3 && pedestal.posbook6==7 && pedestal.posbook5==1 && pedestal.posbook4==5 && pedestal.posbook3==2 && pedestal.posbook2==6 && pedestal.posbook1==4){
            pedestal.OpenCompartment();
            pedestalSolved = true;
            //cameraSwitcher.ExitCurrentCamera();
        }
    }

    public void CheckCypherWheel(){
        if(cypherWheel.wheelInside.transform.eulerAngles.z > 231 &&  cypherWheel.wheelInside.transform.eulerAngles.z < 233  && cypherWheel.wheelMid.transform.eulerAngles.z > 301 && cypherWheel.wheelMid.transform.eulerAngles.z < 303 && cypherWheel.wheelOutside.transform.eulerAngles.z > 16 && cypherWheel.wheelOutside.transform.eulerAngles.z < 18){
            cypherWheelSolved=true;
            cameraSwitcher.ExitCurrentCamera();
            cypherWheel.PlayAnimations(4);
            triggerEnd.GetComponent<BoxCollider>().enabled=true;
        }
    }

}
