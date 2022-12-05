using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundries : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, 0);
        }
        else if(transform.position.y <= -4.7f)
        {
            transform.position = new Vector3(transform.position.x, -4.7f, 0);
        }
        if (transform.position.x <= -9.1f)
        {
            transform.position = new Vector3(-9.1f, transform.position.y, 0);
        }
        else if (transform.position.x >= 9.14)
        {
            transform.position = new Vector3(9.14f, transform.position.y, 0);
        }
    }
}
