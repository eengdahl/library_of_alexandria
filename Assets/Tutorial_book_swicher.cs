using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_book_swicher : MonoBehaviour
{
    int i = 0;
    public GameObject [] books;
    public GameObject start_continue_button;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            books[i].SetActive(true);
            i += 1;
        }
        if (i == books.Length-1)
        {
            start_continue_button.SetActive(true);
        }
    }
}
