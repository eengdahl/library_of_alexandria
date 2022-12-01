using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    private InventoryPlayer inventoryPlayer;
    public GameObject BookColour;

    private void Start()
    {
        inventoryPlayer = GameObject.FindGameObjectWithTag ("BookPickUpZone").GetComponent<InventoryPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BookPickUpZone")) 
        {
            for (int i = 0; i < inventoryPlayer.slots.Length; i++)
            {
                if (inventoryPlayer.isFull[i] == false)
                {
                    //BOOK CAN BE ADDED TO INVENTORY
                    inventoryPlayer.isFull[i] = true;
                    Instantiate(BookColour, inventoryPlayer.slots[i].transform, false);
                    Destroy(gameObject);
                    break; //Stop the for loop if empty spot in inventory is found
                }
            }
        }


     
    }
}
