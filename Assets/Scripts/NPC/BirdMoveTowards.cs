using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoveTowards : MonoBehaviour
{
    int waypointIndex = 0;
    public Transform[] wayPoints;
    Transform currentWaypoint;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        currentWaypoint = wayPoints[waypointIndex];
        

        if (transform.position == wayPoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;

        }
        if (waypointIndex == wayPoints.Length)
        {
            Destroy(gameObject);

        }
    }
}
