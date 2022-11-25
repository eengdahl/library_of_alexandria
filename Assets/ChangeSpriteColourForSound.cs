using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColourForSound : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    NPCMakeNoise npcMakeNoiseScript;
    // Start is called before the first frame update
    void Start()
    {
        npcMakeNoiseScript = GetComponent<NPCMakeNoise>();
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (npcMakeNoiseScript.makingNosie == true)
        {
            
            spriteRenderer.color = new Color(200, 0, 0, 255);
        }
        if (npcMakeNoiseScript.makingNosie == false)
        {
           
            spriteRenderer.color = new Color(255, 255, 255, 255);
        }
    }
}
