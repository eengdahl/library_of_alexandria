using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLevelAS : MonoBehaviour
{
    AudioSource audioSource;
    IamMakingNoise iAmMakingNoise;
    public float noiseLevel;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        iAmMakingNoise = GetComponent<IamMakingNoise>();
    }

    private void Update()
    {
        if (noiseLevel / 20f < 1)
        {
            noiseLevel = iAmMakingNoise.levelOfSound / 100;
        }
        else if (noiseLevel / 20f > 1)
        {
            noiseLevel = 1;
        }
        audioSource.volume = noiseLevel;
    }
}
