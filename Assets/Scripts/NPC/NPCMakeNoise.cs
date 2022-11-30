using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMakeNoise : MonoBehaviour
{
    public float timer;
    public AudioSource aS;
    public AudioClip[] nosie;
    public bool makingNosie = false;
    public float chanceOfMakingSound;//if smaller or same than this number make sound
    
    void Start()
    {
        aS = GetComponent<AudioSource>();
        timer = 0;
        
        //Setting Diffrent Noiceclipp
        Random.Range(0, nosie.Length);
        aS.clip = nosie[Random.Range(0, nosie.Length)];


    }

    // Update is called once per frame
    void Update()
    {

        //Make the timer increase chance of making noise 
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            float startMakingSoundPicker = Random.Range(1f, 10f);
            if (startMakingSoundPicker <= chanceOfMakingSound)
            {
                makingNosie = true;
            }
            timer = 0;
        }

        if (makingNosie == true)
        {
            timer = 0;
            aS.enabled = true;
            //Calling Meters and adjusting noisemeter
            // meters.UpdateNoise(10);

        }
        else if (makingNosie == false)
        {
            aS.enabled = false;
        }
    }

}
