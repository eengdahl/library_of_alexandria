using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_longhush : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject buddy2;
    void Start()
    {
        buddy2 = GameObject.FindGameObjectWithTag("Tutorial buddy2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
        {
           if (other.CompareTag ("Tutorial buddy2"))
            {
              
            }
           
        }

}
