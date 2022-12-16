using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarShake : MonoBehaviour
{
    public NoiseHandeler noiseHandlerScript;
    bool shaking;
    public float shakeAmount;
    float timer;
    //public float shakeSpeed;
    Vector2 earStartPos;
    void Start()
    {
        earStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //start shaking the ear if only 10% before losing of sound
        if (noiseHandlerScript.soundLevelInRoom >= 95)
        {
            shaking = true;
        }
        else
        {
            transform.position = earStartPos;
            shaking = false;
        }
        if (shaking)
        {
            timer += Time.deltaTime;
            
            if (timer > 0.05)
            { 
                transform.position = earStartPos + Random.insideUnitCircle * shakeAmount;
                timer = 0;
            }
        }

        
    }
}
