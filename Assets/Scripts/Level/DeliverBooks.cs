using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliverBooks : MonoBehaviour
{
    public int booksOnTable;
    public Image[] visibleBooksOnTable;
    public bool tableFull;
    public bool tableEmpty;
    // Start is called before the first frame update
    void Start()
    {
        booksOnTable = 0;
    }

    public void AddBookToTable(int books)
    {
        booksOnTable = booksOnTable +   books;

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
}


//for (int i = 0; i <= books; i++)
//{
//    booksOnTable++;
//    if (books > 0 && !tableFull)
//    {
//        ////Turning sprite on on books on table
//        //for (int j = 0; j <= i; j++)
//        //{
//            visibleBooksOnTable[booksOnTable - 1].enabled = true;
//       // }
//    }

//    else if (books < 0)
//    {
//        ////Disable sprite on books on table when removed
//        //for (int k = 0; k <= Mathf.Abs(books); k++)
//        //{
//            visibleBooksOnTable[booksOnTable - 1].enabled = false;
//            tableFull = false;
//        //}
//    }
//}


//if (booksOnTable >= 10)
//{
//    tableFull = true;

//}