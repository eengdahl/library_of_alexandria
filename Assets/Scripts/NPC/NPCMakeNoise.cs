using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMakeNoise : MonoBehaviour
{
    public float timer;
    public AudioSource aS;
    public AudioClip[] nosie;
    public bool makeingNosie = false;
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

        if (timer >= 1f)
        {
            float startMakingSoundPicker = Random.Range(1f, 10f);
            if (startMakingSoundPicker <= 4)
            {
                makeingNosie = true;
            }
            timer = 0;
        }

        if (makeingNosie == true)
        {
            timer = 0;
            aS.enabled = true;
            //Calling Meters and adjusting noisemeter
            meters.UpdateNoise(10);

        }
        else if (makeingNosie == false)
        {
            aS.enabled = false;
        }
    }

}
