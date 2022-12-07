using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registration : MonoBehaviour
{

    public List<GameObject> books;
    public float timer;
    public float spawnrate;
    public Rigidbody2D rb;
    InventoryPlayer inventoryPlayer;
    DeliverBooks deliverBooks;
    public GameObject[] slots;
    public int buffer;
    public GameObject bookSpawnPoint;
    GameObject bookWhite;
    public int amountRegistered;
    public List <GameObject> registeredBooks;
    public SwayBooksList swayBookScript;
    AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        swayBookScript = FindObjectOfType<SwayBooksList>();
        amountRegistered = 0;
        spawnrate = 5;
        deliverBooks = FindObjectOfType<DeliverBooks>();
        inventoryPlayer = FindObjectOfType<InventoryPlayer>();
        aS = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if(swayBookScript.toMany == false)
        {

        if (deliverBooks.booksOnTable >= 1)
        {
            timer += Time.deltaTime;

            if (timer > spawnrate)
            {
                Vector3 thisSpawnPoint = bookSpawnPoint.transform.position + new Vector3(0, amountRegistered / 10f);
                
                GameObject book = Instantiate(books[UnityEngine.Random.Range(0, books.Count)], thisSpawnPoint, Quaternion.identity);
                registeredBooks.Add(book);
                //registeredBooks[registeredBooks.IndexOf(book)].GetComponent<Collider2D>().enabled = false;

                amountRegistered += 1;
                deliverBooks.AddBookToTable(-1);
                timer = 0;
            }
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
                    aS.Play();

                    //Why this break is needed is beyond me 
                break;
                }
                    bookWhite = null;

            }

        }
    }


}

