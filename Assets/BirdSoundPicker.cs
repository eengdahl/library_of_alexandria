using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSoundPicker : MonoBehaviour
{
    public AudioClip[] birdNoices;
    public AudioSource aS;
    int i = 0;
    // Start is called before the first frame update
    void Awake()
    {
        aS = GetComponent<AudioSource>();
        Invoke("NextBirdSound", aS.clip.length);
    }


    public void NextBirdSound()
    {
        if (i == birdNoices.Length - 1)
        {
            i = 0;
        }
        aS.Stop();
        aS.clip = birdNoices[i];
        aS.Play();
        Invoke("NextBirdSound", aS.clip.length);
        i++;

    }
}
