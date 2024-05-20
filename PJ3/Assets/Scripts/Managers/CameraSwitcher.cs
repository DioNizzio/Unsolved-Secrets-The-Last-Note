using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public GameObject mainCamera;

    public GameObject safeCamera;

    public GameObject clockCamera;

    public GameObject pianoCamera;

    public GameObject lockCamera;

    public GameObject safe;

    public GameObject clock;

    public GameObject piano;

    public GameObject locky;
    private string cameraActivated;

    UIManager uIManager;

    PlayerandCameraHolders playerandCameraHolders;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GetComponent<UIManager>();
        playerandCameraHolders = gameObject.GetComponent<PlayerandCameraHolders>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCameras();
    }

    public void SwitchCameras(){
        if(safe.GetComponent<Safe>().cameraActive){
            cameraActivated = "safe";
        }
        else if(clock.GetComponent<Clock>().cameraActive){
            cameraActivated = "clock";
        }
        else if(piano.GetComponent<Piano>().cameraActive){
            cameraActivated = "piano";
        }
        else if(locky.GetComponent<Lock>().cameraActive){
            cameraActivated = "lock";
        }
        else{
            cameraActivated = "main";
        }
        if(cameraActivated.Contains("main")){
            mainCamera.SetActive(true);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            uIManager.HideUI(false);
            if(uIManager.notePad.activeSelf==true){
                uIManager.ChangeCursor("close");
            }
            else{
                uIManager.ChangeCursor("locked");
            }
        }
        else if(cameraActivated.Contains("safe")){    
            mainCamera.SetActive(false);
            safeCamera.SetActive(true);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideUI(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains("clock")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(true);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideUI(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains(value: "piano")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(true);
            lockCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideUI(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains(value: "lock")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(true);
            uIManager.ChangeCursor("close");
            uIManager.HideUI(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
    }

    public void ExitCurrentCamera(){
        playerandCameraHolders.PlayerCanMove(move: true);
        if(safeCamera.activeSelf==true){
            safe.GetComponent<Safe>().ExitCameraSafe();
        }
        else if(clockCamera.activeSelf==true){
            clock.GetComponent<Clock>().ExitCameraClock();
        }

        else if(pianoCamera.activeSelf==true){
            piano.GetComponent<Piano>().ExitCameraPiano();
        }

        else if(lockCamera.activeSelf==true){
            locky.GetComponent<Lock>().ExitCameraLock();
        }
    }

    public GameObject GetCurrentCamera(){
        if(mainCamera.activeSelf==true){
            return mainCamera;
        }
        else if(safeCamera.activeSelf==true){
            return safeCamera;
        }
        else if(clockCamera.activeSelf==true){
            return clockCamera;
        }
        else if(pianoCamera.activeSelf==true){
            return pianoCamera;
        }
        else if(lockCamera.activeSelf==true){
            return lockCamera;
        }
        return null;
    }
}
