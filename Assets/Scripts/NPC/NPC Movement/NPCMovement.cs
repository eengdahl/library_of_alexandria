using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    //Animations
    Animator thisAnimator;
    [SerializeField]Animator redSpriteAnimator;


    //BasicMovement
    [SerializeField]
    float moveSpeed;
    public bool canMove = true;
    float stopTimer;
    public float stillAfterHusch = 2;

    //Pick up book
    [SerializeField] NPCBookPickUpScript nPCbookPickUp;



    // What book to leave at table
    [SerializeField] GameObject blankBook;
    float[] distanceBetween;

    //Tables flip sprite
    GameObject[] tables;


    //Chairs
    int chairPicker = 0;
    public GameObject[] chairs;
    ChairOccupied chairOccupiedScript;
    public bool hasChair = false;
    float seatedTimer = 0;
    float willBeSeatedFor;
    public bool isSeated = false;

    //Waypoints
    WayPointsArmory wayPointsArmory;
    public Transform[] wayPoints;
    int waypointIndex = 0;
    int movementArrayPickerIndex;
    public int numberOfPaths;
    Transform currentWaypoint;
    bool isLeaving = false;
    int ExitWayPointIndex = 0;

    //Exit
    public GameObject[] exitStartsGO;
    public Transform[] exitStartTF;
    public Transform[] exitWaypoints;//2
    public int numberOfExitArrays;
    int indexPickerExitArray = 0;
    bool havepicked = false;
    public Transform currentTransformExitDebugRemoveLater;
    private void Awake()
    {


    }
    void Start()
    {

        //Tables
        //tables = GameObject.FindGameObjectsWithTag("Table");

        //Animators
        thisAnimator = GetComponent<Animator>();


        wayPointsArmory = FindObjectOfType<WayPointsArmory>();
        //Waypoint Picker
        movementArrayPickerIndex = Random.Range(0, 2);

        wayPoints = wayPointsArmory.GetArray(movementArrayPickerIndex);
        transform.position = wayPoints[waypointIndex].transform.position; // Set location to

        exitStartsGO = GameObject.FindGameObjectsWithTag("ExitStart");
        exitStartTF = new Transform[exitStartsGO.Length];
        chairs = GameObject.FindGameObjectsWithTag("Chair");
        //Store the gameobjects transforms into a transform array
        for (int i = 0; i < exitStartsGO.Length; i++)
        {
            exitStartTF[i] = exitStartsGO[i].transform;
        }
    }

    
    void Update()
    {
        if (gameObject.tag == "NPC")
        { //If NPC havent picked up a book yet
            if (nPCbookPickUp.haveBook == false && isLeaving == false)
            {
                
                CanMove();
            }
            else if (isLeaving == true)
            {

                ExitMove2();
            }
            //If NPC have picked up a book
            else if (nPCbookPickUp.haveBook == true)
            {

                //If has chair
                if (hasChair)
                {
                    if (canMove == true)
                    {
                        stopTimer = 0;
                        MoveToChair();
                        Debug.Log("should move to chair");
                    }
                    else if (canMove == false)
                    {
                        Debug.Log("Should not move");
                        //Idle animators
                        thisAnimator.SetBool("isWalking", false);
                        redSpriteAnimator.SetBool("isWalking", false);

                        stopTimer += Time.deltaTime;
                        if (stopTimer > stillAfterHusch)
                        {
                            canMove = true;
                        }
                    }
                    
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
        else if (chairOccupiedScript.chairOccupied == true && !hasChair)
        {
            ChairPicker();
        }
    }
    void LeaveChair()
    {

        willBeSeatedFor = Random.Range(25f, 30f); //Decides how long the NPC will be seated (starts when book is picked up)
        if (isSeated)// start timer when at chair
        {
            seatedTimer += Time.deltaTime;
        }
        
        if (seatedTimer > willBeSeatedFor && nPCbookPickUp.haveBook == true)
        { //Reset everything that have anything to do with books
            isSeated = false;
            SpawnBook();//Spawn book 
            nPCbookPickUp.haveBook = false;
            chairOccupiedScript.chairOccupied = false;
            hasChair = false;
            seatedTimer = 0;
            isLeaving = true;//Bool to start looking for exit arrays
        }

    }
    void ChairPicker()
    {
        chairPicker = Random.Range(0, chairs.Length);
    }
    void MoveToChair()
    {

        transform.position = Vector3.MoveTowards(transform.position, chairs[chairPicker].transform.position, moveSpeed * Time.deltaTime);
        if(transform.position == chairs[chairPicker].transform.position) // if at chair
        {
            isSeated = true;
            thisAnimator.SetBool("isWalking", false);
            redSpriteAnimator.SetBool("isWalking", false);
        }
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
            //Idle animators
            thisAnimator.SetBool("isWalking", false);
            redSpriteAnimator.SetBool("isWalking", false);
            
            stopTimer += Time.deltaTime;
            if (stopTimer > stillAfterHusch)
            {
                canMove = true;
            }
        }
    }
    void ExitMove2()
    {

        //Pick the closest waypoint
        thisAnimator.SetBool("isWalking", true);
        redSpriteAnimator.SetBool("isWalking", true);
        float distanceStart;
        float distance;
        distanceStart = Vector3.Distance(transform.position, exitStartTF[0].position);
        for (int i = 0; i < exitStartTF.Length; i++) // exitStartTF.Length
        {
            
            if (havepicked== false)
            {
                distance = Vector3.Distance(transform.position, exitStartTF[i].position);
                if (distanceStart < distance)
                {
                   
                    indexPickerExitArray = i;
                    havepicked = true;
                }


            }


        }

        exitWaypoints = wayPointsArmory.GetExitArray(indexPickerExitArray);// Get the array of waypoints for exiting
        
        transform.position = Vector3.MoveTowards(transform.position, exitWaypoints[ExitWayPointIndex].transform.position, moveSpeed * Time.deltaTime);
        currentTransformExitDebugRemoveLater = exitWaypoints[ExitWayPointIndex];//Debug Thingy
        currentWaypoint = exitWaypoints[ExitWayPointIndex]; //For NPC flip
        FlipFacingDirection();
        
        //If NPC reach waypoint, change that waypoint
        if (transform.position == exitWaypoints[ExitWayPointIndex].transform.position)
        {
            ExitWayPointIndex += 1;
        }
        if (ExitWayPointIndex == exitWaypoints.Length)//If reaches the last waypoint delete the npc
        {
            
            Destroy(this.gameObject);

        }
        
    }

    void FlipSpriteWhenSittingAtTable()
    {
        //Sprint 2
    }
    void ExitMove()
    {

        
        bool havepicked = false;
        float distanceStart;
        float distance;
        distanceStart = Vector3.Distance(transform.position, exitStartTF[0].position);
        for (int i = 0; i < exitStartTF.Length; i++)
        {
            Debug.Log("Inside the for loop now :) ");
            if (!havepicked)
            {
                distance = Vector3.Distance(transform.position, exitStartTF[i].position);
                if (distanceStart > distance)
                {
                    Debug.Log("Should have picked the closest");
                    indexPickerExitArray = i;
                    havepicked = true;
                }

                
            }


        }
        wayPoints = wayPointsArmory.GetExitArray(indexPickerExitArray);//Make it change this index
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        currentWaypoint = wayPoints[waypointIndex];
        FlipFacingDirection();

        if (transform.position == wayPoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;

        }
        if (waypointIndex == wayPoints.Length)
        {
            Destroy(this.gameObject);

        }
    }
    void Move()
    {
        thisAnimator.SetBool("isWalking", true);
        redSpriteAnimator.SetBool("isWalking", true);

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        currentWaypoint = wayPoints[waypointIndex];
        FlipFacingDirection();

        if (transform.position == wayPoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;

        }
        if (waypointIndex == wayPoints.Length)
        {
            waypointIndex = 1;

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
        float randomX = Random.Range(-0.42f, 0.42f);
        float randomY = Random.Range(-0.85f, 0.85f);
        //Find the lowest value in distance array
        int lowestIndex;
        lowestIndex = GetIndexOfLowestValue(distanceBetween);
        Instantiate(blankBook, tables[lowestIndex].transform.position + new Vector3(randomX, randomY, 0), tables[lowestIndex].transform.rotation);

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
