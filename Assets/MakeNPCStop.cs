using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakeNPCStop : MonoBehaviour
{
    GameObject npc;
    NPCMovement npcMove;
    StopSounds stopSounds;
    NPCMakeNoise npcNoise;
    
    public bool canStopToHusch = false;
    float stopTimer = 0;
    public float stopTimerMax = 2;
   
    private void Update()
    {
        if (npcMove != null)
        {
            
            if (canStopToHusch && Input.GetKey(KeyCode.F)) //&& npcNoise.makeingNosie == true
            {
                Debug.Log("Should STOP NPC");
                npcMove.canMove = false;             
            }
            if (npcMove.canMove == false)
            {
                stopTimer += Time.deltaTime;
                if (stopTimer > stopTimerMax)
                {
                    stopTimer = 0;
                    npcMove.canMove = true;
                    canStopToHusch = false;
                }
            }
        }           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC stop")
        {
            npc = collision.transform.parent.gameObject;
            npcMove = npc.gameObject.GetComponent<NPCMovement>();
            stopSounds = GetComponent<StopSounds>();
            canStopToHusch = true;
            npcNoise = npc.gameObject.GetComponent<NPCMakeNoise>();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC stop")
        {
            npc = null;
            npcMove.canMove = true;
            npcMove = null;
        }
    }

}
