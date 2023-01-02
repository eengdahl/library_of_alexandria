using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeOutWhenY : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //Will start the fade out after value (in seconds)
    public float timeToStartFading = 0f;
    //Higher values = faster Fade Out
    public float fadeSpeed = 1f;
    //LandingSpot
    [SerializeField] GameObject landingSpot;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (transform.position.y == landingSpot.transform.position.y)
        {
            //Timer
            if (timeToStartFading > 0)
            {
                timeToStartFading -= Time.deltaTime;
                return;
            }

            //Modify the color by changing alpha value
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - (fadeSpeed * Time.deltaTime));
        }
    }
}