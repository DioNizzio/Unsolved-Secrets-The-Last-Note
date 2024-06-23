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

    public Fireplace fireplace;

    public GameObject locky2;

    public GameObject bookshelfCompartment1;

    public GameObject bookshelfCompartment2;

    public CoatofArms coatofArms;

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
            }
        }
        
    }

    public void CheckBookshelfs(){
        int[] shelf1 = Shelf1.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf2 = Shelf2.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf3 = Shelf3.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf4 = Shelf4.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf5 = Shelf5.GetComponent<Bookshelf>().CheckBookshelf();
        if(shelf1[0] == 0 && shelf1[1] == 16 && shelf2[0] == 4 && shelf2[1] == 12 && shelf3[0] == 7 && shelf3[1] == 9 && shelf4[0] == 11 && shelf4[1] == 5 && shelf5[0] == 13 && shelf5[1] == 3){
            Debug.Log("Puzzle Solved");
            bookshelvesSolved = true;
            bookshelfCompartment1.GetComponent<Animator>().SetTrigger("Open");
            bookshelfCompartment2.GetComponent<Animator>().SetTrigger("Open");
        }
    }


    public void CheckSafeCode(){
        if(safe.GetNeedsCheck()==true){
            if(safe.GetCode()=="1712"){
                Debug.Log("Puzzle Solved!");
                safeSolved=true;
                safe.PlayAnimations(true);
                cameraSwitcher.ExitCurrentCamera();
                uIManager.ShowDialogue("Wow, I managed to crack the code, that's crazy let's goooooooo");
                
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
        //3:15
        if(clock.minutes.transform.parent.eulerAngles.z > 14 && clock.minutes.transform.parent.eulerAngles.z < 16 && clock.hours.transform.parent.eulerAngles.z > 96 && clock.hours.transform.parent.eulerAngles.z < 98 && hour1 == false){
            hour1 = true;
            visionsManager.ShowImage("hour1");
        }
        //7:30
        if(clock.minutes.transform.parent.eulerAngles.z == -75 && clock.hours.transform.parent.eulerAngles.z < -164 && clock.hours.transform.parent.eulerAngles.z > -166 && hour2 == false){
            hour2 = true;
            visionsManager.ShowImage("hour2");
        }
        //23:45
        if (clock.minutes.transform.parent.eulerAngles.z == -165 && clock.hours.transform.parent.eulerAngles.z < -7 && clock.hours.transform.parent.eulerAngles.z > -8 && hour3 == false){
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
        if(locky.lock1.transform.eulerAngles.y > -1 &&  locky.lock1.transform.eulerAngles.y < 1  && locky.lock2.transform.eulerAngles.y > 215 && locky.lock2.transform.eulerAngles.y < 217 && locky.lock3.transform.eulerAngles.y > 323 && locky.lock3.transform.eulerAngles.y < 325 && locky.lock4.transform.eulerAngles.y > 251 && locky.lock4.transform.eulerAngles.y < 253){
            closetLockSolved=true;
            cameraSwitcher.ExitCurrentCamera();
            locky.isUnlocked=true;
            locky.gameObject.SetActive(false);
            locky2.SetActive(true);
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
            coatofArmsSolved = true;
        }
    }
    

}
