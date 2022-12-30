using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCMovement : MonoBehaviour
{

    //Animations
    Animator thisAnimator;
    [SerializeField] Animator redSpriteAnimator;
    SpriteRenderer spriteRenderer;


    //BasicMovement
    [SerializeField]
    Difficulty difficulty;
   public float moveSpeed;
    public bool canMove = true;
    float stopTimer;
    public float stillAfterHusch = 2;

    //Pick up book
    [SerializeField] NPCBookPickUpScript nPCbookPickUp;



    // What book to leave at table
    [SerializeField] GameObject blankBook;
    float[] distanceBetween;



    //Chairs
    int chairPicker = 0;

    //The Picked array of chairs
    public GameObject[] chairs;


    //Chairs arrays
    ChairLists chairListScript;


    bool onLeftSide = false;
    ChairOccupied chairOccupiedScript;
    public bool hasChair = false;
    float seatedTimer = 0;
    float willBeSeatedFor;
    public bool isSeated = false;
    //Chair checker Spots
    Vector3 nextCheckerSpot;
    int chairCheckerIndex = 0;
    int chairSpotIndex = 0;

    //Waypoints
    WayPointsArmory wayPointsArmory;
    public Transform[] wayPoints;
    int waypointIndex = 0;
    int movementArrayPickerIndex;
    public int numberOfPaths;
    Transform currentWaypoint;
    public bool isLeaving = false;
    int ExitWayPointIndex = 0;

    //Exit
    bool havePickedExit = false;
    int indexPickerExitArray;
    ExitStart exitStartScript;
    List<Transform> listOfExitStarts;
    Transform[] exitWayPoints;
    bool atExitSpot = false;



    //Onfire
    public bool OnFire = false;
    float onFireSpeed;
    float startMoveSpeed;
    //Move to table

    int tableWayPointIndex = 0;
    int indexPickerTableArray;
    TableStart tableStartScript;
    List<Transform> listOfToTableStarts;
    bool havePickedTablePath = false;
    bool atTableStart = false;
    bool atTableFinish = false;
    public Transform[] toTableWayPoints;

    private void Awake()
    {


    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


        //Exit
        exitStartScript = FindObjectOfType<ExitStart>();
        listOfExitStarts = exitStartScript.exitTransforms;

        //Tables
        tableStartScript = FindObjectOfType<TableStart>();
        listOfToTableStarts = tableStartScript.moveToTableTransforms;

        //Animators
        thisAnimator = GetComponent<Animator>();


        wayPointsArmory = FindObjectOfType<WayPointsArmory>();
        //Waypoint Picker
        movementArrayPickerIndex = Random.Range(0, 4);

        wayPoints = wayPointsArmory.GetArray(movementArrayPickerIndex);
        transform.position = wayPoints[waypointIndex].transform.position; // Set location to

        //Chairs 

        chairListScript = FindObjectOfType<ChairLists>();

        //Level specific movespeed
        difficulty = FindObjectOfType<Difficulty>();
        moveSpeed = difficulty.levelSpeed;
        startMoveSpeed = difficulty.levelSpeed;

        //OnFire
        onFireSpeed = moveSpeed * 2f;
        startMoveSpeed = moveSpeed;

    }


    void Update()
    {
        if (OnFire)
        {
            moveSpeed = onFireSpeed; 
        }
        else
        {

            moveSpeed = startMoveSpeed;
        }

        //To se if NPC is on left or right side of map
        if (transform.position.x < 0)
        {
            onLeftSide = true;
        }
        if (transform.position.x >= 0)
        {
            onLeftSide = false;
        }




        //If NPC havent picked up a book yet
        if (nPCbookPickUp.haveBook == false && isLeaving == false && isSeated == false)
        {

            CanMove();
        }
        else if (isLeaving == true)
        {

            ExitMove3();
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
                }
                else if (canMove == false)
                {
                    //Idle animators
                    thisAnimator.SetBool("isWalking", false);


                    stopTimer += Time.deltaTime;
                    if (stopTimer > stillAfterHusch)
                    {
                        canMove = true;
                    }
                }

                LeaveChair();

            }
            //If dont have chair
            else if (!hasChair && !atTableFinish)
            {
                //CheckIfChairsEmpty();
                //CanMove();
                MoveToChairCheckerArea();

            }
            if (atTableFinish && !hasChair) // start moving back and forth if no seats found
            {
                
                LookingForFreeSeats();
            }
        }



    }
    void LookingForFreeSeats()
    {

      
        transform.position = Vector3.MoveTowards(transform.position, nextCheckerSpot, moveSpeed * Time.deltaTime);

        if (onLeftSide)
        {
           
            chairs = chairListScript.listOfLeftChairArrays[chairCheckerIndex];

            CheckIfChairsEmpty();
            
            //If npc reaches the spot where it should check;
            
            if (transform.position == nextCheckerSpot)
            {
                chairPicker = 0;
                //Check if any chair is empty
                //change what chairs its checking when reaching checker spots
                if (chairCheckerIndex < chairListScript.listOfLeftChairArrays.Count)
                {
                    chairCheckerIndex += 1;

                }
                if (chairCheckerIndex >= chairListScript.listOfLeftChairArrays.Count)
                {
                    chairCheckerIndex = 0;
                }
                if (chairSpotIndex < wayPointsArmory.leftCheckerSpotsArray.Length)
                {
                    chairSpotIndex += 1;
                }
                if (chairSpotIndex >= wayPointsArmory.leftCheckerSpotsArray.Length)
                {
                    chairSpotIndex = 0;
                }

                nextCheckerSpot = wayPointsArmory.leftCheckerSpotsArray[chairSpotIndex].position;
                //NPC sprite flip
                currentWaypoint = wayPointsArmory.leftCheckerSpotsArray[chairSpotIndex];
                FlipFacingDirection();
                
            }



            }
            //Debug.Log("Hello can you see me? On left side bool: "+onLeftSide);
            if (onLeftSide == false)
            {
                
                chairs = chairListScript.listOfRightChairArrays[chairCheckerIndex];

                CheckIfChairsEmpty();
            //If npc reaches the spot where it should check;
           

            if (transform.position == nextCheckerSpot)//(transform.position == nextCheckerSpot)
                    {

                    chairPicker = 0;
                    //Check if any chair is empty
                    //change what chairs its checking when reaching checker spots
                    if (chairCheckerIndex < chairListScript.listOfRightChairArrays.Count)
                    {
                        chairCheckerIndex += 1;

                    }
                    else if (chairCheckerIndex >= chairListScript.listOfRightChairArrays.Count)
                    {
                        chairCheckerIndex = 0;
                    }
                    if (chairSpotIndex < wayPointsArmory.rightCheckerSpotsArray.Length)
                    {
                        chairSpotIndex += 1;
                    }
                    if (chairSpotIndex >= wayPointsArmory.rightCheckerSpotsArray.Length)
                    {
                        chairSpotIndex = 0;
                    }
                    nextCheckerSpot = wayPointsArmory.rightCheckerSpotsArray[chairSpotIndex].position;
                    
                    //NPC sprite flip
                    currentWaypoint = wayPointsArmory.rightCheckerSpotsArray[chairSpotIndex];
                    FlipFacingDirection();
                    
                }
        }
        void CheckIfChairsEmpty()
        {
            if (onLeftSide)
            {
                chairs = chairListScript.listOfLeftChairArrays[chairCheckerIndex];
                chairOccupiedScript = chairs[chairPicker].GetComponent<ChairOccupied>();//chairsMiddleL[chairPicker].GetComponent<ChairOccupied>();

                if (chairOccupiedScript.chairOccupied == false)
                {
                    chairOccupiedScript.chairOccupied = true;
                    hasChair = true;
                    atTableFinish = false;
                }
                else if (chairOccupiedScript.chairOccupied == true && !hasChair)
                {
                    ChairPicker();
                }
            }
            else if (onLeftSide == false)
            {
                chairs = chairListScript.listOfRightChairArrays[chairCheckerIndex];
                chairOccupiedScript = chairs[chairPicker].GetComponent<ChairOccupied>();

                if (chairOccupiedScript.chairOccupied == false)
                {
                    chairOccupiedScript.chairOccupied = true;
                    hasChair = true;
                    atTableFinish = false;
                }
                else if (chairOccupiedScript.chairOccupied == true && !hasChair)
                {
                    ChairPicker();
                }
            }

        }
    }
    void LeaveChair()
    {
        willBeSeatedFor = Random.Range(30f, 35f); //Decides how long the NPC will be seated (starts when book is picked up)
        if (isSeated)// start timer when at chair
        {
            seatedTimer += Time.deltaTime;

            thisAnimator.SetFloat("isSitting", seatedTimer);
            if (chairs[chairPicker].tag == "Chair Face Left")
            {
                transform.localScale = new Vector2(-2, transform.localScale.y);
            }
            else if (chairs[chairPicker].tag == "Chair Face Right")
            {
                transform.localScale = new Vector2(2, transform.localScale.y);
            }
        }

        if (seatedTimer > willBeSeatedFor && nPCbookPickUp.haveBook == true)
        { //Reset everything that have anything to do with books
            Debug.Log("Should reset occupied bool");
            chairOccupiedScript.chairOccupied = false;
            isSeated = false;
            SpawnBook2();//Spawn book 
            nPCbookPickUp.haveBook = false;
            hasChair = false;
            seatedTimer = 0;
            thisAnimator.SetFloat("isSitting", seatedTimer);
            isLeaving = true;//Bool to start looking for exit arrays
        }

    }
    void ChairPicker()
    {
        if (chairPicker < chairs.Length - 1)
        {
            chairPicker += 1;
        }
        if (chairPicker >= chairs.Length)
        {
            chairPicker = 0;
        }
        //chairPicker = Random.Range(0, chairs.Length); //chairs.Length
    }
    void MoveToChair()
    {
        if (!isSeated)
        {
            FlipFacingDirection();
        }

        transform.position = Vector3.MoveTowards(transform.position, chairs[chairPicker].transform.position - new Vector3(0f, 0.4f, 0), moveSpeed * Time.deltaTime);
        if (transform.position == chairs[chairPicker].transform.position - new Vector3(0, 0.4f, 0)) // if at chair
        {
            isSeated = true;
        }
        currentWaypoint = chairs[chairPicker].transform;
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


            stopTimer += Time.deltaTime;
            if (stopTimer > stillAfterHusch)
            {
                canMove = true;
            }
        }
    }

    void MoveToChairCheckerArea()
    {
        ////To se if NPC is on left or right side of map
        //if (transform.position.x < 0)
        //{
        //    onLeftSide = true;
        //}
        //else if (transform.position.x > 0)
        //{
        //    onLeftSide = false;
        //}
        thisAnimator.SetBool("isWalking", true);
        float distanceFinal = Vector3.Distance(transform.position, listOfToTableStarts[0].position);
        //Loop through all moveToTableStarts and find the closest one;
        if (!havePickedTablePath)
        {
            for (int i = 0; i < listOfToTableStarts.Count; i++)
            {
                float distanceCheck = Vector3.Distance(transform.position, listOfToTableStarts[i].position);
                if (distanceFinal > distanceCheck)
                {
                    indexPickerTableArray = i;
                    distanceFinal = distanceCheck;
                }
                if (i == listOfToTableStarts.Count - 1)
                {
                    havePickedTablePath = true;
                }
            }
        }
        //Move to path start
        if (!atTableStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, listOfToTableStarts[indexPickerTableArray].transform.position, moveSpeed * Time.deltaTime);
        }
        if (!atTableStart && transform.position == listOfToTableStarts[indexPickerTableArray].transform.position)
        {

            atTableStart = true;
        }
        //Get array of waypoints to move to table area
        toTableWayPoints = wayPointsArmory.GetMoveToTableArray(indexPickerTableArray);
        //NPC sprite flip
        currentWaypoint = toTableWayPoints[tableWayPointIndex];
        FlipFacingDirection();
        //Move to table area;
        if (atTableStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, toTableWayPoints[tableWayPointIndex].transform.position, moveSpeed * Time.deltaTime);
        }
        float distance = Vector3.Distance(transform.position, toTableWayPoints[tableWayPointIndex].transform.position);
        if (distance<0.2f)//(transform.position == toTableWayPoints[tableWayPointIndex].transform.position)
        {
            tableWayPointIndex += 1;
        }
        if (tableWayPointIndex == toTableWayPoints.Length)//If reaches the last waypoint set a bool to true so it starts searching for chair
        {

            if (onLeftSide)
            {
                nextCheckerSpot = wayPointsArmory.leftCheckerSpotsArray[0].position;
            }
            if (!onLeftSide)
            {
                nextCheckerSpot = wayPointsArmory.rightCheckerSpotsArray[0].position;
            }


            atTableFinish = true;
        }

    }
    void ExitMove3()
    {
        //Pick the closest waypoint
        thisAnimator.SetBool("isWalking", true);

        float distanceFinal = Vector3.Distance(transform.position, listOfExitStarts[0].position); //Start getting the distance between one exit and the npc

        //Loop through all exit paths and find the closest one;
        if (!havePickedExit)
        {

            for (int i = 0; i < listOfExitStarts.Count; i++)
            {
                float distance = Vector3.Distance(transform.position, listOfExitStarts[i].position);
                if (distanceFinal > distance)
                {
                    indexPickerExitArray = i;
                    distanceFinal = distance;
                }
                if (i == listOfExitStarts.Count - 1)
                {
                    havePickedExit = true;
                }
            }

        }
        //Move to exit spot
        if (!atExitSpot)
        {
            transform.position = Vector3.MoveTowards(transform.position, listOfExitStarts[indexPickerExitArray].transform.position, moveSpeed * Time.deltaTime);
        }
        if (!atExitSpot && transform.position == listOfExitStarts[indexPickerExitArray].transform.position)
        {
            atExitSpot = true;
        }
        // Get the array of waypoints for exiting
        exitWayPoints = wayPointsArmory.GetExitArray(indexPickerExitArray);

        //For NPC flip
        currentWaypoint = exitWayPoints[ExitWayPointIndex];
        FlipFacingDirection();

        //Move out of library
        if (atExitSpot)
        {
            transform.position = Vector3.MoveTowards(transform.position, exitWayPoints[ExitWayPointIndex].transform.position, moveSpeed * Time.deltaTime);
        }

        if (transform.position == exitWayPoints[ExitWayPointIndex].transform.position)
        {
            ExitWayPointIndex += 1;
        }
        if (ExitWayPointIndex == exitWayPoints.Length)//If reaches the last waypoint delete the npc
        {

            Destroy(this.gameObject);

        }

    }
    void Move()
    {
        thisAnimator.SetBool("isWalking", true);
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

    void SpawnBook2()
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
        //Find the lowest value in distance array
        int lowestIndex;
        lowestIndex = GetIndexOfLowestValue(distanceBetween);
        //SpawnBook
        //If on right side of table
        if (tables[lowestIndex].transform.position.x < transform.position.x)
        {
            float randomPlacement = Random.Range(0, 0.07f);
            Vector3 instantiateBookVector = transform.position - new Vector3(0.5f, randomPlacement, 0);
            //Instantiate(blankBook, transform.position - new Vector3(0.5f, 0, 0) , tables[lowestIndex].transform.rotation);//+ new Vector3(0,2,0)
            Instantiate(blankBook, instantiateBookVector + new Vector3(randomPlacement, 0.5f, 0), Quaternion.Euler(0, 0, 90));//+ new Vector3(0,2,0)//* new Quaternion(0, 0, -45, 0)//tables[lowestIndex].transform.rotation
        }
        //if on left side of table
        else if (tables[lowestIndex].transform.position.x > transform.position.x)
        {
            float randomPlacement = Random.Range(0, 0.07f);
            Vector3 instantiateBookVector = transform.position + new Vector3(0.5f, randomPlacement, 0);
            Instantiate(blankBook, instantiateBookVector + new Vector3(randomPlacement, 0.5f, 0), Quaternion.Euler(0, 0, -90));//+ new Vector3(0,2,0)//* new Quaternion(0,0,45,0) //tables[lowestIndex].transform.rotation * 
            //Instantiate(blankBook, transform.position + new Vector3(0.5f, 0, 0), tables[lowestIndex].transform.rotation);//+ new Vector3(0,2,0)
        }
        //Instantiate(blankBook, tables[lowestIndex].transform.position + new Vector3(randomX, randomY, 0), tables[lowestIndex].transform.rotation);
    }
    void SpawnBook()
    {
        float chanceOfNotDroppingBook;
        chanceOfNotDroppingBook = Random.Range(0, 10);
        if (chanceOfNotDroppingBook > 7)
        {
            return;
        }
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
