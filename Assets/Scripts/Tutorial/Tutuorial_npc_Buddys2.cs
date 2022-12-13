using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutuorial_npc_Buddys2 : MonoBehaviour
{
    public Transform target_Buddys2;
    public Transform target_Buddys22;
    SpriteRenderer red;
    GameObject target_Buddys2_2;

    /////////////////
    //   UI text   //  
    /////////////////
    //public GameObject Long_hush_information;
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

    //public Long_hush_information Long_hush_information2;
    // Start is called before the first frame update
    void Start() 
    {
        target_Buddys2_2 = GameObject.FindGameObjectWithTag("Waypoint npc buddy2");
        target_Buddys2 = target_Buddys2_2.transform;

        long_hush_information2 = GameObject.FindGameObjectWithTag("Long hush information");
      

        audio2_2 = GetComponent<AudioSource>();
        opacity = 0;
        long_hush_information2.SetActive(true);

    }
        

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        
        if (active_1== false)
        {
        transform.position = Vector3.MoveTowards(transform.position, target_Buddys2.position, speed * Time.deltaTime);
        if (timer >= 1 && timer <= 2)
        {
            audio2_2.Play();
        exclamation_talkbubbel.SetActive(true);
        }
        }

       if(collision_between_buddy2_player == true && Input.GetKeyDown(KeyCode.Space) == true)
        {
            exclamation_talkbubbel.SetActive(false);
            audio2_2.Pause();
        }


    }
    private void OnTriggerStay2D(Collider2D other)
        {
           if (other.CompareTag ("Player"))
            {
                collision_between_buddy2_player = true;
            }
           
        }
    private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag ("Player"))
            {
                collision_between_buddy2_player = false;
            }
        }
}
