using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutWhiteBookPickUp : MonoBehaviour
{
    //Book animator
    [Header("Book Animator")]
    [SerializeField] Animator bookAnimator;
    bool havePickedUpBookWhite = false;
    [SerializeField] GameObject tutorialInstructionBook;

    //Arrows
    [Header("Arrows")]
    public GameObject ArrowBookRenderer_false;
    public GameObject stopstart_Arrowreception;

    //GameObjects
    [Header("Other GameObjects")]
    [SerializeField] GameObject Waypoint_deliver;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Book White"))
        {
            //Animator book
            if (!havePickedUpBookWhite)
            {
                bookAnimator.SetBool("GoToWhiteBook", false);
                bookAnimator.SetBool("TurnPage", true);
                havePickedUpBookWhite = true;
            }
            stopstart_Arrowreception.SetActive(true);
            ArrowBookRenderer_false.SetActive(false);
            Waypoint_deliver.SetActive(true);
        }
    }
}
