using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuschChangeSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite huschSprite;
    Sprite normalSprite;
    public MakeHuschSound makeHuschSoundScript;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalSprite = spriteRenderer.sprite;
    }
    private void Update()
    {
        if(makeHuschSoundScript.doesHuschSound == true)
        {
            spriteRenderer.sprite = huschSprite;
        }
        else if (makeHuschSoundScript.doesHuschSound == false)
        {
            spriteRenderer.sprite = normalSprite;
        }
        
    }
}
