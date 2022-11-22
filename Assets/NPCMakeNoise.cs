using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMakeNoise : MonoBehaviour
{
    public float timer;
    public AudioSource aS;
    public AudioClip[] nosie;
    public bool makeingNosie = false;
    void Start()
    {
        aS = GetComponent<AudioSource>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Make the timer increase chance of making noise 
        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            float startMakingSoundPicker = Random.Range(1f, 10f);
            if (startMakingSoundPicker >= 8)
            {
                makeingNosie = true;
                Debug.Log("Should turn noise making on now");
            }
            timer = 0;
        }

        if (makeingNosie == true)
        {
            Debug.Log("Inside makingNoise");
            aS.enabled = true;
        }
        else if (makeingNosie == false)
        {
            aS.enabled = false;
        }
    }
}
