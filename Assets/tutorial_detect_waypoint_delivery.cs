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
    public GameObject close_pick_up_information;
    public GameObject close_long_hush_information;
    public GameObject close_pickUpStaminaOre;
    public GameObject ArrowBookRenderer_false;
    public GameObject stopstart_Arrowreception;
    public GameObject start_can_hush;


    bool playerHaveRedBook = false;
    GameObject redBookChecker;

    InventoryPlayer inventoryPlayer;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPlayer = FindObjectOfType<InventoryPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Book White"))
        {
            Leave_at_desk_information.SetActive(true);
            Waypoint_deliver.SetActive(true);
            stopstart_Arrowreception.SetActive(true);
            //start_can_hush.SetActive(true);
            ArrowBookRenderer_false.SetActive(false);
        }
        if (other.CompareTag("Waypoint deliver"))
        {
            start_can_hush.SetActive(true);
            stopstart_Arrowreception.SetActive(false);
            Leave_at_desk_information.SetActive(false);
            set_books_in_bookshelf_information.SetActive(true);
            red_bookshelf.SetActive(true);
            //Waypoint_deliver.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        //inventoryPlayer.ReturnBooks("Book Red");
        for (int i = 0; i < inventoryPlayer.slots.Length; i++)
        {
            redBookChecker = inventoryPlayer.FindChildWithTag(inventoryPlayer.slots[i], "Book Red");
            if (redBookChecker != null)
            {

                playerHaveRedBook = true;
                Debug.Log("should have found red book in inventory");
            }
        }
        if (other.CompareTag("tutorial red bookshelf1") && playerHaveRedBook && Input.GetKey(KeyCode.E))
        {
            Waypoint_deliver.SetActive(false);
            close_long_hush_information.SetActive(false);
            close_pick_up_information.SetActive(false);
            set_books_in_bookshelf_information.SetActive(false);
            End_of_tutorial_text.SetActive(true);
            continueButton.SetActive(true);
            Show_Clock.SetActive(true);
            Show_noicemeter.SetActive(true);
            Cursor.visible = true;
        }
    }

}
