using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_book_pick_up : MonoBehaviour
{
    public GameObject colide_with_firstNPC;

    public GameObject activate_information_book_pick_up;
    public GameObject deactivate_information_Long_hush;
    public GameObject Tutorialbook_pop_up;

    float timer;
    float speed = 2;
    bool Go_away = false;
    public Transform target2;
    bool book_is_picked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Go_away == true)
        {
            Walk_Out();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("tutorial first NPC"))
        {
            timer += Time.deltaTime;
     
           // deactivate_information_Long_hush.SetActive(false);
           // activate_information_book_pick_up.SetActive(true);
            //Tutorialbook_pop_up.SetActive(true);
            Go_away = true;

            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tutorial first NPC"))
        {
            Walk_Out();
        }
    }
    public void Walk_Out()
    {
        transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
    }
}
