using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registration : MonoBehaviour
{
    public List<GameObject> books;
    public float timer;
    private float spawnrate;
    public Rigidbody2D rb;
    InventoryPlayer inventoryPlayer;
    DeliverBooks deliverBooks;
    public GameObject[] slots;
    public int buffer;
    public GameObject bookSpawnPoint;
    GameObject kid;


    // Start is called before the first frame update
    void Start()
    {
        spawnrate = 1;
        deliverBooks = FindObjectOfType<DeliverBooks>();
        inventoryPlayer = FindObjectOfType<InventoryPlayer>();


    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        //If player holds left shift books are beeing registrated and put on the table
        if (collision.tag == "Registration" && Input.GetKey(KeyCode.LeftShift) && deliverBooks.booksOnTable >= 1)
        {
            timer += Time.deltaTime;

            if (timer > spawnrate)
            {
                Instantiate(books[UnityEngine.Random.Range(0, books.Count)], bookSpawnPoint.transform.position, Quaternion.identity);
                deliverBooks.AddBookToTable(-1);
                timer = 0;
            }
        }

        //Checking if player can drop book in reception
        if (collision.tag == "Deliver")
        {
            //Checking each slot in inventory and if white - deliver to table and remove from inventory
            foreach (GameObject slot in slots)
            {
                GameObject bookWhite;
                bookWhite = inventoryPlayer.FindChildWithTag(slot, "Book White");

                if (bookWhite != null && deliverBooks.tableFull == false)
                {
                    deliverBooks.AddBookToTable(1);
                    inventoryPlayer.ReturnBooksToReception("Book White", 1);
                }

            }

        }
    }


}



//if (collision.tag == "Deliver")
//{

//    //Checking if inventory is occupied and sending that many books to the table
//    //testing with all colors untill a undefined book is ingame 
//    for (int i = 0; i < 3; i++)
//    {
//        if (inventoryPlayer.isFull[i])
//        {
//            buffer++;
//        }
//        //Setting a max of 10 books at the table at once
//        if (deliverBooks.booksOnTable + buffer >= 10)
//        {

//            for (int k = deliverBooks.booksOnTable + buffer; k <= 10; k++)
//            {
//                deliverBooks.AddBookToTable(1);
//                inventoryPlayer.ReturnBooks("Book White");
//            }
//            buffer = 0;
//            return;
//        }
//        else if (i == 2 && buffer > 0)
//        {
//            for (int j = 0; j <= buffer; j++)
//            {
//                deliverBooks.AddBookToTable(1);
//                inventoryPlayer.ReturnBooks("Book White");

//            }
//            //inventoryPlayer.ReturnBooks("Book Green");
//            //inventoryPlayer.ReturnBooks("Book Red");
//            //inventoryPlayer.ReturnBooks("Book Blue");
//            buffer = 0;
//        }
//    }

//}