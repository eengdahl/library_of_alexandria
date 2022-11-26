using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTextOff : MonoBehaviour
{
    MeshRenderer text;
    void Start()
    {    //Turn off the text when script run ( not done!
        text = GetComponent<MeshRenderer>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
