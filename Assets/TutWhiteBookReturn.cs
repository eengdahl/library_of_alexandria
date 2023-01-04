using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutWhiteBookReturn : MonoBehaviour
{
    [SerializeField] Animator bookAnimator;
    bool pageHasBeenShowed = false;
    [Header("GameObjects")]
    [SerializeField] GameObject red_bookshelf;
    [SerializeField] GameObject start_can_hush;
    [Header("Arrows")]
    [SerializeField] GameObject stopstart_Arrowreception;
    [SerializeField] AnimationBoolFunctions boolFunctions;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Waypoint deliver"))
        {
            //Tutorial animation
            if (!pageHasBeenShowed)
            {
                bookAnimator.SetBool("GoToWhiteBook", false);
                bookAnimator.SetBool("TurnPage", true);
                boolFunctions.TurnPageSound();
                pageHasBeenShowed = true;
            stopstart_Arrowreception.SetActive(false);
            }
            //start_can_hush.SetActive(true);
            red_bookshelf.SetActive(true);
            //Waypoint_deliver.SetActive(false);
        }
    }
}
