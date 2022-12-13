using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutuorial_npc_Buddys : MonoBehaviour
{
    public Transform target_Buddys1;
    public Transform target_Buddys11;
    SpriteRenderer red;
    GameObject target_Buddys1_1;

    public Tutuorial_npc_Buddys2 collision_between_buddys2_player;

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
    float timer2;
    // Start is called before the first frame update
    void Start()
    {
        buddy2 = GameObject.FindGameObjectWithTag("Tutorial buddy2");
        buddy2.GetComponent<Tutuorial_npc_Buddys2>();

        target_Buddys1_1 = GameObject.FindGameObjectWithTag("Waypoint npc buddy1");
        target_Buddys1 = target_Buddys1_1.transform;

        audio1_1 = GetComponent<AudioSource>();
        opacity = 0;
        Debug.Log(collision_between_buddys2_player.collision_between_buddy2_player);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (active_1== false)
        {
        transform.position = Vector3.MoveTowards(transform.position, target_Buddys1.position, speed * Time.deltaTime);
        if (timer >= 1 && timer <= 2)
        {   
            audio1_1.Play();
            exclamation_talkbubbel.SetActive(true);
        }
        }
        
        if(collision_between_buddy_player == true && Input.GetKey(KeyCode.Space) == true)
        {
            
            timer2 += Time.deltaTime;

            Debug.Log(timer);
            if (timer >= 0.01)
            {
            exclamation_talkbubbel.SetActive(false);
            audio1_1.Pause();
            Debug.Log(collision_between_buddys2_player.collision_between_buddy2_player);
            }
        }
    }
    //if buddy 1 collidar med player && buddy 2 collidar med player
	//stop adio
	//avaktivera pratbublor
    private void OnTriggerStay2D(Collider2D other)
        {
           if (other.CompareTag ("Player"))
            {
                collision_between_buddy_player = true;
            }
           
        }
    private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag ("Player"))
            {
                collision_between_buddy_player = false;
            }
        }
}
