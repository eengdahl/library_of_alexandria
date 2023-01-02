using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnArrow : MonoBehaviour
{
    [SerializeField]SingerMovement singerMovement;
    SpriteRenderer arrowSprite;
    // Start is called before the first frame update
    void Start()
    {
        arrowSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Flipp the arrow dependding on target
        if (singerMovement.walkingIn && arrowSprite.flipX == true)
        {

            arrowSprite.flipX = false;

        }
        else if (!singerMovement.walkingIn && arrowSprite.flipX == false)
        {
            arrowSprite.flipX = true;
        }
        //Remove the  arrow if at singing spot
        if (singerMovement.atSingingSpot)
        {
            arrowSprite.enabled = false;
        }
        else
        {
            arrowSprite.enabled = true;
        }


    }

 
}
