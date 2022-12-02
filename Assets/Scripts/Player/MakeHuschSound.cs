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
    Animator animatorKarin;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animatorKarin = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Om du trycker p�  activate spela husch ljudet och g�r om boolen doesHuschSound till true
        if (Input.GetKeyDown("space"))
        {
            doesHuschSound = true;
            audioSource.Play();
            animatorKarin.SetBool("IsHushing", true);
        }
        //Om vi huschar h�ll boolen ig�ng i l�ngden "lengthOfHusch" sec st�ng sedan av husch boolen 
        if (doesHuschSound)
        {
            huschTimer += Time.deltaTime;

         
            if (huschTimer >= lenghtOfHusch)
            {
                animatorKarin.SetBool("IsHushing", false);
                doesHuschSound = false;
            }

        }
        //Om vi inte huschar ska husch timern vara p� 0
        else if (!doesHuschSound)
        {
            animatorKarin.SetBool("IsHushing", false);
            huschTimer = 0;
        }
    }
}
