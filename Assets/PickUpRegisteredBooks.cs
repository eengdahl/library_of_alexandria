using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRegisteredBooks : MonoBehaviour
{
    Registration registrationScript; //Get the amount registered from this script and remove amount when book is picked up + get registered book list and remove from there
    private InventoryPlayer inventoryPlayer;
    public List <GameObject> bookColours;



    private void Start()
    {
        registrationScript = FindObjectOfType<Registration>();
        inventoryPlayer = GameObject.FindGameObjectWithTag("BookPickUpZone").GetComponent<InventoryPlayer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BookPickUpZone" && Input.GetKey(KeyCode.E))
        {
            if (registrationScript.registeredBooks.Count > 0)
            {
                GameObject book = registrationScript.registeredBooks[registrationScript.registeredBooks.Count - 1]; // Make the higest up book in stack this GameObject
                BookColorOfThisBook bookcolorScript = book.GetComponent<BookColorOfThisBook>();
                GameObject bookcolor = bookcolorScript.bookColour;//Get the colour of the book
                //Add that colour to the inventory

                for (int i = 0; i < inventoryPlayer.slots.Length; i++)
                {
                    if (inventoryPlayer.isFull[i] == false)
                    {
                        //BOOK CAN BE ADDED TO INVENTORY
                        inventoryPlayer.isFull[i] = true;
                        Instantiate(bookcolor, inventoryPlayer.slots[i].transform, false);
                        Destroy(book);
                        registrationScript.amountRegistered -= 1;
                        registrationScript.registeredBooks.Remove(registrationScript.registeredBooks[registrationScript.registeredBooks.Count - 1]);
                        break; //Stop the for loop if empty spot in inventory is found
                    }
                }
                

            }
            
        }







        //{
        //    Debug.Log("Collision activated");
        //    for (int i = registrationScript.registeredBooks.Count; i >= registrationScript.registeredBooks.Count; i--)
        //    {
        //        Debug.Log("First Loop");
        //        for (int j = 0; i < inventoryPlayer.slots.Length; j++)
        //        {
        //            Debug.Log("Second Loop");
        //            if (inventoryPlayer.isFull[i] == false)
        //            {
        //                Debug.Log("Inside if statement");
        //                BookColorOfThisBook bookColourScript = registrationScript.registeredBooks[i].GetComponent<BookColorOfThisBook>();
        //                GameObject BookColour = bookColourScript.bookColour;
        //                //BOOK CAN BE ADDED TO INVENTORY
        //                inventoryPlayer.isFull[i] = true;
        //                Instantiate(BookColour, inventoryPlayer.slots[i].transform, false);
        //                Destroy(gameObject);
        //                break; //Stop the for loop if empty spot in inventory is found
        //            }
        //        }
        //    }
        //}
    }
}
