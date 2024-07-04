using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using UnityEditor.Timeline;
using UnityEngine;

public class HelpsManager : MonoBehaviour
{

    private float globalTime = 0.0f;

    private Dictionary<string, float> timeList = new();

    private Dictionary<string, bool> helpedList = new();

    PuzzlesManager puzzlesManager;

    public NotePad notePad;


    // public Sprite books2;

    // public Sprite cypherWheel;

    // public Sprite desk;

    // public Sprite closet;

    // public Sprite tutorialRoom;

    // Start is called before the first frame update
    void Start()
    {
        puzzlesManager = GetComponent<PuzzlesManager>();
        timeList.Add("paintings", 0);
        helpedList.Add("paintings", false);
        timeList.Add("safe", 0);
        helpedList.Add("safe", false);
        timeList.Add("books1", 0);
        helpedList.Add("books1", false);
        timeList.Add(key: "piano", 0);
        helpedList.Add("piano", false);
        timeList.Add("clockBells", 0);
        helpedList.Add("clockBells", false);
        timeList.Add("fireplace", 0);
        helpedList.Add("fireplace", false);
        timeList.Add("globe", 0);
        helpedList.Add("globe", false);
        timeList.Add(key: "coatOfArms", 0);
        helpedList.Add("coatOfArms", false);
        timeList.Add(key: "books2", 0);
        helpedList.Add("books2", false);
        timeList.Add(key: "cypherWheel", 0);
        helpedList.Add("cypherWheel", false);
        timeList.Add(key: "desk", 0);
        helpedList.Add("desk", false);
        timeList.Add(key: "closet", 0);
        helpedList.Add("closet", false);
        timeList.Add(key: "tutorialRoom", 0);
        helpedList.Add("tutorialRoom", false);
        globalTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        globalTime += Time.deltaTime;
        if(helpedList["tutorialRoom"]==false){
            timeList["tutorialRoom"] += Time.deltaTime;
        }
        if(puzzlesManager.bookshelvesSolved==false && helpedList["books1"]==false){
            timeList["books1"] += Time.deltaTime;
        }
        if(puzzlesManager.paintingsSolved==false && helpedList["paintings"]==false){
            timeList["paintings"] += Time.deltaTime;
        }
        if(puzzlesManager.safeSolved==false && puzzlesManager.fireplaceSolved==true && helpedList["safe"]==false){
            timeList["safe"] += Time.deltaTime;
        }
        if(puzzlesManager.pedestalSolved == false && puzzlesManager.coatofArmsSolved==true && helpedList["books2"]==false){
            timeList["books2"] += Time.deltaTime;
        }
        if(puzzlesManager.deskLockSolved == false && puzzlesManager.coatofArmsSolved==true && helpedList["desk"]==false){
            timeList["desk"] += Time.deltaTime;
        }
        if(puzzlesManager.closetLockSolved == false && puzzlesManager.deskLockSolved==true && helpedList["closet"]==false){
            timeList["closet"] += Time.deltaTime;
        }
        if(puzzlesManager.cypherWheelSolved == false && puzzlesManager.closetLockSolved==true && helpedList["cypherWheel"]==false){
            timeList["cypherWheel"] += Time.deltaTime;
        }
        CheckForHelp();
    }

    public void CheckForHelp(){
        if(globalTime>120f && timeList.Values.Max()>300f){
            //Ui show help available;
        }
    }


    public void AskForHelp(){
        if(globalTime>1f && timeList.Values.Max()>3f){
            helpedList[timeList.FirstOrDefault(x => x.Value == timeList.Values.Max()).Key] = true;
            timeList[timeList.FirstOrDefault(x => x.Value == timeList.Values.Max()).Key] = 0.0f;
            globalTime = 0.0f;
            notePad.AddNotepadWritings(timeList.FirstOrDefault(x => x.Value == timeList.Values.Max()).Key);
            //Ui Show Notepad updated;
        }
    }
}
