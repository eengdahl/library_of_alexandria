using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFallScript : MonoBehaviour
{
    
    [SerializeField] Transform landingSpot;
    RandomXposition randomPositionScript;

    private void Start()
    {
        if(gameObject.tag == "SmallStone")
        {
            randomPositionScript = GetComponent<RandomXposition>();
        }
    }
    void Update()
    {
        if(gameObject.tag == "SmallStone")
        {

            Vector3 landingspotRandom = landingSpot.position + new Vector3(randomPositionScript.randomX, 0, 0);
            transform.position = Vector3.MoveTowards(this.transform.position, landingspotRandom, 0.07f);
        }
        else
        {

        transform.position = Vector3.MoveTowards(this.transform.position, landingSpot.position, 0.06f);
        }
    }

}
