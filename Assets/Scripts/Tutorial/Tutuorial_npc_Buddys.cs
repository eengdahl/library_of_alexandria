using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutuorial_npc_Buddys : MonoBehaviour
{
    ///////////////////
    // BeingHusched  //  
    ///////////////////
    public bool beingHusched = false;

    /////////////////
    //   .......   //  
    /////////////////
    public Transform target_Buddys1;
    public Transform target_Buddys11;
    SpriteRenderer red;
    GameObject target_Buddys1_1;

    /////////////////
    //   UI text   //  
    /////////////////
    public GameObject exclamation_talkbubbel;

    bool collision_between_buddy_player = false;


    float timerOnTrigger;
    float speed = 2;
    float timer;
    AudioSource audio1_1;
    float opacity;
    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;
    public GameObject buddy2;
    GameObject target_Buddys1_1goback;
    float timer2;

    Tutuorial_npc_Buddys2 budy2;
    MakeHuschSound makeHuschSound;

    public float collisiontimer;
    bool walk_out = false;
    bool has_been_hushed = false;
    // Start is called before the first frame update
    void Start()
    {
        target_Buddys1_1 = GameObject.FindGameObjectWithTag("Waypoint npc buddy1");
        target_Buddys1 = target_Buddys1_1.transform;

        target_Buddys1_1goback = GameObject.FindGameObjectWithTag("Waypoint npc buddygoback");
        target_Buddys11 = target_Buddys1_1goback.transform;

        audio1_1 = GetComponent<AudioSource>();
        opacity = 0;

        budy2 = FindObjectOfType<Tutuorial_npc_Buddys2>();
        makeHuschSound = FindObjectOfType<MakeHuschSound>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (active_1 == false)
        {
   
            transform.position = Vector3.MoveTowards(transform.position, target_Buddys1.position, speed * Time.deltaTime);

            if (timer >= 1 && timer <= 2 && has_been_hushed == false)
            {
                audio1_1.Play();
                exclamation_talkbubbel.SetActive(true);
            }
        }

        if (walk_out == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_Buddys11.position, speed * Time.deltaTime);
        }
    }
    //if buddy 1 collidar med player && buddy 2 collidar med player
    //stop adio
    //avaktivera pratbublor
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Husch" && makeHuschSound.doesHuschSound == true)
        {
            collisiontimer += Time.deltaTime;
           // audio1_1.Stop();
          //  has_been_hushed = true;
           // exclamation_talkbubbel.SetActive(false);
           active_1 = true;
        }

        if (collision.tag == "Husch" && budy2.collisiontimer>0.1f && makeHuschSound.doesHuschSound == true)
        {
            audio1_1.Stop();
            has_been_hushed = true;
            exclamation_talkbubbel.SetActive(false);

            walk_out = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Husch")
        {
            collisiontimer = 0;
        }
    }
}
