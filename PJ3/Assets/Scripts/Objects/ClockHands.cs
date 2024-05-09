using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ClockHands : MonoBehaviour
{
    public void Rotate(int angle){
        if(transform.parent.name.Contains("minutes")){
            transform.parent.eulerAngles = new Vector3(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y,transform.parent.eulerAngles.z+90*angle);
        }
        else if(transform.parent.name.Contains("hours")){
            transform.parent.eulerAngles = new Vector3(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y,transform.parent.eulerAngles.z+7.5f*(-angle));
        }
    }
}