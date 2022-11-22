using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSounds : MonoBehaviour
{
    public bool husched;

    private void Start()
    {
        husched = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.tag == "NPC Sound")
        {
            GameObject npc = collision.transform.parent.gameObject;
            NPCMakeNoise npcSound = npc.GetComponent<NPCMakeNoise>();           
            npcSound.timer = 0;
            npcSound.makeingNosie = false;
                
            

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "NPC Sound")
        {
            if (Input.GetKeyDown("space"))
            {
                GameObject npc = collision.transform.parent.gameObject;
                NPCMakeNoise npcSound = npc.GetComponent<NPCMakeNoise>();
                npcSound.timer = 0;
                npcSound.makeingNosie = false;
            }

        }
    }

}
