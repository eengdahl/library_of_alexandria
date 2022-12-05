using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    GameObject kid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bookshelf Red")
        {
            ReturnBooks("Book Red");
        }
        else if (collision.tag == "Bookshelf Blue")
        {
            ReturnBooks("Book Blue");
        }
        else if (collision.tag == "Bookshelf Green")
        {
            ReturnBooks("Book Green");
        }
        else if (collision.tag == "Bookshelf White")
        {
            ReturnBooks("Book White");
        }

    }
    public GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }

    public void ReturnBooks(string bookColour)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            kid = FindChildWithTag(slots[i], bookColour);

            if (kid != null && kid.tag == bookColour)
            {
                Slot slot = slots[i].GetComponent<Slot>();
                slot.DestroyBook();
            }
        }
    }


    //Checking if book in inventory is white and deleting as many books as called for
    public void ReturnBooksToReception(string bookColour,int amount)
    {
        int counter = 0;
        for (int i = 0; i < slots.Length; i++)
        {

            kid = FindChildWithTag(slots[i], bookColour);
            //If book med färg finns -radera den
            if (kid != null && kid.tag == bookColour)
            {
                counter++;
                Slot slot = slots[i].GetComponent<Slot>();
                slot.DestroyBook();
            }

            //Om funktionen är callad för att förstöra en book, avbryts loopen när en book är destroyad
            if(counter >= amount)
            {
                break;
            }

        }
    }
}
