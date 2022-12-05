using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationDesk : MonoBehaviour
{
    Registration registrationScript;
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
    int amountRegistered;
    public List<GameObject> registeredBooks;
    // Start is called before the first frame update
    void Start()
    {
        registrationScript = GetComponent<Registration>();
        amountRegistered = 0;
        spawnrate = 5;
        deliverBooks = FindObjectOfType<DeliverBooks>();
        inventoryPlayer = FindObjectOfType<InventoryPlayer>();

    }
    private void Update()
    {

        if (deliverBooks.booksOnTable >= 1)
        {
            timer += Time.deltaTime;

            if (timer > spawnrate)
            {
                Vector3 thisSpawnPoint = bookSpawnPoint.transform.position + new Vector3(0, amountRegistered / 10f);
                GameObject book = Instantiate(books[UnityEngine.Random.Range(0, books.Count)], thisSpawnPoint, Quaternion.identity);
                registeredBooks.Add(book);
                amountRegistered += 1;
                deliverBooks.AddBookToTable(-1);
                timer = 0;
            }
        }
        //timer += Time.deltaTime;


    }
}



