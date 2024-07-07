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

    public GameObject pedestalCamera;

    public GameObject deskLockCamera;

    public GameObject cypherWheelCamera;

    public GameObject musicBoxCamera;

    public GameObject safe;

    public GameObject clock;

    public GameObject piano;

    public GameObject locky;

    public GameObject deskLock;

    public GameObject pedestal;

    public GameObject cypherWheel;

    public GameObject musicBox;

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
        else if(pedestal.GetComponent<Pedestal>().cameraActive){
            cameraActivated = "pedestal";
        }
        else if(deskLock.GetComponent<Lock>().cameraActive){
            cameraActivated = "deskLock";
        }
        else if(cypherWheel.GetComponent<CypherWheel>().cameraActive){
            cameraActivated = "cypherWheel";
        }
        else if(musicBox.GetComponent<MusicBox>().cameraActive){
            cameraActivated = "musicBox";
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
            pedestalCamera.SetActive(false);
            deskLockCamera.SetActive(false);
            cypherWheelCamera.SetActive(false);
            musicBoxCamera.SetActive(false);
            uIManager.HideActiveSlotsandFixesSlots(false);
            
            if(uIManager.notePad.activeSelf==true){
                uIManager.ChangeCursor("close");
                uIManager.HideCrossair(true);
            }
            else if(uIManager.PauseMenu.activeSelf==true){
                uIManager.ChangeCursor("close");
                uIManager.HideCrossair(true);
            }
            else if(uIManager.Options.activeSelf==true){
                uIManager.ChangeCursor("close");
                uIManager.HideCrossair(true);
            }
            else{
                uIManager.ChangeCursor("locked");
                uIManager.HideCrossair(false);
            }
        }
        else if(cameraActivated.Contains("safe")){    
            mainCamera.SetActive(false);
            safeCamera.SetActive(true);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            pedestalCamera.SetActive(false);
            deskLockCamera.SetActive(false);
            cypherWheelCamera.SetActive(false);
            musicBoxCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideActiveSlotsandFixesSlots(true);
            uIManager.HideCrossair(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains("clock")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(true);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            pedestalCamera.SetActive(false);
            deskLockCamera.SetActive(false);
            cypherWheelCamera.SetActive(false);
            musicBoxCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideActiveSlotsandFixesSlots(true);
            uIManager.HideCrossair(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains(value: "piano")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(true);
            lockCamera.SetActive(false);
            pedestalCamera.SetActive(false);
            deskLockCamera.SetActive(false);
            cypherWheelCamera.SetActive(false);
            musicBoxCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideActiveSlotsandFixesSlots(true);
            uIManager.HideCrossair(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains(value: "lock")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(true);
            pedestalCamera.SetActive(false);
            deskLockCamera.SetActive(false);
            cypherWheelCamera.SetActive(false);
            musicBoxCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideActiveSlotsandFixesSlots(true);
            uIManager.HideCrossair(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains(value: "pedestal")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            pedestalCamera.SetActive(true);
            deskLockCamera.SetActive(false);
            cypherWheelCamera.SetActive(false);
            musicBoxCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideActiveSlotsandFixesSlots(true);
            uIManager.HideCrossair(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains(value: "deskLock")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            pedestalCamera.SetActive(false);
            deskLockCamera.SetActive(true);
            cypherWheelCamera.SetActive(false);
            musicBoxCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideActiveSlotsandFixesSlots(true);
            uIManager.HideCrossair(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains(value: "cypherWheel")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            pedestalCamera.SetActive(false);
            deskLockCamera.SetActive(false);
            cypherWheelCamera.SetActive(true);
            musicBoxCamera.SetActive(false);
            uIManager.ChangeCursor("close");
            uIManager.HideActiveSlotsandFixesSlots(true);
            uIManager.HideCrossair(true);
            playerandCameraHolders.PlayerCanMove(false);
        }
        else if(cameraActivated.Contains(value: "musicBox")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
            pianoCamera.SetActive(false);
            lockCamera.SetActive(false);
            pedestalCamera.SetActive(false);
            deskLockCamera.SetActive(false);
            cypherWheelCamera.SetActive(false);
            musicBoxCamera.SetActive(true);
            uIManager.ChangeCursor("close");
            uIManager.HideActiveSlotsandFixesSlots(true);
            uIManager.HideCrossair(hide: true);
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
        else if(pedestalCamera.activeSelf==true){
            pedestal.GetComponent<Pedestal>().ExitCameraPedestal();
        }
        else if(deskLockCamera.activeSelf==true){
            deskLock.GetComponent<Lock>().ExitCameraLock();
        }
        else if(cypherWheelCamera.activeSelf==true){
            cypherWheel.GetComponent<CypherWheel>().ExitCameraCypher();
        }
        else if(musicBox.activeSelf==true){
            musicBox.GetComponent<MusicBox>().ExitCameraMusicBox();
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
        else if(pedestalCamera.activeSelf==true){
            return pedestalCamera;
        }
        else if(deskLockCamera.activeSelf==true){
            return deskLockCamera;
        }
        else if(cypherWheelCamera.activeSelf==true){
            return cypherWheelCamera;
        }
        else if(musicBoxCamera.activeSelf==true){
            return musicBoxCamera;
        }
        return null;
    }
}
