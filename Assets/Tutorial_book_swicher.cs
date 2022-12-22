using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_book_swicher : MonoBehaviour
{
    public int i = 1;
    public GameObject [] books;
    public GameObject start_continue_button;
     Animator m_Animator;

    void Start() 
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
         if (Input.GetKeyDown("space"))
        {
            books[i].SetActive(true);
            i=i +2;

        }
        if (i >= books.Length-1)
        {
            start_continue_button.SetActive(true);
        } 
        
    }

    void disableanimation()
    {
        i ++;
        m_Animator.enabled=false;
        books[i].SetActive(true);
        Debug.Log(i);
    }
    void nextbook()
    {
        //books[i].SetActive(true);
    }
}
