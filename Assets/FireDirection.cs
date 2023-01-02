using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDirection : MonoBehaviour
{
    //[SerializeField]Animator fireAnimator;
    //[SerializeField]Animator sootAnimator;
    [SerializeField] SpriteRenderer fireSprite;
    [SerializeField] SpriteRenderer sootSprite;
    float speedMove = 0.005f;
    public Vector3 spotMoveTowards;
    public bool shouldMove = false;


    private void Update()
    {
        if (shouldMove)
        {
            fireSprite.enabled = false;
            sootSprite.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, spotMoveTowards, speedMove);
        }
        else
        {
            //fireSprite.enabled = true;
            //sootSprite.enabled = true;
        }
    }
}
