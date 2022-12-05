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
        //Om du trycker p�  activate spela husch ljudet och g�r om boolen doesHuschSound till true
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

    private void StopAudio()
    {
        audioSource.Stop();
    }
}
