using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseChanceOfSound : MonoBehaviour
{

    //10% chans att de bara b�rjar prata
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
         booksInArea = clutterScript.booksInArea; //H�mtar hur m�nga b�cker som finns i NPCns area fr�n clutter scriptet
         NPCsMakingNoiseInArea = otherNPcsScript.numberOfNPCMakingNoise;//H�mtar hur m�nga NPC som g�r ljud ifr�n othernpcMakesoundChecker scriptet
         chanceIncrease = booksInArea + NPCsMakingNoiseInArea; // plussar ihop dessa v�rden till ett

        npcMakeNoiseScript.chanceOfMakingSound = makeSoundChanceNoBooks + chanceIncrease; //plussar ihop den standardiserade chansen att de g�r ljud med chanceIncrease.
    }
}
