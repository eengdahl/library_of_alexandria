using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingerSings : MonoBehaviour
{
    NoiseHandeler noiseHandeler;
    float timer;
    private bool hasBeenAdded = false;
    [Header("Noise Settings")]
    public float noiseinc = 1;
    float maxLevelOfSound = 40;
    
    public float levelOfSound;
    void Start()
    {
        noiseHandeler = FindObjectOfType<NoiseHandeler>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2 )
        {
            levelOfSound += noiseinc;
            //Should smooth the process later 

            if (levelOfSound > maxLevelOfSound)
            {

                levelOfSound = maxLevelOfSound;
            }

            if (!hasBeenAdded)
            {
                noiseHandeler.AddSinger(gameObject);
                hasBeenAdded = true;
            }
            timer = 0;
        }
    }
}
