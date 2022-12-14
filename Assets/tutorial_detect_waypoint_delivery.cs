using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_detect_waypoint_delivery : MonoBehaviour
{
    public GameObject Leave_at_desk_information;
    public GameObject set_books_in_bookshelf_information;
    public GameObject red_bookshelf;

    public GameObject End_of_tutorial_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag ("Waypoint deliver"))
        {
           Leave_at_desk_information.SetActive(false);
           set_books_in_bookshelf_information.SetActive(true);
           red_bookshelf.SetActive(true);
        }
        if (other.CompareTag ("tutorial red bookshelf1"))
        {
           set_books_in_bookshelf_information.SetActive(false);
           End_of_tutorial_text.SetActive(true);
        }
    }

}
