using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_movment_tutorial : MonoBehaviour
{
    // speech bubble when NPC is mad
    public GameObject Mad_NPC_text;

    public GameObject information_about_pick_up_book;

    public GameObject redchild;
    public GameObject pickedNPC;

    //waypoint target
    public Transform target1;
    public Transform target2;

    AudioSource audio1;

    //speed on walk
    float speed = 2;

    float opacity;
    float timer;
    float timerOnTrigger;
    //bool playSound;
    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;

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
                Debug.Log(timer);
            }
            
            //npc walk out
            if (active_2 == false && timer >= 15)
            {   
                Debug.Log(timer);
                Walk_out();
            }
            //many npc walks in
            if (active_3 == false && timer >= 20)
            {   
                Debug.Log(timer);
                
                if (timer >= 20)
                {
                    Walk_to_book();
                }
            }
                //noiceNPCs();
     
        }
        
        //when npc colides with book
        private void OnTriggerStay2D(Collider2D other)
        {
            timerOnTrigger += Time.deltaTime;
           if (other.tag == ("Book White") && opacity <= 0.75f)
           {
                opacity = timerOnTrigger/10;
                red.color = new Color (1,0,0,opacity);
           } 
        }

        //when player pick upp books NPC stops making noice and being
        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.tag == ("Book White"))
            {
            opacity = 0;
            red.color = new Color (1,0,0,opacity);
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
            if (timer >= 2 && timer<2.1f)
            {
                //playSound = true;
                audio1.Play();
                
            }
             if (timer >= 6)
            {
              information_about_pick_up_book.SetActive(true);
              active_1= true;
            }
        }
        public void Walk_out()
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);

            if (timer >= 20)
            {
            active_2 = true;
            }
        }

        public void noiceNPCs()
        {
            Instantiate(pickedNPC, transform.position,Quaternion.identity);
            active_2 = true;
        }
}
