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
    public GameObject target_Buddys2_2goback;
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
    public GameObject book;
    Image bookspartImage;

    GameObject findbook;
    Image findbookimage;

    GameObject stophush;
    GameObject stophushobject;

    GameObject arrow_at_book;
    SpriteRenderer arrow_at_bookImage;

    public float collisiontimer;

    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;
    bool has_been_hushed = false;

    bool walk_out = false;

    private bool pop_up_one_book = false;

    bool bookSpawnedChecker = false;
    float timer2;
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


        makeHuschSound = FindObjectOfType<MakeHuschSound>();
        Invoke("FindBuddy", 0.01f);
    }

    private void FindBuddy()
    {
        budy1 = FindObjectOfType<Tutuorial_npc_Buddys>();

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
            Debug.Log("UT2");
            transform.position = Vector3.MoveTowards(transform.position, target_Buddys22.position, speed * Time.deltaTime);
            if (transform.position == target_Buddys22.position)
            {
                walk_out = false;
                pop_up_one_book = true;
            }

        }
        if (pop_up_one_book == true && bookSpawnedChecker == false)
        {

            // walk_out = false;
            Vector3 temp = new Vector3(7.4f, 0f, 0);
            Instantiate(book, temp, transform.rotation);

            timer2 = 0;
            bookSpawnedChecker = true;
            pop_up_one_book = false;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            collisiontimer = 0;
        }

        //Debug.Log(collisiontimer);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.tag == "Husch" /* && makeHuschSound.doesHuschSound == true  */&& Input.GetKey(KeyCode.Space))
        {
            //audio2_2.Stop();
            //has_been_hushed = true;
            //exclamation_talkbubbel.SetActive(false);
            collisiontimer += Time.deltaTime;
            Debug.Log("timerstart");
            active_1 = true;

        }

        if  (collision.tag == "Husch" &&  budy1.collisiontimer > 2f && Input.GetKeyUp(KeyCode.Space)/* && makeHuschSound.doesHuschSound == true */)
        {
            Debug.Log("timer end..............................");
            walk_out = true;
            collisiontimer += Time.deltaTime;
            audio2_2.Stop();
            has_been_hushed = true;
            exclamation_talkbubbel.SetActive(false);
            //  active_1 = false;
            //Tutorialbook_pop_up.SetActive(true);

            //Tutorialbook_pop_up.SetActive(true);
            //long_hush_information2.SetActive(false);
            // Tutorialbook_pop_up = GameObject.FindGameObjectWithTag("Book_pick_up_information");
            // bookspart = GameObject.FindGameObjectWithTag("KAOSBOK");
            bookspart = GameObject.FindGameObjectWithTag("KAOSBOK");
            bookspartImage = bookspart.GetComponent<Image>();
            bookspartImage.enabled = true;

            //stophush = GameObject.FindGameObjectWithTag("Husch");
            //stophushobject = stophush.GetComponent<GameObject>();
            //stophush.SetActive(false);

            //findbook = GameObject.FindGameObjectWithTag("Book White");
            //findbookimage = bookspart.GetComponent<Image>();
            //findbook.SetActive(true); 
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "husch" && makeHuschSound.doesHuschSound == false)
        {
            collisiontimer = 0;
        }
    }
}