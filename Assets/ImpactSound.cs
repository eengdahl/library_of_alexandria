using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    bool playFirstSound = true;
    bool playSecondSound = false;
    [Header("Transforms")]
    [SerializeField] Transform bounceSpot;
    [SerializeField] Transform landingSpot;
    [Header("Sounds")]
    [SerializeField] AudioClip firstImpactSound;
    [SerializeField] AudioClip secondImpactSound;
    AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (playFirstSound && transform.position == landingSpot.position)
        {
            aS.PlayOneShot(firstImpactSound, 0.1f);
            playFirstSound = false;
        }

        if (!playFirstSound && transform.position == bounceSpot.position)
        {
            playSecondSound = true;
        }
        if (playSecondSound && transform.position == landingSpot.position)
        {
          //  aS.PlayOneShot(secondImpactSound, 0.25f);
            playSecondSound = false;
        }

    }

}
