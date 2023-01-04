using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallStoneFadeOut : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    //Higher values = faster Fade Out
    public float fadeSpeed = 1f;
    
    [SerializeField] FadeOut BigStoneFadeOut;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
       
        if (BigStoneFadeOut.fadingOut)
        {
            //Modify the color by changing alpha value
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - (fadeSpeed * Time.deltaTime));

        }
            

        
    }
}
