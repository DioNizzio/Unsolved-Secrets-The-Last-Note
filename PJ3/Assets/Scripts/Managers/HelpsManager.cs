using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using UnityEngine;

public class HelpsManager : MonoBehaviour
{

    private float globalTime = 0.0f;

    private Dictionary<string, float> timeList = new();

    private Dictionary<string, bool> helpedList = new();

    PuzzlesManager puzzlesManager;

    public GameObject helpAvailable;

    public GameObject notepadUpdated;

    public NotePad notePad;

    private bool played;

    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        puzzlesManager = GetComponent<PuzzlesManager>();
        soundManager =GetComponent<SoundManager>();
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
        timeList.Add(key: "tutorialRoom", 0.1f);
        helpedList.Add("tutorialRoom", false);
        notePad.helps.Add("books1", notePad.books1);
        notePad.helps.Add("paintings", notePad.paintings);
        notePad.helps.Add("clockBells", notePad.clockBells);
        notePad.helps.Add("books2", notePad.books2);
        notePad.helps.Add("safe", notePad.safe);
        notePad.helps.Add("fireplace", notePad.fireplace);
        notePad.helps.Add("tutorialRoom", notePad.tutorialRoom);
        notePad.helps.Add("piano", notePad.piano);
        notePad.helps.Add("coatOfArms", notePad.coatOfArms);
        notePad.helps.Add("desk", notePad.desk);
        notePad.helps.Add("closet", notePad.closet);
        notePad.helps.Add("cypherWheel", notePad.cypherWheel);
        notePad.helps.Add("globe", notePad.globe);
        globalTime = Time.deltaTime;
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        globalTime += Time.deltaTime;
        
        if(puzzlesManager.tutorialRoomSolved==false && helpedList["tutorialRoom"]==false){
            timeList["tutorialRoom"] += Time.deltaTime;
        }else{
            timeList["tutorialRoom"] = 0.0f;
        }
        if(puzzlesManager.tutorialRoomSolved==true && puzzlesManager.bookshelvesSolved==false && helpedList["books1"]==false){
            timeList["books1"] += Time.deltaTime;
        }else{
            timeList["books1"] = 0.0f;
        }
        if(puzzlesManager.tutorialRoomSolved==true && puzzlesManager.pianoSolved==false && helpedList["piano"]==false){
            timeList["piano"] += Time.deltaTime;
        }else{
            timeList["piano"] = 0.0f;
        }
        if(puzzlesManager.tutorialRoomSolved==true && puzzlesManager.paintingsSolved==false && helpedList["paintings"]==false){
            timeList["paintings"] += Time.deltaTime;
        }else{
            timeList["paintings"] = 0.0f;
        }
        if(puzzlesManager.tutorialRoomSolved==true && puzzlesManager.clockBellsSolved==false && helpedList["clockBells"]==false){
            timeList["clockBells"] += Time.deltaTime;
        }else{
            timeList["clockBells"] = 0.0f;
        }
        if(puzzlesManager.globeSolved==false && puzzlesManager.clockBellsSolved==true && helpedList["globe"]==false){
            timeList["globe"] += Time.deltaTime;
        }else{
            timeList["globe"] = 0.0f;
        }
        if(puzzlesManager.fireplaceSolved==false && puzzlesManager.paintingsSolved==true && puzzlesManager.bookshelvesSolved==true && helpedList["fireplace"]==false){
            timeList["fireplace"] += Time.deltaTime;
        }else{
            timeList["fireplace"] = 0.0f;
        }
        if(puzzlesManager.safeSolved==false && puzzlesManager.fireplaceSolved==true && helpedList["safe"]==false){
            timeList["safe"] += Time.deltaTime;
        }else{
            timeList["safe"] = 0.0f;
        }
        if(puzzlesManager.coatofArmsSolved==false && puzzlesManager.safeSolved==true && puzzlesManager.pianoSolved==true && puzzlesManager.globeSolved==true && helpedList["coatOfArms"]==false){
            timeList["coatOfArms"] += Time.deltaTime;
        }else{
            timeList["coatOfArms"] = 0.0f;
        }
        if(puzzlesManager.pedestalSolved == false && puzzlesManager.coatofArmsSolved==true && helpedList["books2"]==false){
            timeList["books2"] += Time.deltaTime;
        }else{
            timeList["books2"] = 0.0f;
        }
        if(puzzlesManager.deskLockSolved == false && puzzlesManager.coatofArmsSolved==true && helpedList["desk"]==false){
            timeList["desk"] += Time.deltaTime;
        }else{
            timeList["desk"] = 0.0f;
        }
        if(puzzlesManager.closetLockSolved == false && puzzlesManager.deskLockSolved==true && helpedList["closet"]==false){
            timeList["closet"] += Time.deltaTime;
        }else{
            timeList["closet"] = 0.0f;
        }
        if(puzzlesManager.cypherWheelSolved == false && puzzlesManager.closetLockSolved==true && helpedList["cypherWheel"]==false){
            timeList["cypherWheel"] += Time.deltaTime;
        }else{
            timeList["cypherWheel"] = 0.0f;
        }
        CheckForHelp();
    }

    public void CheckForHelp(){
        if(globalTime>120f && timeList.Values.Max()>300f && !played){
            helpAvailable.SetActive(true);
            helpAvailable.GetComponent<Animator>().SetTrigger("Help");
            played=true;
        }else if(timeList.Values.Max()>300f && played && globalTime%120==0 && globalTime/120>1){
            played = false;
        }
    }


    public void AskForHelp(){
        if(globalTime>120f && timeList.Values.Max()>300f){
            var key = timeList.FirstOrDefault(x => x.Value == timeList.Values.Max()).Key;
            helpedList[key] = true;
            timeList[key] = 0.0f;
            globalTime = 0.0f;
            notePad.AddNotepadWritings(key);
            notepadUpdated.GetComponent<Animator>().SetTrigger("Help");
            soundManager.Play("notepad");
        }
    }

    public void HideHelpAvailable(){
        helpAvailable.SetActive(false);
    }
}
