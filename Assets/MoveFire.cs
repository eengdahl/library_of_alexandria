using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFire : MonoBehaviour
{
    [SerializeField] GameObject soot;
    [SerializeField] FireHusched fireHuschedScript;
    public void MoveFireHusched()
    {
        //Give new random location and spawn soot at the position before that
        Vector3 newLocation = transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0f);
        Instantiate(soot, transform.position, transform.rotation);
        transform.position = newLocation;
        if(transform.position != newLocation)
        {
            fireHuschedScript.enabled = false;
        }
    }
}
