using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpriteFlip : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        float randomNumber = Random.Range(1, 3);
        if(randomNumber == 1)
        {
        spriteRenderer.flipX = true;
        }
    }


}
