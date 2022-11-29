using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registration : MonoBehaviour
{
    public List<GameObject> books;
    public float timer;
    private float spawnrate;
    public Rigidbody2D rb;
    private Vector2 spawnPosition;
    InventoryPlayer inventoryPlayer;
    DeliverBooks deliverBooks;
    public GameObject[] slots;
    private int buffer;


    // Start is called before the first frame update
    void Start()
    {
        spawnrate = 1;
        deliverBooks = FindObjectOfType<DeliverBooks>();
        inventoryPlayer = FindObjectOfType<InventoryPlayer>();


        //Hardcoded spawnposition for registrated books
        spawnPosition = new Vector2(7.1f, -1.8f);
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        //If player holds left shift books are beeing registrated and put on the table
        if (collision.tag == "Registration" && Input.GetKey(KeyCode.LeftShift) && deliverBooks.booksOnTable >= 1)
        {
            timer += Time.deltaTime;

            if (timer > spawnrate)
            {
                Instantiate(books[Random.Range(0, books.Count)], spawnPosition, Quaternion.identity);
                deliverBooks.AddBookToTable(-1);
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Deliver")
        {
            //Checking if inventory is occupied and sending that many books to the table
            //testing with all colors untill a undefined book is ingame 
            for (int i = 0; i < 3; i++)
            {
                if (inventoryPlayer.isFull[i])
                {
                    buffer++;
                }
                if (i == 2 && buffer > 0)
                {
                    Debug.Log(buffer);
                    deliverBooks.AddBookToTable(buffer);
                    inventoryPlayer.ReturnBooks("Book Green");
                    inventoryPlayer.ReturnBooks("Book Red");
                    inventoryPlayer.ReturnBooks("Book Blue");
                    inventoryPlayer.ReturnBooks("Book White");
                    buffer = 0;
                }
            }

        }

    }
}
