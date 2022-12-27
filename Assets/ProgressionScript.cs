using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressionScript : MonoBehaviour
{
    public Animator animator;
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   

    public void ActivateProgression()
    {
        spriteRenderer.enabled = true;
        //animator set bool new level

    }
}
