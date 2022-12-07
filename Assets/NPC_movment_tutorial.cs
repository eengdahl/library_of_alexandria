using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_movment_tutorial : MonoBehaviour
{
    // speech bubble when NPC is mad
    public GameObject Mad_NPC;

    public GameObject information_about_pick_up_book;

    public GameObject redchild;

    //waypoint target
    public Transform target;

    AudioSource audio1;

    //speed on walk
    float speed = 2;

    float opacity;

    float G_Color;

    float B_Color;

    float timer;
    float timerOnTrigger;
    bool playSound;

    SpriteRenderer red;

    void Start() 
        {
            audio1 = GetComponent<AudioSource>();
            red = redchild.GetComponent<SpriteRenderer>();
            opacity = 0;
        }

        void Update() 
        {
            timer += Time.deltaTime;

            //walking up to the book
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        

            //aktivate speech bubble
            if (transform.position == target.position)
            {
                Mad_NPC.SetActive(true);
            }

            //playSound when npc is in front of the book
            if (timer >= 2 && timer<2.1f)
            {
                playSound = true;
                audio1.Play();
                
            }
             if (timer >= 6)
            {
              information_about_pick_up_book.SetActive(true);
            }

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
        private void OnTriggerExit2D(Collider2D other) 
        {
            opacity = 0;
            audio1.Stop();
        }
}
