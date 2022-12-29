using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliverBooks : MonoBehaviour
{
    public int booksOnTable;
    public SpriteRenderer[] visibleBooksOnTable;
    public bool tableFull;
    public bool tableEmpty;
    public Animator thisAnimator;
    public Animator bellAnimator;
    // Start is called before the first frame update
    void Start()
    {
        booksOnTable = 0;
    }

    public void AddBookToTable(int books)
    {
        booksOnTable = booksOnTable +   books;
        thisAnimator.SetFloat("registrating", booksOnTable);
        bellAnimator.SetBool("Bell",true);
       
        Invoke("BellStop", 0.5f);


        if (books > 0 && !tableFull)
        {
            visibleBooksOnTable[booksOnTable - 1].enabled = true;
            tableEmpty = false;
        }

        else if (books < 0 && !tableEmpty)
        {

            //Disable sprite on books on table when removed
            visibleBooksOnTable[booksOnTable].enabled = false;
            tableFull = false;
        }

        if (booksOnTable == 0)
        {
            tableEmpty = true;
        }


        if (booksOnTable >= 10)
        {
            tableFull = true;

        }
      
    }

    private void BellStop()
    {
        bellAnimator.SetBool("Bell", false);
    }
}

