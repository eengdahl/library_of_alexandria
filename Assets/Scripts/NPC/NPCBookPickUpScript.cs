using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBookPickUpScript : MonoBehaviour
{
    
    public bool haveBook;
    [SerializeField]int whiteBook;
    [SerializeField] int blueBook;
    [SerializeField] int redBook;
    [SerializeField] int greenBook;
    NPCMovement npcMovement;
    // Start is called before the first frame update
    void Start()
    {
        haveBook = false;
        npcMovement = GetComponentInParent<NPCMovement>();
        whiteBook = 0;
        blueBook = 0;
        redBook = 0;
        greenBook = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (haveBook == true)
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int chanceOfPickUp = Random.Range(1, 11);
        if (haveBook == false && chanceOfPickUp > 9)
        {
            
            if (collision.tag == "Bookshelf Green")
            {
                greenBook += 1;
                haveBook = true;
            }
            else if (collision.tag == "Bookshelf Blue")
            {
                blueBook += 1;
                haveBook = true;
            }
            else if (collision.tag == "Bookshelf Red")
            {
                redBook += 1;
                haveBook = true;
            }
            else if (collision.tag == "Bookshelf White")
            {
                whiteBook += 1;
                haveBook = true;
            }
        }

    }


}
