using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingHusched : MonoBehaviour
{
    //Should be placed on huschZone on NPCs
    public bool beingHusched = false;
    NPCMakeNoise npcMakeNoise;
    NPCMovement npcMovement;
    MakeHuschSound makeHuschSound;
    [SerializeField] IamMakingNoise iMakeNoise;
    private void Start()
    {
        makeHuschSound = FindObjectOfType<MakeHuschSound>();
        //npcMovement = GetComponent<NPCMovement>();
        npcMakeNoise = GetComponentInParent<NPCMakeNoise>();
        npcMovement = GetComponentInParent<NPCMovement>();
        //iMakeNoise = GetComponent<IamMakingNoise>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        //If NPC is colliding with "Husch" and the players doesHuschSound is active stop movement and sound.
        if (collision.tag == "Husch" && makeHuschSound.doesHuschSound == true)
        {
            //Stop noise;
            npcMakeNoise.timer = 0; // Reset timer in npcMakeNoise so it doesnt start makeing nosie right after being husched
            npcMakeNoise.makingNosie = false;//Set the makeing noise in npc to false, with other words is silent
            //Stop momvement of NPC
            if (!npcMovement.hasChair)
            {
                npcMovement.canMove = false;
            }
            

            iMakeNoise.levelOfSound = 0;
        }




    }
}
