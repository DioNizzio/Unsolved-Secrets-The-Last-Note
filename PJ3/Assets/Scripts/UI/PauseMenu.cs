using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class PauseMenu : MonoBehaviour, IInteractable
{
    public GameObject Managers;

    private UIManager uIManager;


    private PlayerandCameraHolders playerandCamera;

    // Start is called before the first frame update

    void Start()
    {
        uIManager = Managers.GetComponent<UIManager>();
        playerandCamera = Managers.GetComponent<PlayerandCameraHolders>();
    }

    void Update(){
    }

    public void ExitPause(){
        Debug.Log("Exit Pause");

        uIManager.HidePause();
        playerandCamera.PlayerCanMove(true);
    }

    public void ExitGame(){
        Debug.Log("Exit Game");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public bool Interact(GameObject currentObj)
    {
        Debug.Log("AIIIII");
        return false;
    }
}
