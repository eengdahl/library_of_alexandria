using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_movment_tutorial : MonoBehaviour
{

    bool collidingWithPlayer = false;
    public GameObject StaminaOrb;

    // speech bubble when NPC is mad
    public GameObject deactivate_timer;
    public GameObject exclamation_talkbubbel;
    public GameObject redchild;
    public GameObject pickedNPC;
    public GameObject pickedNPC2;

    /////////////////
    //   UI text   //  
    /////////////////
    public GameObject emergency_text;
    //public GameObject information_about_pick_up_book;
    public GameObject deactivate_information_WASD;
    public GameObject New_Hush_information;
    public GameObject Long_Hush_information;
    public GameObject pick_up_staminaore;

    ///////////////////////
    //  waypoint target  //  
    ///////////////////////

    //waypoint target
    public Transform target1;
    public Transform target2;

    /////////////////
    // is pressed  //  
    /////////////////

    bool W_is_pressed = false;
    bool A_is_pressed = false;
    bool S_is_pressed = false;
    bool D_is_pressed = false;
    bool All_movebuttons_pressed = false;

    //other

    AudioSource audio1;


    public NPCHushedBIgTutorial bigHushedNPC0;
    public NPCHushedBIgTutorial bigHushedNPC1;

    //speed on walk
    float speed = 2;

    float opacity;

    bool walking_is_done = false; //.................................................

    ///////////////
    //   timer   //  
    ///////////////
    float timer;
    float timer2;
    float timerOnTrigger;

    //bool playSound;
    bool if_space_is_presssed = true;
    //the diffrentparts of the tutorial
    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;
    bool active_4 = false;
    bool once = true;

    SpriteRenderer red;

    void Start()
    {
        // deactivate timer
        deactivate_timer.SetActive(false);

        //get sound and child
        audio1 = GetComponent<AudioSource>();
        red = redchild.GetComponent<SpriteRenderer>();
        //exclamation_talkbubbel = exclamation_talkbubbel.GetComponent<GameObject>();

        opacity = 0;
    }

    void Update()
    {
        //looks if the player pressed all movebuttons to continue
        if (Input.GetKeyDown(KeyCode.W))
        {
            W_is_pressed = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            A_is_pressed = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            S_is_pressed = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            D_is_pressed = true;
        }
        if (W_is_pressed == true && A_is_pressed == true && S_is_pressed == true && D_is_pressed == true && walking_is_done == false)
        {
            All_movebuttons_pressed = true;
            walking_is_done = true;
            deactivate_information_WASD.SetActive(false);
        }

        //now have all buttons been pressed and first npc walks in
        if (All_movebuttons_pressed == true && walking_is_done)
        {
            Walk_to_book();
            exclamation_talkbubbel.SetActive(true);

            timer += Time.deltaTime;
            if (timer >= 2 && timer <= 2.1)
            {
                audio1.Play();
                New_Hush_information.SetActive(true);
            }
        }

        //if you collide with player and space pressed
        //npc shuts up and talkbubble disappears
        if (collidingWithPlayer == true && Input.GetKeyDown(KeyCode.Space))
        {
            All_movebuttons_pressed = false;
            audio1.Stop();
            walking_is_done = true;
            exclamation_talkbubbel.SetActive(false);
            New_Hush_information.SetActive(false);
            active_2 = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
        /////////////
        //walks out//
        /////////////

        if (active_2 == true)
        {
            Invoke("Walk_Out", 1.5f); // start function after 1,5 seconds
            if (active_4 == false)
            {
                for (int i = 0; i < 200; i++)
                {
                    Instantiate(StaminaOrb, transform.position, transform.rotation);
                }
            }
            active_4 = true;
            active_3 = true;
        }


        ///////////////////////
        // many npc walks in //
        ///////////////////////
        if (active_3 == true)
        {

            timer2 += Time.deltaTime;
            if (timer2 > 2 && once == true)
            {
                once = false;
                Debug.Log("Enter");
                noiceNPCs();
            }
        }

        /////////////////////
        //start game button//
        /////////////////////
        if (Input.GetKeyDown(KeyCode.K))
        {

            SceneManager.LoadScene("scene_main_preTest");
        }
    }

    //////////////////////////////
    //bool when collide with npc//
    //////////////////////////////
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collidingWithPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collidingWithPlayer = false;
        }
    }

    /////////////////
    //  functions  //  
    /////////////////

    //walking up to the book
    public void Walk_to_book()
    {
        transform.position = Vector3.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
    }
    public void Walk_Out()
    {
        bigHushedNPC0.startWalking = true;
        bigHushedNPC1.startWalking = true;
        transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
    }

    public void noiceNPCs()
    {
        Vector3 temp = new Vector3(0.1f, -5.5f, 0);
        Vector3 temp2 = new Vector3(-0.1f, -5.5f, 0);


        //  Instantiate(pickedNPC, temp, transform.rotation);
        // Instantiate(pickedNPC2, temp2, transform.rotation);

        Long_Hush_information.SetActive(true);
        pick_up_staminaore.SetActive(true);
        active_3 = true;
        //emergency_text.SetActive(true);
    }
}
