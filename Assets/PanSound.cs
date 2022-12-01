using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanSound : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.panStereo = transform.position.x / 10;
    }
}
