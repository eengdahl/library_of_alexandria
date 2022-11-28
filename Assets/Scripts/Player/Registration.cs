using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registration : MonoBehaviour
{
    public List<GameObject> books;
    public float timer;
    private float spawnrate;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        spawnrate = 1;
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Registration" && Input.GetKey(KeyCode.LeftShift))
        {

            timer += Time.deltaTime;
            if (timer > spawnrate)
            {
                 Instantiate(books[Random.Range(0, books.Count)], rb.position, Quaternion.identity);
            
                timer = 0;
            }
        }
    }
}
