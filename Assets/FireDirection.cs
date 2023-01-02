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
    [SerializeField] FireHusched fireHuschedScript;
    [SerializeField] GameObject soot;

    private void Update()
    {


        if (shouldMove)
        {
            if (fireSprite != null)
            {
                fireSprite.enabled = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, spotMoveTowards, speedMove);
            if (transform.position == spotMoveTowards)
            {
                
                fireSprite.enabled = true;
                shouldMove = false;
            }
            else if (transform.position != spotMoveTowards)
            {
                Debug.Log("Shouldnt be able to husch fire now");
                
                sootSprite.enabled = false;
            }
        }

    }
}
