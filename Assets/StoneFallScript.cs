using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFallScript : MonoBehaviour
{
    [SerializeField] Transform landingSpot;
    RandomXposition randomPositionScript;
    [SerializeField] Transform bounceSpot;
    Transform target;
    bool haveBounced = false;
    float speed = 0.12f;
    float bounceDownSpeed = 0.04f;
    private void Start()
    {
        target = landingSpot;

        if (gameObject.tag == "SmallStone")
        {
            randomPositionScript = GetComponent<RandomXposition>();
        }
    }
    void Update()
    {

        if (gameObject.tag == "SmallStone")
        {
            Vector3 landingspotRandom = landingSpot.position + new Vector3(randomPositionScript.randomX, 0, 0);
            transform.position = Vector3.MoveTowards(this.transform.position, landingspotRandom, 0.1f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed);
            if (transform.position == target.position)
            {
                if (!haveBounced)
                {
                    speed = 0.02f;
                    target = bounceSpot;
                    haveBounced = true;
                }
                else
                {
                    speed = bounceDownSpeed;
                    target = landingSpot;
                }
            }
        }
    }

}
