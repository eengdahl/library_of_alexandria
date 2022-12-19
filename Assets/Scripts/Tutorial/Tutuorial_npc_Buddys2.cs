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
    GameObject activate_information_book_pick_up;

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

    Tutuorial_npc_Buddys budy1;
    MakeHuschSound makeHuschSound;

    GameObject long_hush_information2;
    GameObject Tutorialbook_pop_up;
    GameObject bookspart;
    Image bookspartImage;

    GameObject findbook;
    Image findbookimage;

    public float collisiontimer;

    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;
    bool has_been_hushed = false;

    bool walk_out = false;
    private void Awake()
    {
    }
    //public Long_hush_information Long_hush_information2;
    // Start is called before the first frame update
    void Start()
    {

        target_Buddys2_2 = GameObject.FindGameObjectWithTag("Waypoint npc buddy2");
        target_Buddys2 = target_Buddys2_2.transform;

        target_Buddys2_2goback = GameObject.FindGameObjectWithTag("Waypoint npc buddy2goback");
        target_Buddys22 = target_Buddys2_2goback.transform;

        long_hush_information2 = GameObject.FindGameObjectWithTag("Long hush information");
        long_hush_information2.SetActive(true);

        budy1 = FindObjectOfType<Tutuorial_npc_Buddys>();
        makeHuschSound = FindObjectOfType<MakeHuschSound>();


        audio2_2 = GetComponent<AudioSource>();
        opacity = 0;

        //activate_information_book_pick_up = GameObject.FindGameObjectWithTag("Long hush information");
        //activate_information_book_pick_up.SetActive(true);

        // Tutorialbook_pop_up = GameObject.FindGameObjectWithTag("Book_pick_up_information");



    }
    void Update()
    {

        timer += Time.deltaTime;

        if (active_1 == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_Buddys2.position, speed * Time.deltaTime);


            if (timer >= 1 && timer <= 2 && has_been_hushed == false)
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
        if (collision.tag == "Husch" && makeHuschSound.doesHuschSound == true)
        {
            //audio2_2.Stop();
            //has_been_hushed = true;
            //exclamation_talkbubbel.SetActive(false);
            collisiontimer += Time.deltaTime;
            active_1 = true;



            if (collision.tag == "Husch" && budy1.collisiontimer > 0.01f && makeHuschSound.doesHuschSound == true)
            {
                audio2_2.Stop();
                has_been_hushed = true;
                exclamation_talkbubbel.SetActive(false);
                //  active_1 = false;
                walk_out = true;
                Tutorialbook_pop_up.SetActive(true);
                
                //Tutorialbook_pop_up.SetActive(true);
                //long_hush_information2.SetActive(false);
                // Tutorialbook_pop_up = GameObject.FindGameObjectWithTag("Book_pick_up_information");
                // bookspart = GameObject.FindGameObjectWithTag("KAOSBOK");
                bookspart = GameObject.FindGameObjectWithTag("KAOSBOK");
                bookspartImage = bookspart.GetComponent<Image>();
                //Tutorialbook_pop_up.SetActive(true);
                bookspartImage.enabled = true;
            }
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