using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseChanceOfSound : MonoBehaviour
{

    //10% chans att de bara börjar prata
    public OtherNPCMakeSoundChecker otherNPcsScript;
    NPCClutterCheckerScript clutterScript;
    [SerializeField]NPCMakeNoise npcMakeNoiseScript;
    public float makeSoundChanceNoBooks = 3;

    float booksInArea;
    float NPCsMakingNoiseInArea;
    float chanceIncrease;
    private void Start()
    {
        clutterScript = GetComponent<NPCClutterCheckerScript>();
    }

    private void Update()
    {
         booksInArea = clutterScript.booksInArea; //Hämtar hur många böcker som finns i NPCns area från clutter scriptet
         NPCsMakingNoiseInArea = otherNPcsScript.numberOfNPCMakingNoise;//Hämtar hur många NPC som gör ljud ifrån othernpcMakesoundChecker scriptet
         chanceIncrease = booksInArea + NPCsMakingNoiseInArea; // plussar ihop dessa värden till ett

        npcMakeNoiseScript.chanceOfMakingSound = makeSoundChanceNoBooks + chanceIncrease; //plussar ihop den standardiserade chansen att de gör ljud med chanceIncrease.
    }
}
