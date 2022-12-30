using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySinger : MonoBehaviour
{
    public bool canBeDestroyed = false;

    void Update()
    {
        if (canBeDestroyed && transform.position.y < -5.9f)
        {
            Destroy(gameObject);
        }
    }
}
