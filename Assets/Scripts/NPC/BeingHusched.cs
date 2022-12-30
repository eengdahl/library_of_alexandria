using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeingHusched : MonoBehaviour
{


    [SerializeField]NPCMovement NPCMovementScript;
    //Should be placed on huschZone on NPCs
    public bool beingHusched = false;
    NPCMakeNoise npcMakeNoise;
    NPCMovement npcMovement;
    MakeHuschSound makeHuschSound;
    [SerializeField] IamMakingNoise iMakeNoise;
    public Animator myAnimator;

    private void Start()
    {
        makeHuschSound = FindObjectOfType<MakeHuschSound>();
        //npcMovement = GetComponent<NPCMovement>();
        npcMakeNoise = GetComponentInParent<NPCMakeNoise>();
        npcMovement = GetComponentInParent<NPCMovement>();
        //iMakeNoise = GetComponent<IamMakingNoise>();
        myAnimator = GetComponentInParent<Animator>();


    }
    private void Update()
    {
        if (npcMakeNoise.makingNosie == false)
        {
            beingHusched = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        //If NPC is colliding with "Husch" and the players doesHuschSound is active stop movement and sound.
        //npc does not stop if its not making noise
        if (collision.tag == "Husch" && makeHuschSound.doesHuschSound == true && npcMakeNoise.makingNosie)
        {
            //Stop noise;
            npcMakeNoise.timer = 0; // Reset timer in npcMakeNoise so it doesnt start makeing nosie right after being husched
            npcMakeNoise.makingNosie = false;//Set the makeing noise in npc to false, with other words is silent
            npcMakeNoise.chanceOfMakingSound = 0;
            //Timer for when npc can make noise again
            npcMakeNoise.timerAfterBeingHusched = 0;

            //Stop momvement of NPC
            npcMovement.canMove = false;

            beingHusched = true;
            iMakeNoise.levelOfSound = 0;
            myAnimator.SetBool("burning", false);
            NPCMovementScript.OnFire = false;
        }

        if (collision.tag == "Fire")
        {
            if (Random.Range(0, 60) == 0)
            {
                Debug.Log("ping");
                NPCMovementScript.OnFire = true;
                myAnimator.SetBool("burning", true);
                npcMakeNoise.makingNosie = true;
            }
        }
    }




}
