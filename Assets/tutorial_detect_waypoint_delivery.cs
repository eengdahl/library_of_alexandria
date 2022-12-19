using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_detect_waypoint_delivery : MonoBehaviour
{
    public GameObject Leave_at_desk_information;
    public GameObject set_books_in_bookshelf_information;
    public GameObject red_bookshelf;
    public GameObject Waypoint_deliver;
    public GameObject End_of_tutorial_text;
    public GameObject continueButton;
    public GameObject Show_Clock;
    public GameObject Show_noicemeter;

    bool playerHaveRedBook = false;
    GameObject redBookChecker;

    InventoryPlayer inventoryPlayer;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPlayer =FindObjectOfType<InventoryPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        //inventoryPlayer.ReturnBooks("Book Red");
            for (int i = 0; i < inventoryPlayer.slots.Length; i++)
            {
                redBookChecker = inventoryPlayer.FindChildWithTag(inventoryPlayer.slots[i],"Book Red");
                if (redBookChecker != null){

                    playerHaveRedBook = true;
                    Debug.Log("should have found red book in inventory");
                }

                // if (inventoryPlayer.slots[i].tag=="Book Red")
                // {
                    
                // }
            }

        if (other.CompareTag ("Waypoint deliver"))
        {
           Leave_at_desk_information.SetActive(false);
           set_books_in_bookshelf_information.SetActive(true);
           red_bookshelf.SetActive(true);
           //Waypoint_deliver.SetActive(false);
           Debug.Log("test.........................................");
        }
        if (other.CompareTag ("tutorial red bookshelf1") && playerHaveRedBook)
        {
           set_books_in_bookshelf_information.SetActive(false);
           End_of_tutorial_text.SetActive(true);
           continueButton.SetActive(true);
           Show_Clock.SetActive(true);
           Show_noicemeter.SetActive(true);
            Cursor.visible = true;
           Debug.Log("test.............jjjgggggggggg..........");
        }
    }

}
