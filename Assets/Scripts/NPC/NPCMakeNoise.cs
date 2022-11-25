using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMakeNoise : MonoBehaviour
{
    public float timer;
    public AudioSource aS;
    public AudioClip[] nosie;
    public bool makingNosie = false;
    Meters meters;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        timer = 0;
        meters = FindObjectOfType<Meters>();

    }

    // Update is called once per frame
    void Update()
    {

        //Make the timer increase chance of making noise 
        timer += Time.deltaTime;

        if (timer >= 4f)
        {
            float startMakingSoundPicker = Random.Range(1f, 10f);
            if (startMakingSoundPicker <= 4)
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
            meters.UpdateNoise(10);

        }
        else if (makingNosie == false)
        {
            aS.enabled = false;
        }
    }

}
