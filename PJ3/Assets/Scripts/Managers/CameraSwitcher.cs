using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public GameObject mainCamera;

    public GameObject safeCamera;

    public GameObject clockCamera;

    public GameObject safe;

    public GameObject clock;
    private string cameraActivated;

    UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GetComponent<UIManager>();
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
        else{
            cameraActivated = "main";
        }
        if(cameraActivated.Contains("main")){
            mainCamera.SetActive(true);
            safeCamera.SetActive(false);
            clockCamera.SetActive(false);
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
            uIManager.ChangeCursor("close");
            uIManager.HideUI(true);
        }
        else if(cameraActivated.Contains("clock")){
            mainCamera.SetActive(false);
            safeCamera.SetActive(false);
            clockCamera.SetActive(true);
            uIManager.ChangeCursor("close");
            uIManager.HideUI(true);
        }
    }

    public void ExitCurrentCamera(){
        if(safeCamera.activeSelf==true){
            safe.GetComponent<Safe>().ExitCameraSafe();
        }
        else if(clockCamera.activeSelf==true){
            clock.GetComponent<Clock>().ExitCameraClock();
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
        return null;
    }
}
