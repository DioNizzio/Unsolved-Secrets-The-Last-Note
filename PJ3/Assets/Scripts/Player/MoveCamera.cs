using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float sensX;

    public float sensY;

    public Transform orientation;

    float rotateX = 0;

    float rotateY = 0;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = true;
        //Cursor.SetCursor(Texture2D.blackTexture, new Vector2(100,100), CursorMode.ForceSoftware);
    }
    // Update is called once per frame
    public void CameraRotation(float x, float y)
    {
        float mouseX = x * Time.deltaTime * sensX;
        float mouseY = y * Time.deltaTime * sensY;

        rotateX -= mouseY;
        rotateY += mouseX;
        
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        orientation.rotation = Quaternion.Euler(0,rotateY,0);
    }
}
