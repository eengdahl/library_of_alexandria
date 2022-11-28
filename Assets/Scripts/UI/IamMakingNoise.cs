using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class IamMakingNoise : MonoBehaviour
{
    public float levelOfSound;
    private float timer;
    public NPCMakeNoise npcMakeNoise;
    public float noiseinc = 1;
    public NoiseHandeler noiseHandeler;
    public GameObject self;
    public bool hasBeenAdded;
    private float maxLevelOfSound;


    void Start()
    {
        noiseHandeler = FindObjectOfType<NoiseHandeler>();
        levelOfSound = 0;
        timer = 0;
        npcMakeNoise = GetComponent<NPCMakeNoise>();
        self = this.gameObject;
        hasBeenAdded = false;

        maxLevelOfSound = 5;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1 && npcMakeNoise.makingNosie == true)
        {
            //Should smooth the process later 
            levelOfSound += noiseinc;

            if (levelOfSound > maxLevelOfSound)
            {
                levelOfSound = maxLevelOfSound;
            }

            if (!hasBeenAdded)
            {
                noiseHandeler.IAmMakingNoise(self);
                hasBeenAdded = true;
            }

            timer = 0;


        }

    }
}