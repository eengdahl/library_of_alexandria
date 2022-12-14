using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutuorial_npc_Buddys2 : MonoBehaviour
{
    ///////////////////
    // BeingHusched  //  
    ///////////////////
    public bool beingHusched = false;

     /////////////////
    //   .......   //  
    /////////////////
    public Transform target_Buddys2;
    public Transform target_Buddys22;
    SpriteRenderer red;
    GameObject target_Buddys2_2;
    GameObject target_Buddys2_2goback;

    /////////////////
    //   UI text   //  
    /////////////////
    public GameObject exclamation_talkbubbel;

    public bool collision_between_buddy2_player = false;

    float timerOnTrigger;
    float speed = 2;
    float timer;
    AudioSource audio2_2;
    float opacity;

    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;
    GameObject long_hush_information2;
    bool has_been_hushed = false;

    bool walk_out = false;

    //public Long_hush_information Long_hush_information2;
    // Start is called before the first frame update
    void Start() 
    {
        target_Buddys2_2 = GameObject.FindGameObjectWithTag("Waypoint npc buddy2");
        target_Buddys2 = target_Buddys2_2.transform;

        target_Buddys2_2goback = GameObject.FindGameObjectWithTag("Waypoint npc buddy2goback");
        target_Buddys22= target_Buddys2_2goback.transform;

        long_hush_information2 = GameObject.FindGameObjectWithTag("Long hush information");
      

        audio2_2 = GetComponent<AudioSource>();
        opacity = 0;
        long_hush_information2.SetActive(true);

    }
    void Update()
    {
        
        timer += Time.deltaTime;
        
        if (active_1== false)
        {
        transform.position = Vector3.MoveTowards(transform.position, target_Buddys2.position, speed * Time.deltaTime);
        
        if (timer >= 1 && timer <= 2 && has_been_hushed ==  false)
        {
            audio2_2.Play();
            exclamation_talkbubbel.SetActive(true);
        }
        }
        if (walk_out == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_Buddys22.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Husch")
        {
            audio2_2.Stop();
            has_been_hushed = true;
            exclamation_talkbubbel.SetActive(false);
            active_1 = false;
            walk_out = true;
        }
    }
}