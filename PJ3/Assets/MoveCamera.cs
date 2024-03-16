using System.Collections;
using System.Collections.Generic;
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
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotateX -= mouseY;
        rotateY += mouseX;
        
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        orientation.rotation = Quaternion.Euler(0,rotateY,0);
    }
}
