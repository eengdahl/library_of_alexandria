using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHuschSound : MonoBehaviour
{
    public AudioClip[] schhSound;
    public AudioClip longHush;
    AudioSource audioSource;
    float huschTimer;
    public float lenghtOfHusch;
    public bool doesHuschSound;
    Animator animatorKarin;
    private float chargedHush;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animatorKarin = GetComponentInParent<Animator>();
        // Random.Range(0, schhSound.Length);
        audioSource.clip = schhSound[Random.Range(0, schhSound.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        //Om du trycker på  activate spela husch ljudet och gör om boolen doesHuschSound till true
        if (Input.GetKey("space"))
        {
            chargedHush += Time.deltaTime;

        }
        //Makes a chargedHush
        if (Input.GetKeyUp("space") && chargedHush > 0.5f)
        {
            doesHuschSound = true;
            audioSource.clip = longHush;
            Invoke("StopAudio",chargedHush);
            audioSource.Play();
            animatorKarin.SetBool("IsHushing", true);
            chargedHush = 0;
        }
        //Makes standard hush
        else if (Input.GetKeyUp("space"))
        {
            doesHuschSound = true;
            audioSource.clip = schhSound[Random.Range(0, schhSound.Length)];
            audioSource.Play();
            animatorKarin.SetBool("IsHushing", true);

            chargedHush = 0;
        }
        //Om vi huschar håll boolen igång i längden "lengthOfHusch" sec stäng sedan av husch boolen 
        if (doesHuschSound)
        {
            huschTimer += Time.deltaTime;


            if (huschTimer >= lenghtOfHusch)
            {
                animatorKarin.SetBool("IsHushing", false);
                doesHuschSound = false;
            }

        }
        //Om vi inte huschar ska husch timern vara på 0
        else if (!doesHuschSound)
        {
            animatorKarin.SetBool("IsHushing", false);
            huschTimer = 0;
        }
    }

    private void StopAudio()
    {
        audioSource.Stop();
    }
}
