using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SootSize : MonoBehaviour
{
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < fire.transform.localScale.x)
        {
            transform.localScale = fire.transform.localScale ;
        }
    }
}
