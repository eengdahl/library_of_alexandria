using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondFlowerMove : MonoBehaviour
{
    Vector3 startPosition;
    float moveAwaySpeed = 0.001f;
    float moveBackSpeed = 0.00025f;
    float speed;
    bool contact = false;
    Vector3 targetPosition;
    float timer = 0;
    float moveAmount = 0.1f;
    
    void Start()
    {
        speed = moveAwaySpeed;
        startPosition = transform.position;
        targetPosition = startPosition;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
        //if (contact && startPosition.x + moveAmount < transform.position.x && startPosition.x + moveAmount > transform.position.x)
        //{
        //    //timer += Time.deltaTime;
        //    //if (timer > 2)
        //    //{
        //    //    //targetPosition = startPosition;
        //    //    contact = false;
        //    //    timer = 0;
        //    //}
        //}
        if (contact)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                speed = moveBackSpeed;
                targetPosition = startPosition;
                timer = 0;
                contact = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speed = moveAwaySpeed;
            contact = true;
            if (collision.transform.position.x > transform.position.x)
            {
                targetPosition = startPosition - new Vector3(moveAmount, 0, 0);
            }
            else if (collision.transform.position.x < transform.position.x)
            {
                targetPosition = startPosition + new Vector3(moveAmount, 0, 0);
            }
        }
    }
}
