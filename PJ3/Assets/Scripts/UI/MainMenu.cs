using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject ExitPanel;
    public GameObject Options;
    public GameObject Main;

    public void PlayGame (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowQuitText (){
        ExitPanel.SetActive(true);
    }

    public void HideQuitText (){
        ExitPanel.SetActive(false);
    }

    public void QuitGame (){
        Debug.Log("Quit");
        Application.Quit();
    }
}
