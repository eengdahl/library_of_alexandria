using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoolFunctions : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GoToSpace()
    {
        animator.SetBool("TurnPage", false);
        animator.SetBool("GoToSpace",true);
    }
    void GoToBigSpace()
    {
        animator.SetBool("TurnPage", false);
        animator.SetBool("GoToBigSpace", true);
    }
    void GoToWhiteBook()
    {
        animator.SetBool("TurnPage", false);
        animator.SetBool("GoToWhiteBook", true);
    }
    void GoToDesk()
    {
        animator.SetBool("TurnPage", false);
        animator.SetBool("GoToDesk", true);
    }
    void TakeColouredBook()
    {
        animator.SetBool("TurnPage", false);
        animator.SetBool("TakeColouredBook", true);
    }
    void ReturnColouredBook()
    {
        animator.SetBool("TurnPage", false);
        animator.SetBool("ReturnColouredBook", true);
    }
}
