using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkScript : MonoBehaviour
{
    // The rate at which the object will shrink, in units per second
    public float shrinkRate = 0.1f;
    public float increaseRate = 2f;
    bool increaseSize = true;
    float timer;
    void Update()
    {
        if (increaseSize)
        {
            timer += Time.deltaTime;
            
            transform.localScale += new Vector3(increaseRate, increaseRate, 0) * Time.deltaTime;
            if(timer> 0.3f)
            {
                increaseSize = false;
            }
        }
        else
        {
        // Reduce the object's scale by the shrink rate on each frame
        transform.localScale -= new Vector3(shrinkRate, shrinkRate, 0) * Time.deltaTime;

        }

        // If the object's scale is below a certain threshold, destroy it
        if (transform.localScale.x < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}


