using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    private Transform[] books;
    // Start is called before the first frame update
    void Start()
    {
        books = this.transform.GetComponentsInChildren<Transform>();
        books = books.Skip(1).Take(books.Length-1).ToArray();
    }

    // Update is called once per frame
    public int[] CheckBookshelf(){
        int leftBooks = 0;
        int rightBooks = 0;
        foreach(Transform t in books){
            if (t.GetComponent<Book>().left){
                leftBooks++;
            }
            else{
                rightBooks++;
            }
        }
        int[] result = new int[2];
        result[0] = leftBooks;
        result[1] = rightBooks;
        return result;
    }
}
