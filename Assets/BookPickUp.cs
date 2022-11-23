using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPickUp : MonoBehaviour
{
    [SerializeField]
    int maxNumberOfBooks;
    public int booksInArms;
    public int whiteBooksInHands;
    public int redBooksInHands;
    public int blueBooksInHands;
    public int greenBooksInHands;
    private void Awake()
    {
        booksInArms = 0;
        whiteBooksInHands = 0;
        redBooksInHands = 0;
        blueBooksInHands = 0;
        greenBooksInHands = 0;


}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //White Books Pick UP and leave
        //Pick UP
        if (collision.tag == "Book White" && booksInArms < maxNumberOfBooks)
        {
            booksInArms += 1;
            whiteBooksInHands += 1;
            Destroy(collision.gameObject);
        }
        //Leave
        if (collision.tag == "Bookshelf White" && whiteBooksInHands > 0)
        {
            booksInArms -= whiteBooksInHands;
            whiteBooksInHands -= whiteBooksInHands;
        }
        //Red Books Pick Up and leave
        //Pick UP
        if (collision.tag == "Book Red" && booksInArms < maxNumberOfBooks)
        {
            booksInArms += 1;
            redBooksInHands += 1;
            Destroy(collision.gameObject);
        }

        //Leave
        if (collision.tag == "Bookshelf Red" && redBooksInHands > 0)
        {
            booksInArms -= redBooksInHands;
            redBooksInHands -= redBooksInHands;
        }

        //Blue Books Pick Up and leave 
        //Pick up
        if (collision.tag == "Book Blue" && booksInArms < maxNumberOfBooks)
        {
            booksInArms += 1;
            blueBooksInHands += 1;
            Destroy(collision.gameObject);
        }
        //Leave
        if (collision.tag == "Bookshelf Blue" && blueBooksInHands > 0)
        {
            booksInArms -= blueBooksInHands;
            blueBooksInHands -= blueBooksInHands;
        }
        //Green Books Pick Up And Leave
        //Pick up
        if (collision.tag == "Book Green" && booksInArms < maxNumberOfBooks)
        {
            booksInArms += 1;
            greenBooksInHands += 1;
            Destroy(collision.gameObject);
        }
        //Leave
        if (collision.tag == "Bookshelf Green" && greenBooksInHands > 0)
        {
            booksInArms -= greenBooksInHands;
            greenBooksInHands -= greenBooksInHands;
        }
    }
}
