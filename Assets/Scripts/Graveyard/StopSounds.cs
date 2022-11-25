using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSounds : MonoBehaviour
{
    public bool canDoHusch;
    GameObject npc;
    NPCMakeNoise npcSound;
    private void Start()
    {
        canDoHusch = false;
    }

    private void Update()
    {
        if(canDoHusch && Input.GetKey(KeyCode.F)&&npcSound.makingNosie == true)
        {
            Debug.Log("F is pressed and sound should stop");
            npcSound.timer = 0;
            npcSound.makingNosie = false;
            canDoHusch = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.tag == "NPC Sound")
        {
            canDoHusch = true;
            npc = collision.transform.parent.gameObject;
            npcSound = npc.GetComponent<NPCMakeNoise>();
           

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
        npcSound = null;
    }

}
