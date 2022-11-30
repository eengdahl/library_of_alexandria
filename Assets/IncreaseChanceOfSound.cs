using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseChanceOfSound : MonoBehaviour
{

    //10% chans att de bara börjar prata
    NPCClutterCheckerScript clutterScript;
    [SerializeField]NPCMakeNoise npcMakeNoiseScript;
    public float makeSoundChanceNoBooks = 1;
    private void Start()
    {
        clutterScript = GetComponent<NPCClutterCheckerScript>();
    }

    private void Update()
    {
        float booksInArea = clutterScript.booksInArea / 2f;
        npcMakeNoiseScript.chanceOfMakingSound = booksInArea +  makeSoundChanceNoBooks; 
    }
}
