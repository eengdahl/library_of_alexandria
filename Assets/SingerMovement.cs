using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingerMovement : MonoBehaviour
{
    Animator thisAnimator;
    Transform target;
    //Transforms for the spots
    GameObject gOSingerSpot;
    Transform singerSpot;
    Transform destroyPoint;
    GameObject gODestroyPoint;

    Transform directionTransform;
    DestroySinger destroySingerScript;
    float moveInSpeed = 0.003f;
    float moveOutSpeed = 0.01f;
    float speed;
    float directionTimer;

    public bool atSingingSpot = false;
    public bool walkingIn = true;
    // Start is called before the first frame update
    void Start()
    {
        //Find the different transforms 
        gOSingerSpot = GameObject.FindGameObjectWithTag("SingerSpot");
        singerSpot = gOSingerSpot.transform;
        gODestroyPoint = GameObject.FindGameObjectWithTag("SingerDestroyPoint");
        destroyPoint = gODestroyPoint.transform;

        thisAnimator = GetComponent<Animator>();
        destroySingerScript = GetComponent<DestroySinger>();
        target = singerSpot;
        directionTransform = target;
        speed = moveInSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Animate singing 
        if (transform.position == singerSpot.position)
        {
            atSingingSpot = true;
            thisAnimator.SetBool("StandsStill", true);
        }
        else
        {
            atSingingSpot = false;
            thisAnimator.SetBool("StandsStill", false);
        }
        //Move
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

        //Bool for arrow to work
        if (target.position == gOSingerSpot.transform.position)
        {
            walkingIn = true;
        }
        else if (target.position == gODestroyPoint.transform.position)
        {
            walkingIn = false;
        }


        //DirectionSwitch
        directionTimer += Time.deltaTime;
        if (directionTimer> 0.05)
        {
            target = directionTransform;
            directionTimer = 0;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "SingerRemover")
        {
            speed = moveOutSpeed;
            destroySingerScript.canBeDestroyed = true;        
            directionTransform = destroyPoint;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SingerRemover")
        {
            speed = moveInSpeed;
            directionTransform = singerSpot;
        }
    }

}
