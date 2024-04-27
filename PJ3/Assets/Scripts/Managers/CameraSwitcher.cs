using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public GameObject mainCamera;

    public GameObject safeCamera;

    public GameObject safe;
    private bool mainActivated;

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
        mainActivated = !safe.GetComponent<Safe>().cameraActive;
        if(mainActivated == true){
            mainCamera.SetActive(true);
            safeCamera.SetActive(false);
            uIManager.HideUI(false);
            if(uIManager.notePad.activeSelf==true){
                uIManager.ChangeCursor("close");
            }
            else{
                uIManager.ChangeCursor("locked");
            }
        }
        else if(mainActivated == false){    
            mainCamera.SetActive(false);
            safeCamera.SetActive(true);
            uIManager.ChangeCursor("close");
            uIManager.HideUI(true);
        }
    }

    public GameObject GetCurrentCamera(){
        if(mainCamera.activeSelf==true){
            return mainCamera;
        }
        else if(safeCamera.activeSelf==true){
            return safeCamera;
        }
        return null;
    }
}
