using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsAroundHead : MonoBehaviour
{

    [SerializeField]HitByStone hitByStoneScript;
    Animator thisAnimator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitByStoneScript.stoned)
        {
            thisAnimator.enabled = true;
            spriteRenderer.enabled = true;
        }
        else
        {
            thisAnimator.enabled = false;
            spriteRenderer.enabled = false;
        }
    }
}
