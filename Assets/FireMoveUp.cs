using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMoveUp : MonoBehaviour
{
    Vector3 endSpot = new Vector3(0, 1.43f, 1);
    public float speed = 4;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endSpot, speed * Time.deltaTime);
    }
}
