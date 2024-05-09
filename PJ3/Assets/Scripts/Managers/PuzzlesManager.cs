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


    public bool paintingsSolved;

    public bool bookshelvesSolved;

    public bool safeSolved;

    public bool clockBellsSolved;

    public bool hour1;

    public bool hour2;

    public bool hour3;

    public bool pianoSolved;

    private List<string> pianoSolution;
    

    InventoryManager inventoryManager;

    InteractionsManager interactionsManager;
    
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
        interactionsManager = gameObject.AddComponent<InteractionsManager>();
        inventoryManager = gameObject.AddComponent<InventoryManager>();
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
    }


    public void CheckPaintings(){
        //Debug.Log(paintingMozart.transform.parent.name);
        if(paintingMozart.transform.parent!=null && paintingBeethoven.transform.parent!=null && paintingRachmaninoff.transform.parent!=null && paintingBach.transform.parent!=null){
            if(paintingMozart.transform.parent.name == "posQuadro1" && paintingBeethoven.transform.parent.name == "posQuadro2" && paintingRachmaninoff.transform.parent.name == "posQuadro3" && paintingBach.transform.parent.name == "posQuadro4"){
                Debug.Log("Solved Puzzle");
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
            //play some animation after
        }
    }


    public void CheckSafeCode(){
        if(safe.GetNeedsCheck()==true){
            if(safe.GetCode()=="1712"){
                Debug.Log("Puzzle Solved!");
                safeSolved=true;
                safe.PlayAnimations(true);
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
        if(clock.minutes.transform.rotation.z == 15 && clock.hours.transform.rotation.z == 97.5 && hour1 == false){
            hour1 = true;
            Debug.Log("Hour1");
            //play animation
        }
        //7:30
        if(clock.minutes.transform.rotation.z == -75 && clock.hours.transform.rotation.z == -165 && hour2 == false){
            hour2 = true;
            Debug.Log("Hour2");
            // play animation
        }
        //23:45
        if (clock.minutes.transform.rotation.z == -165 && clock.hours.transform.rotation.z == -7.5 && hour3 == false){
            hour3 = true;
            Debug.Log("Hour3");
            //play animation
        }
    }

    public void CheckPianoKeys(){
        var pianoNotes = piano.GetPianoNotes();
        for(int i = 0;i<pianoNotes.Count;i++){
            //Debug.Log(pianoNotes[i].ToString());
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
    

}
