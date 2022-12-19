using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPlayer : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    GameObject kid;
    [SerializeField] Image[] inventorySlotsImages; 
    public bool inventoryFull;
    public int invSpotsUsed;
    int spotsWhileInLoop;
    private void Update()
    {
        //Loop for inventory hide and book magnet to work
        for (int i = 0; i < isFull.Length; i++)
        {
            int usedSpots;
            if (isFull[i] == true)
            {
                inventorySlotsImages[i].enabled = true;
                usedSpots = 1;
            }
            else
            {
                inventorySlotsImages[i].enabled = false;
                usedSpots = 0;
            }
            spotsWhileInLoop += usedSpots;
        }
        invSpotsUsed = spotsWhileInLoop;
        spotsWhileInLoop = 0;
        if(invSpotsUsed >= 3)
        {
            inventoryFull = true;
        }
        else
        {
            inventoryFull = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If collision with Bookshelf
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

        //If collision with researcher
        if (collision.tag == "Researcher Red" )
        {
            bool returnedBook = false;
            NPCResearcherMovement nPCResearcher = collision.gameObject.GetComponent<NPCResearcherMovement>();
             //Only if ReturnBooks is done!!!
            GiveNPCBook("Book Red",1,returnedBook); //Returned book doesnt change
            if (returnedBook)
            {

                nPCResearcher.gotBook = true; 
                collision.tag = "Researcher";
            }

        }
        else if (collision.tag == "Researcher Blue" )
        {
            bool returnedBook = false;
            NPCResearcherMovement nPCResearcher = collision.gameObject.GetComponent<NPCResearcherMovement>();
            
            GiveNPCBook("Book Blue",1,returnedBook);
            
            if (returnedBook)
            {

                nPCResearcher.gotBook = true;
                collision.tag = "Researcher";
            }
        }
        else if (collision.tag == "Researcher Green" )
        {
            bool returnedBook = false;
            NPCResearcherMovement nPCResearcher = collision.gameObject.GetComponent<NPCResearcherMovement>();
            
            GiveNPCBook("Book Green",1,returnedBook);
            
            if (returnedBook)
            {

                nPCResearcher.gotBook = true;
                collision.tag = "Researcher";
            }
        }
        else if (collision.tag == "Researcher White")
        {
            bool returnedBook = false;
            NPCResearcherMovement nPCResearcher = collision.gameObject.GetComponent<NPCResearcherMovement>();
            GiveNPCBook("Book White",1,returnedBook);


            if (returnedBook)
            {

            nPCResearcher.gotBook = true;
            collision.tag = "Researcher";
            }
        }
    }
    private void HideInventory()
    {

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
    void GiveNPCBook(string bookColour, int amount,bool gaveBook)
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
                gaveBook = true;
            }

            //Om funktionen är callad för att förstöra en book, avbryts loopen när en book är destroyad
            if (counter >= amount)
            {
                break;
            }

        }
    }
}
