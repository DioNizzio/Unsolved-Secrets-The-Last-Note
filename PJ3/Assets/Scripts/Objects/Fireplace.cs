using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bit;

    public GameObject ornamentLeft;

    public GameObject ornamentRight;

    public void PlayAnimation(){
        bit.GetComponent<Animator>().SetTrigger("Open");
    }


}
