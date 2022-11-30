using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherNPCMakeSoundChecker : MonoBehaviour
{
    public List<GameObject> listOfNPCs;
    public int numberOfNPCMakingNoise;
    int numberOfNPCMakingNoiseBuffer;
    NPCMakeNoise thisNpcMakeNoise;
    private void Start()
    {
        thisNpcMakeNoise = GetComponentInParent<NPCMakeNoise>();
    }

    private void Update()
    {
        numberOfNPCMakingNoiseBuffer = 0;
        for (int i = 0; i < listOfNPCs.Count; i++)
        {
            
            NPCMakeNoise npcMakeNoise = listOfNPCs[i].GetComponentInParent<NPCMakeNoise>();
            if (npcMakeNoise.makingNosie == true)
            {

                numberOfNPCMakingNoiseBuffer += 1;
            }
            
        }
        numberOfNPCMakingNoise = numberOfNPCMakingNoiseBuffer;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "OtherNPCmakeSoundChecker")
        {
            listOfNPCs.Add(collision.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "OtherNPCmakeSoundChecker")
        {
            listOfNPCs.Remove(collision.gameObject);
        }
        
    }
}
