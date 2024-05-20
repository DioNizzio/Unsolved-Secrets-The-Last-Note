using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent!=null){
            if(transform.parent.name.Contains("pos")){
                gameObject.SetActive(true);
                transform.position = new Vector3(transform.parent.position.x,transform.parent.position.y,transform.parent.position.z-0.1f);
                transform.eulerAngles = new Vector3(0,180,0);
            }
        }   
    }
}
