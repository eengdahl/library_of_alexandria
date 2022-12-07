using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCResearcherMovement : MonoBehaviour
{
    //Basic Movement
    [SerializeField]
    float moveSpeed;

    bool isAtPoint;


    //Order UI
    private NPCInventory npcInventory;
    public Image uiImageBackground;
    public GameObject[] booksUI;//Array of different books to pick from
    public GameObject bookUI;//The pickedbook
    int bookPicker;

    //Waypoints
    WayPointsArmory wayPointsArmory;
    public Transform[] wayPoints;
    int waypointIndex = 0;
    public int movementArrayPickerIndex;
    Transform currentWaypoint;
    

    private void Start()
    {
        //UI
        uiImageBackground.enabled = false;       
        bookPicker = Random.Range(0, 3);
        npcInventory = GetComponent<NPCInventory>();
        
        //bookColorUi.enabled = false;
        //Waypoints
        wayPointsArmory = FindObjectOfType<WayPointsArmory>(); // Get the waypoints armory component
        movementArrayPickerIndex = Random.Range(0, 2); //Waypoint Picker
        wayPoints = wayPointsArmory.ResearcherGetArray(movementArrayPickerIndex);//Pick witch array
        transform.position = wayPoints[waypointIndex].transform.position;//Set location to first waypoint
        isAtPoint = false;
    }
    private void Update()
    {
        if (!isAtPoint)
        {
            MoveToSpot();
        }
        
        if (isAtPoint)
        {
            MakeOrder();
        }
    }


    void StartScreaming()
    {

    }
    void MakeOrder()
    {
        //Enable sprite of bakground of orderbook
        uiImageBackground.enabled = true;
         for (int i = 0; i < npcInventory.slots.Length; i++)
         {
            if (npcInventory.isFull[i] == false)
            {
                bookUI = booksUI[bookPicker];
                //BOOK CAN BE ADDED TO INVENTORY
                npcInventory.isFull[i] = true;
                Instantiate(bookUI, npcInventory.slots[i].transform, false);               
                break; //Stop the for loop if empty spot in inventory is found
            }
        }

        
    }
    void MoveToSpot()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        currentWaypoint = wayPoints[waypointIndex];
        FlipFacingDirection();

        if (transform.position == wayPoints[waypointIndex].transform.position)//Move to next waypointIndex
        {
            if (waypointIndex != wayPoints.Length-1)
            {

                waypointIndex += 1;
            }
        }
        if (waypointIndex == wayPoints.Length-1)
        {
            Debug.Log("Is at point");
            isAtPoint = true;
        }
    }
    void FlipFacingDirection()
    {
        if (currentWaypoint.position.x < transform.position.x)
        {
            if (transform.localScale.x > 0)
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        else if (currentWaypoint.position.x > transform.position.x)
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}
