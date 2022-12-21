using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_book_swicher : MonoBehaviour
{
    int i = 0;
    public GameObject [] books;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            books[i].SetActive(true);
            i += 1;
        }
    }
}
