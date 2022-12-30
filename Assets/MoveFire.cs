using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFire : MonoBehaviour
{
    [SerializeField] GameObject soot;

    public void MoveFireHusched()
    {
        //Give new random location and spawn soot at the postiotion before that
        Vector3 newLocation = transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0f);
        Instantiate(soot, transform.position, transform.rotation);
        transform.position = newLocation;

    }
}
