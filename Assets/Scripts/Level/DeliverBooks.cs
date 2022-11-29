using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverBooks : MonoBehaviour
{
    public int booksOnTable;
    // Start is called before the first frame update
    void Start()
    {
        booksOnTable = 0;
    }

    public void AddBookToTable(int books)
    {
        booksOnTable += books;
    }
}
