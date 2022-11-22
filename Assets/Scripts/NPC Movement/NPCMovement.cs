using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField]
    Transform[] wayPoints;
    [SerializeField]
    float moveSpeed;
    int waypointIndex = 0;
    
    void Start()
    {
        transform.position = wayPoints[waypointIndex].transform.position;
    }

 
    void Update()
    {
        Move();   
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
