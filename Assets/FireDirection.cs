using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDirection : MonoBehaviour
{
    Animator fireAnimator;
    Animator sootAnimator;
    SpriteRenderer fireSprite;
    SpriteRenderer sootSprite;
     float speedMove = 0.005f;
    public Vector3 spotMoveTowards;
    public bool shouldMove = false;
    private void Update()
    {
        if (shouldMove)
        {
       
        transform.position = Vector3.MoveTowards(transform.position, spotMoveTowards,speedMove);
        }
    }
}
