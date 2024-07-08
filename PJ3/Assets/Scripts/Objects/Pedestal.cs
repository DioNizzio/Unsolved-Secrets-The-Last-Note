using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pedestal : MonoBehaviour, IInteractable
{
    int first = 0;
    int second = 0;
    public bool cameraActive;
    public GameObject book1;
    public GameObject book2;
    public GameObject book3;
    public GameObject book4;
    public GameObject book5;
    public GameObject book6;
    public GameObject book7;
    public GameObject compartment;

    public int posbook1=1;
    public int posbook2=2;
    public int posbook3=3;
    public int posbook4=4;
    public int posbook5=5;
    public int posbook6=6;
    public int posbook7=7;
    public float waitTime=0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if(first!=0 && second!=0){
            waitTime += Time.deltaTime;
            if(waitTime > 1.0f){
                SwitchBooks();
                waitTime = 0.0f;
            }
        }
        
    }

    public bool Interact(GameObject currentObj)
    {
        cameraActive = true;
        GetComponent<BoxCollider>().enabled = false;
        return false;
    }

    public void ExitCameraPedestal(){
        cameraActive = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void UpNumber(string number){
        Debug.Log("number: " + number);
        if(first == 0){
            first = int.Parse(number.Split("_")[1]);
            Debug.Log("first: " + first);
            CheckBook(first).GetComponent<Animator>().SetTrigger("UpDown" + CheckPosBook(first));
        } 
        else{
            second = int.Parse(number.Split("_")[1]);
            Debug.Log("second: " + second);
            if(second == first){
                CheckBook(second).GetComponent<Animator>().SetTrigger("UpDown" + CheckPosBook(second));
                first=0;
                second=0;
            }
            else{
                CheckBook(second).GetComponent<Animator>().SetTrigger("UpDown" + CheckPosBook(second));
               
                //SwitchBooks();
            }
        }
    }

    public GameObject CheckBook(int bookNumber){
        if(bookNumber == 1){
            return book1;
        }
        else if(bookNumber == 2){
            return book2;
        }
        else if(bookNumber == 3){
            return book3;
        }
        else if(bookNumber == 4){
            return book4;
        }
        else if(bookNumber == 5){
            return book5;
        }
        else if(bookNumber == 6){
            return book6;
        }
        else if(bookNumber == 7){
            return book7;
        }else{
            return null;
        }
        
    }

    public int CheckPosBook(int bookNumber){
        if(bookNumber == 1){
            Debug.Log("posbook1: " + posbook1);
            return posbook1;
        }
        else if(bookNumber == 2){
            Debug.Log("posbook2: " + posbook2);
            return posbook2;
        }
        else if(bookNumber == 3){
            Debug.Log("posbook3: " + posbook3);
            return posbook3;
        }
        else if(bookNumber == 4){
            return posbook4;
        }
        else if(bookNumber == 5){
            return posbook5;
        }
        else if(bookNumber == 6){
            return posbook6;
        }
        else if(bookNumber == 7){
            return posbook7;
        }else{
            return 0;
        }
    }

    public void SwitchBooks(){
        CheckBook(first).GetComponent<Animator>().SetTrigger(CheckPosBook(first)+"to"+CheckPosBook(second));
        CheckBook(second).GetComponent<Animator>().SetTrigger(CheckPosBook(second)+"to"+CheckPosBook(bookNumber: first));
        UpdateBoookPos();
    }

    public void UpdateBoookPos(){
        Debug.Log("asserting positions: " + first + ";" + second);
        int aux = 0;
        int a = CheckPosBook(first);
        int b = CheckPosBook(second);
        if(CheckPosBook(first) == posbook1){
            posbook1=b;
            aux=1;
        }
        else if(CheckPosBook(first) == posbook2){
            posbook2=b;
            aux=2;
        }
        else if(CheckPosBook(first) == posbook3){
            posbook3=b;
            aux=3;
        }
        else if(CheckPosBook(first) == posbook7){
            posbook7=b;
            aux=7;
        }
        else if(CheckPosBook(first) == posbook4){
            posbook4=b;
            aux=4;
        }
        else if(CheckPosBook(first) == posbook5){
            posbook5=b;
            aux=5;
        }
        else if(CheckPosBook(first) == posbook6){
            posbook6=b;
            aux=6;
        }
        if(CheckPosBook(second) == posbook1 && aux !=1){
            posbook1=a;
        }
        else if(CheckPosBook(second) == posbook2 && aux !=2){
            posbook2=a;
        }
        else if(CheckPosBook(second) == posbook3 && aux !=3){
            posbook3=a;
        }
        else if(CheckPosBook(second) == posbook7 && aux !=7){
            posbook7=a;
        }
        else if(CheckPosBook(second) == posbook4 && aux !=4){
            posbook4=a;
        }
        else if(CheckPosBook(second) == posbook5 && aux !=5){
            posbook5=a;
        }
        else if(CheckPosBook(second) == posbook6 && aux !=6){
            posbook6=a;
        }
        second = 0;
        first = 0;
    }

    public void OpenCompartment(){
        compartment.GetComponent<Animator>().SetTrigger("Open");
        compartment.GetComponent<AudioSource>().Play();
    }

}
