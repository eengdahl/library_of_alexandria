using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchChanger : MonoBehaviour
{
    AudioSource audioSource;
    NoiseHandeler noiseHandler;
    private void Awake()
    {
        noiseHandler = FindObjectOfType<NoiseHandeler>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //200 noise max
        if(noiseHandler.noiseSlider.value < 60) //Under "80" eller valfritt värde noise i rummet ha denna pitch
        {
            audioSource.pitch = 1;
        }
        else if (noiseHandler.noiseSlider.value > 60 && noiseHandler.noiseSlider.value < 120) //mellan 80 och 120 ha denna pitch
        {
            audioSource.pitch = 1.2f;
        }
        //else if (noiseHandler.noiseSlider.value > 60 && noiseHandler.noiseSlider.value < 160)
        //{
        //    audioSource.pitch = 1.4f;
        //}
        //else if (noiseHandler.noiseSlider.value > 160)
        //{
        //    audioSource.pitch = 1.7f;
        //}
        
    }
}
