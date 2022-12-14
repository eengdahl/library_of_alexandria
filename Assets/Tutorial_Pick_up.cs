using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Pick_up : MonoBehaviour
{
    private InventoryPlayer inventoryPlayer;
    public GameObject BookColour;
    public GameObject Tutorialbook_pick_up_information;
    public GameObject Leave_on_desk_information;

    public GameObject activate_Waypoint_deliver;
    float timer;

    private void Start()
    {
        inventoryPlayer = GameObject.FindGameObjectWithTag ("BookPickUpZone").GetComponent<InventoryPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BookPickUpZone")) 
        {
            //timer += Time.deltaTime;
            for (int i = 0; i < inventoryPlayer.slots.Length; i++)
            {
                if (inventoryPlayer.isFull[i] == false)
                {
                    //BOOK CAN BE ADDED TO INVENTORY
                    inventoryPlayer.isFull[i] = true;
                    Instantiate(BookColour, inventoryPlayer.slots[i].transform, false);
                    Tutorialbook_pick_up_information.SetActive(false);
                    Leave_on_desk_information.SetActive(true);
                    activate_Waypoint_deliver.SetActive(true);
                    Destroy(gameObject);

                    break; //Stop the for loop if empty spot in inventory is found
                }
            }
        }
    }
}
