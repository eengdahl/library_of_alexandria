using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    WayPointsArmory wayPointsArmory;

    //BasicMovement
    [SerializeField]
    float moveSpeed;
    public bool canMove = true;
    float stopTimer;
    public float stillAfterHusch = 2;

    //Pick up book
    [SerializeField]NPCBookPickUpScript nPCbookPickUp;

    //Chairs
    int chairPicker = 0;
    public GameObject[] chairs;
    ChairOccupied chairOccupiedScript;
    bool hasChair = false;
    float seatedTimer = 0;
    float willBeSeatedFor;

    //Waypoints
    public Transform[] wayPoints;
    int waypointIndex = 0;
    int movementArrayPickerIndex;

    private void Awake()
    {
        
        wayPointsArmory = FindObjectOfType<WayPointsArmory>();
    }
    void Start()
    {
        //Waypoint Picker
        movementArrayPickerIndex = Random.Range(0, 4);
        
        wayPoints = wayPointsArmory.GetArray(movementArrayPickerIndex);
        transform.position = wayPoints[waypointIndex].transform.position; // Set location to 

        
        chairs = GameObject.FindGameObjectsWithTag("Chair");
        
    }


    void Update()
    {
        //If NPC havent picked up a book yet
        if (nPCbookPickUp.haveBook == false)
        {
            CanMove();
        }
        //If NPC have picked up a book
        else if (nPCbookPickUp.haveBook == true)
        {

            //If has chair
            if (hasChair)
            {              
                MoveToChair();
                LeaveChair();
            }
            //If dont have chair
            else if (!hasChair)
            {
                CheckIfChairsEmpty();
                CanMove();
            }
        }

    }
    void CheckIfChairsEmpty()
    {
        chairOccupiedScript = chairs[chairPicker].GetComponent<ChairOccupied>();
        if (chairOccupiedScript.chairOccupied == false)
        {
            
            chairOccupiedScript.chairOccupied = true;
            hasChair = true;

        }
        else if ( chairOccupiedScript.chairOccupied == true && !hasChair)
        {
            ChairPicker();
        }
    }
    void LeaveChair() 
    {
        
           willBeSeatedFor = Random.Range(25f, 30f); //Decides how long the NPC will be seated (starts when book is picked up)
           seatedTimer += Time.deltaTime;
            if (seatedTimer > willBeSeatedFor)
            { //Reset everything that have anything to do with books
                nPCbookPickUp.haveBook = false;
                chairOccupiedScript.chairOccupied = false;
                hasChair = false;
                seatedTimer = 0;
            }
        
    }
    void ChairPicker()
    {
        chairPicker = Random.Range(0, chairs.Length);
    }
    void MoveToChair()
    {       
        transform.position = Vector3.MoveTowards(transform.position, chairs[chairPicker].transform.position, moveSpeed * Time.deltaTime);
    }
    void CanMove()
    {
        if (canMove == true)
        {
            stopTimer = 0;
            Move();
        }
        else if (canMove == false)
        {
            stopTimer += Time.deltaTime;
            if (stopTimer > stillAfterHusch)
            {
                canMove = true;
            }
        }
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == wayPoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if (waypointIndex == wayPoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
