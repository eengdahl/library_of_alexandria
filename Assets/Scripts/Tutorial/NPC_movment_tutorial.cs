using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_movment_tutorial : MonoBehaviour
{

    bool collidingWithPlayer = true;
    
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
    public GameObject information_about_pick_up_book;
    public GameObject Mad_NPC_text;
    public GameObject deactivate_information_WASD;
    public GameObject New_Hush_information;
    public GameObject Long_Hush_information;

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
        if (  W_is_pressed == true && A_is_pressed == true && S_is_pressed == true && D_is_pressed == true && walking_is_done == false)
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
            Debug.Log("hello");
            All_movebuttons_pressed = false;
            audio1.Stop(); 
            walking_is_done = true;
            exclamation_talkbubbel.SetActive(false);
            New_Hush_information.SetActive(false);
            active_2 = true;
        }
       /*  if (Input.GetKey(KeyCode.Space))
        { 
            
        } */
            /////////////
            //walks out//
            /////////////

            if (active_2 == true)
            {
                Invoke("Walk_Out", 1.5f); // start function after 1,5 seconds
                active_3 =true;
            }
        
        
            ///////////////////////
            // many npc walks in //
            ///////////////////////
        if (active_3 == true)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 2 && timer2 <= 2.01)
            {
            noiceNPCs();
            }
        }

            /////////////////////
            //start game button//
            /////////////////////
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Enter");
            SceneManager.LoadScene("scene_main_preTest");
        }
    }

            //////////////////////////////
            //bool when collide with npc//
            //////////////////////////////
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag ("Player"))
        {
                collidingWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {   
        if (other.CompareTag ("Player"))
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
        transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
    }

    //activates spechbubbel
    public void activate_spechbubbel_madNPC()
    {
        if (transform.position == target1.position)
        {
            Mad_NPC_text.SetActive(true);
        }
    }

    //playSound when npc is in front of the book
    public void activate_sound_and_spechbubbel_pickup_book()
    {
        if (timer >= 2 && timer < 2.1f)
        {
            //playSound = true;
            audio1.Play();

        }
        if (timer >= 6)
        {
            information_about_pick_up_book.SetActive(true);
            active_1 = true;

        }
    }
    /* public void Walk_out()
    {
        transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);

        if (timer >= 25)
        {
            active_2 = true;
        }
    } */

    public void noiceNPCs()
    {
        Vector3 temp = new Vector3(0.3f, -9.4f, 0);
        Vector3 temp2 = new Vector3(-0.2f, -9.4f, 0);

        Instantiate(pickedNPC, temp, transform.rotation);
        Instantiate(pickedNPC2, temp2, transform.rotation);
        Long_Hush_information.SetActive(true);
        active_3 = true;
        //emergency_text.SetActive(true);
    }


}
