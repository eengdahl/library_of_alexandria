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
    public GameObject exclamation_talkbubbel;
    public GameObject redchild;
    public GameObject hush_information;
    //hush_information_1
    float timerOnTrigger;
    float speed = 2;
    float timer;
    AudioSource audio2_2;
    float opacity;

    bool active_1 = false;

    bool active_2 = false;
    bool active_3 = false;

    // Start is called before the first frame update
    void Start()
    {
        target_Buddys2_2 = GameObject.FindGameObjectWithTag("Waypoint npc buddy2");
        target_Buddys2 = target_Buddys2_2.transform;

        audio2_2 = GetComponent<AudioSource>();
        opacity = 0;

        //hush_information_1 = hush_information.;
         hush_information.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (active_1== false)
        {
        transform.position = Vector3.MoveTowards(transform.position, target_Buddys2.position, speed * Time.deltaTime);
        audio2_2.Play();
        exclamation_talkbubbel.SetActive(true);
        }

        }
    private void OnTriggerStay2D(Collider2D other)
        {

        }
}
