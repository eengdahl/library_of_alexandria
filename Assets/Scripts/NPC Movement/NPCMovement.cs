using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    WayPointsArmory wayPointsArmory;
    
    public Transform[] wayPoints;
    [SerializeField]
    float moveSpeed;
    int waypointIndex = 0;
    public bool canMove = true;
    int movementArrayPickerIndex;
    float stopTimer;
    public float stillAfterHusch = 2;
    void Start()
    {
        movementArrayPickerIndex = Random.Range(0, 4);
        wayPointsArmory = FindObjectOfType<WayPointsArmory>();
        wayPoints = wayPointsArmory.GetArray(movementArrayPickerIndex);
        transform.position = wayPoints[waypointIndex].transform.position;
    }

 
    void Update()
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
