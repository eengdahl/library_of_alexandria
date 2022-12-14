using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoundries : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire")
        {
            Destroy(collision.gameObject);
        }
    }
}
