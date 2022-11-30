using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
   

    //BasicMovement
    [SerializeField]
    float moveSpeed;
    public bool canMove = true;
    float stopTimer;
    public float stillAfterHusch = 2;

    //Pick up book
    [SerializeField]NPCBookPickUpScript nPCbookPickUp;



    // What book to leave at table
    [SerializeField]GameObject blankBook;
    float[] distanceBetween;


    //Chairs
    int chairPicker = 0;
    public GameObject[] chairs;
    ChairOccupied chairOccupiedScript;
    public bool hasChair = false;
    float seatedTimer = 0;
    float willBeSeatedFor;

    //Waypoints
    WayPointsArmory wayPointsArmory;
    public Transform[] wayPoints;
    int waypointIndex = 0;
    int movementArrayPickerIndex;
    public int numberOfPaths;
    Transform currentWaypoint;
    private void Awake()
    {
      

    }
    void Start()
    {
        wayPointsArmory = FindObjectOfType<WayPointsArmory>();
        //Waypoint Picker
        movementArrayPickerIndex = Random.Range(0, 3);

        wayPoints = wayPointsArmory.GetArray(movementArrayPickerIndex);
        transform.position = wayPoints[waypointIndex].transform.position; // Set location to


        chairs = GameObject.FindGameObjectsWithTag("Chair");
        
    }


    void Update()
    {
        if(gameObject.tag == "NPC")
        { //If NPC havent picked up a book yet
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
        if (gameObject.tag == "Researcher")
        {
            Move();
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
            SpawnBook();//Spawn book 
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
        currentWaypoint = chairs[chairPicker].transform;
        FlipFacingDirection();
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
        currentWaypoint = wayPoints[waypointIndex];
        FlipFacingDirection();

        if (transform.position == wayPoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
            
        }
        if (waypointIndex == wayPoints.Length)
        {
            waypointIndex = 0;
            
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
    void SpawnBook()
    {
        GameObject[] tables; //tables gameObjects
        tables = GameObject.FindGameObjectsWithTag("Table");
        distanceBetween = new float[tables.Length];

        //Calculate the distance between the NPC position and the tables
        for (int i = 0; i < tables.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, tables[i].transform.position);
            
            distanceBetween[i] = distance;
            
        }
        //Randomize x and y spawn point of table
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-0.1f, 0.1f);
        //Find the lowest value in distance array
        int lowestIndex;
        lowestIndex = GetIndexOfLowestValue(distanceBetween);
        Instantiate(blankBook, tables[lowestIndex].transform.position + new Vector3(randomX,randomY,0), tables[lowestIndex].transform.rotation);

    }
    public int GetIndexOfLowestValue(float[] arr)
    {
        float value = float.PositiveInfinity;
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < value)
            {
                index = i;
                value = arr[i];
            }
        }
        return index;
    }
}
