using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockShake : MonoBehaviour
{
    Meters metersScript;
    GameObjectShakeSuperNew shakeScript;
    // Start is called before the first frame update
    void Start()
    {
        metersScript = FindObjectOfType<Meters>();
        shakeScript = GetComponent<GameObjectShakeSuperNew>();
    }

    // Update is called once per frame
    void Update()
    {
        if((metersScript.shouldShake == true)) 
        {
            Debug.Log("Should shake ");
            shakeScript.ShakeIt();
        }
    }
}
