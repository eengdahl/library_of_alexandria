using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTiltScript : MonoBehaviour
{
    MakeHuschSound makeHuschSound;
    float tiltSpeed = 20f;
    float angle;
    float targetAngle;
    bool contactPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        makeHuschSound = FindObjectOfType<MakeHuschSound>();
        targetAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!contactPlayer)
        {
            
        }

        angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, tiltSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tiltSpeed = 20;
            contactPlayer = true;
            if(collision.transform.position.x > transform.position.x)
            {
                targetAngle = 6;
                //transform.eulerAngles = new Vector3(0, 0, angle);
            }
            if (collision.transform.position.x < transform.position.x)
            {

                targetAngle = -6;
                //transform.eulerAngles = new Vector3(0, 0, angle);
            }

        }
        if (collision.tag == "Husch" && makeHuschSound.doesHuschSound)
        {
                tiltSpeed = 40f;
            if (collision.transform.position.x > transform.position.x)
            {
                targetAngle = 6;
                //transform.eulerAngles = new Vector3(0, 0, angle);
            }
            if (collision.transform.position.x < transform.position.x)
            {              
                targetAngle = -6;
                //transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            contactPlayer = false;
        }
        targetAngle = 0;
        //transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
