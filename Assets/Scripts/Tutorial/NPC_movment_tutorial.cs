using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_movment_tutorial : MonoBehaviour
{
    // speech bubble when NPC is mad
    public GameObject Mad_NPC_text;

    public GameObject information_about_pick_up_book;

    public GameObject redchild;
    public GameObject pickedNPC;
    public GameObject pickedNPC2;

    public GameObject emergency_text;

    //waypoint target
    public Transform target1;
    public Transform target2;

    AudioSource audio1;

    //speed on walk
    float speed = 2;

    float opacity;
    float timer;
    float timer2;
    float timerOnTrigger;
    bool if_space_is_presssed = true;
    //bool playSound;

    //the diffrentparts of the tutorial
    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;

    bool walkout = false;

    SpriteRenderer red;

    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        red = redchild.GetComponent<SpriteRenderer>();
        opacity = 0;
    }

    void Update()
    {
        //walk to book and activates spechbubbel and sound
        timer += Time.deltaTime;

        if (active_1 == false)
        {
            Walk_to_book();
            activate_spechbubbel_madNPC();
            activate_sound_and_spechbubbel_pickup_book();
        }


        //npc walk out
        walkout = true;
        if (active_2 == false && timer >= 18 && walkout == false)
        {
            Debug.Log(timer);
            Walk_out();
            emergency_text.SetActive(true);
            walkout = true;
        }
        //many npc walks in
        if (active_3 == false && timer >= 30)
        {
            if (active_3 == false && walkout == true)
            {
                //noiceNPCs();
            }
            if (timer >= 25)
            {
                Walk_to_book();

            }
            if (timer >= 28)//Ändrat från 35
            {
                Mad_NPC_text.SetActive(false);
                information_about_pick_up_book.SetActive(false);
                emergency_text.SetActive(true);
            }
        }

        //fixa bool som görs i uppdate som gör att när vi klickar space spelas heal funktionen.
        if (Input.GetKeyUp("space"))
        {
            timer2 += Time.deltaTime;
            if_space_is_presssed = true;
            if (timer2 >= 10 && timer2 < 15)
            {
                Mad_NPC_text.SetActive(false);
                information_about_pick_up_book.SetActive(false);
                Walk_out();
                walkout = true;
            }
            if_space_is_presssed = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Enter");
            SceneManager.LoadScene("scene_main_preTest");
        }
    }

    //when npc colides with book
    private void OnTriggerStay2D(Collider2D other)
    {
        timerOnTrigger += Time.deltaTime;
        if (other.tag == ("Book White") && opacity <= 0.75f)
        {
            opacity = timerOnTrigger / 10;
            red.color = new Color(1, 0, 0, opacity);
        }
    }

    //when player pick upp books NPC stops making noice and being
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == ("Book White"))
        {
            opacity = 0;
            red.color = new Color(1, 0, 0, opacity);
            audio1.Stop();
            Mad_NPC_text.SetActive(false);
            information_about_pick_up_book.SetActive(false);
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
    public void Walk_out()
    {
        transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);

        if (timer >= 25)
        {
            active_2 = true;
        }
    }

    public void noiceNPCs()
    {
        Vector3 temp = new Vector3(0.3f, -9.4f, 0);
        Vector3 temp2 = new Vector3(-0.2f, -9.4f, 0);

        Instantiate(pickedNPC, temp, transform.rotation);
        Instantiate(pickedNPC2, temp2, transform.rotation);
        active_3 = true;
        emergency_text.SetActive(true);
    }
}
