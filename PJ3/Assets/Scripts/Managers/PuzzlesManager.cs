using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzlesManager : MonoBehaviour
{

    public GameObject paintingMozart;
    public GameObject paintingBeethoven;
    public GameObject paintingRachmaninoff;
    public GameObject paintingBach;

    public GameObject Shelf1;
    public GameObject Shelf2;
    public GameObject Shelf3;
    public GameObject Shelf4;
    private bool paintingsUnsolved;

    private bool bookshelvesUnsolved;

    InventoryManager inventoryManager;

    InteractionsManager interactionsManager;
    
    // Start is called before the first frame update
    void Start()
    {
        paintingsUnsolved = false;
        bookshelvesUnsolved = false;
        interactionsManager = gameObject.AddComponent<InteractionsManager>();
        inventoryManager = gameObject.AddComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!paintingsUnsolved){
            CheckPaintings();
        }
        if(!bookshelvesUnsolved){
            CheckBookshelfs();
        }
    }


    public void CheckPaintings(){
        //Debug.Log(paintingMozart.transform.parent.name);
        if(paintingMozart.transform.parent!=null && paintingBeethoven.transform.parent!=null && paintingRachmaninoff.transform.parent!=null && paintingBach.transform.parent!=null){
            if(paintingMozart.transform.parent.name == "posQuadro1" && paintingBeethoven.transform.parent.name == "posQuadro2" && paintingRachmaninoff.transform.parent.name == "posQuadro3" && paintingBach.transform.parent.name == "posQuadro4"){
                Debug.Log("Solved Puzzle");
                paintingsUnsolved = true;
                //play some animation after
            }
        }
        
    }

    public void CheckBookshelfs(){
        int[] shelf1 = Shelf1.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf2 = Shelf2.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf3 = Shelf3.GetComponent<Bookshelf>().CheckBookshelf();
        int[] shelf4 = Shelf4.GetComponent<Bookshelf>().CheckBookshelf();
        if(shelf1[0] == 0 && shelf1[1] == 16 && shelf2[0] == 4 && shelf2[1] == 12 && shelf3[0] == 7 && shelf3[1] == 9 && shelf4[0] == 11 && shelf4[1] == 5){
            Debug.Log("Puzzle Solved");
            bookshelvesUnsolved = true;
            //play some animation after
        }
    }
    

}
