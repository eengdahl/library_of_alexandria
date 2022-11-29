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


    // Start is called before the first frame update
    void Start()
    {
        spawnrate = 1;

        //Hardcoded spawnposition for registrated books
        spawnPosition = new Vector2(7.1f, -1.8f);
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        //If player holds left shift books are beeing registrated and put on the table
        if (collision.tag == "Registration" && Input.GetKey(KeyCode.LeftShift))
        {

            timer += Time.deltaTime;
            if (timer > spawnrate)
            {

                Instantiate(books[Random.Range(0, books.Count)], spawnPosition, Quaternion.identity);

                timer = 0;
            }
        }
    }
}
