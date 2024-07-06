using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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

    // Update is called once per frame
    public bool Interact(GameObject currentObj)
    {
        Debug.Log("Exit Pause");

        uIManager.HidePause();
        playerandCamera.PlayerCanMove(true);
        return false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Exit Pause");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(message: "Other Thing");
    }
}
