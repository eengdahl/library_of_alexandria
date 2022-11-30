using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHuschSound : MonoBehaviour
{
    public AudioClip schhSound;
    AudioSource audioSource;
    float huschTimer;
    public float lenghtOfHusch;
    public bool doesHuschSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Om du trycker på  activate spela husch ljudet och gör om boolen doesHuschSound till true
        if (Input.GetKeyDown("space"))
        {
            doesHuschSound = true;
            audioSource.Play();
        }
        //Om vi huschar håll boolen igång i längden "lengthOfHusch" sec stäng sedan av husch boolen 
        if (doesHuschSound)
        {
            huschTimer += Time.deltaTime;
            if (huschTimer >= lenghtOfHusch)
            {
                doesHuschSound = false;
            }
            
        }
        //Om vi inte huschar ska husch timern vara på 0
        else if(!doesHuschSound)
        {
            huschTimer = 0;
        }
    }
}
