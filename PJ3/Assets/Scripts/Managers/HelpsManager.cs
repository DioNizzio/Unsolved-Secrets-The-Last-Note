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
        timeList.Add(key: "brasao", 0);
        helpedList.Add("brasao", false);
        globalTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        globalTime += Time.deltaTime;
        if(puzzlesManager.bookshelvesSolved==false && helpedList["books1"]==false){
            timeList["books1"] += Time.deltaTime;
        }
        if(puzzlesManager.paintingsSolved==false && helpedList["paintings"]==false){
            timeList["paintings"] += Time.deltaTime;
        }
        if(puzzlesManager.safeSolved==false && puzzlesManager.paintingsSolved==true && helpedList["safe"]==false){
            timeList["safe"] += Time.deltaTime;
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
