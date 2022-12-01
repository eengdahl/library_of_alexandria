using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClutterCheckerScript : MonoBehaviour
{
    public int booksInArea;
    private void Start()
    {
        booksInArea = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Book")
        {
            booksInArea += 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Book")
        {
            booksInArea -= 1;
        }
    }
}
