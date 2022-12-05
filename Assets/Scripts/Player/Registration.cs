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
    GameObject bookWhite;


    // Start is called before the first frame update
    void Start()
    {
        spawnrate = 5;
        deliverBooks = FindObjectOfType<DeliverBooks>();
        inventoryPlayer = FindObjectOfType<InventoryPlayer>();

    }
    private void Update()
    { 
        
        if(deliverBooks.booksOnTable >= 1)
        {
            timer += Time.deltaTime;

            if (timer > spawnrate)
            {
                Instantiate(books[UnityEngine.Random.Range(0, books.Count)], bookSpawnPoint.transform.position, Quaternion.identity);
                deliverBooks.AddBookToTable(-1);
                timer = 0;
            }
        }
        //timer += Time.deltaTime;

       
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //If player holds left shift books are beeing registrated and put on the table
        //if (collision.tag == "Registration" && Input.GetKey(KeyCode.LeftShift) && deliverBooks.booksOnTable >= 1)
        //{
        //    timer += Time.deltaTime;

        //    if (timer > spawnrate)
        //    {
        //        Instantiate(books[UnityEngine.Random.Range(0, books.Count)], bookSpawnPoint.transform.position, Quaternion.identity);
        //        deliverBooks.AddBookToTable(-1);
        //        timer = 0;
        //    }
        //}

        //Checking if player can drop book in reception
        if (collision.tag == "Deliver")
        {
            //Checking each slot in inventory and if white - deliver to table and remove from inventory
            foreach (GameObject slot in slots)
            {
                
                bookWhite = inventoryPlayer.FindChildWithTag(slot, "Book White");

                if (bookWhite != null && deliverBooks.tableFull == false)
                {
                    deliverBooks.AddBookToTable(1);
                    inventoryPlayer.ReturnBooksToReception("Book White", 1);

                    //Why this break is needed is beyond me 
                break;
                }
                    bookWhite = null;

            }

        }
    }


}

