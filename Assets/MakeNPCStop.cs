using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakeNPCStop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC stop")
        {
            GameObject npc = collision.transform.parent.gameObject;
            NPCMovement npcMove = npc.gameObject.GetComponent<NPCMovement>();
            StopSounds stopSounds = GetComponent<StopSounds>();
            npcMove.canMove = false;
            

        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC stop")
        {
            GameObject npc = collision.transform.parent.gameObject;
            NPCMovement npcMove = npc.gameObject.GetComponent<NPCMovement>();
            npcMove.canMove = true;
        }
    }

}
