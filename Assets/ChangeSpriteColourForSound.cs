using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColourForSound : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    NPCMakeNoise npcMakeNoiseScript;

    IamMakingNoise iamMakingNoiseScript;
    // Start is called before the first frame update
    void Start()
    {
        npcMakeNoiseScript = GetComponent<NPCMakeNoise>();
 
        iamMakingNoiseScript = GetComponent<IamMakingNoise>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcMakeNoiseScript.makingNosie == true)
        {
            
            spriteRenderer.color = new Color(1, 0, 0, iamMakingNoiseScript.levelOfSound / 20);
        }
        if (npcMakeNoiseScript.makingNosie == false)
        {
           
            spriteRenderer.color = new Color(255, 255, 255, 255);
        }
    }
}
