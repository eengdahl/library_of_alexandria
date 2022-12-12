using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutuorial_npc_Buddys : MonoBehaviour
{
    public Transform target_Buddys1;
    public Transform target_Buddys11;
    SpriteRenderer red;
    GameObject target_Buddys1_1;
    public GameObject redchild;
    float timerOnTrigger;
    float speed = 2;
    float timer;
    AudioSource audio1_1;
    float opacity;
    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;
    // Start is called before the first frame update
    void Start()
    {
        target_Buddys1_1 = GameObject.FindGameObjectWithTag("Waypoint npc buddy1");
        target_Buddys1 = target_Buddys1_1.transform;

        red = redchild.GetComponent<SpriteRenderer>();

        audio1_1 = GetComponent<AudioSource>();
        opacity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1 && active_1== false)
        {
        transform.position = Vector3.MoveTowards(transform.position, target_Buddys1.position, speed * Time.deltaTime);
        }

        if (timer >= 7 && timer<7.1f && active_2 == false)
        {
            audio1_1.Play();
            active_1 = true;
        }
        if (timer >= 15)
            {
              active_2= true;
            }
    }
    private void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log("colidas denna");
            timerOnTrigger += Time.deltaTime;
           if (other.tag == ("Waypoint npc buddy2") && opacity <= 0.75f)
           {
            Debug.Log("nej.................................");
                opacity = timerOnTrigger/10;
                red.color = new Color (1,0,0,opacity);
           } 
        }
}
