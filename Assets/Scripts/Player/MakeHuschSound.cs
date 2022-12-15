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
    public float chargedHush;
    public float standardRadius = 0.5f;//0.4697719f;
    public bool doesHuschSound;
    Animator animatorKarin;
    CircleCollider2D collider2D;
    PlayerController1 playerController1;
    float startSize = 1;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animatorKarin = GetComponentInParent<Animator>();
        collider2D = GetComponent<CircleCollider2D>();
        audioSource.clip = schhSound[Random.Range(0, schhSound.Length)];
        playerController1 = GetComponentInParent<PlayerController1>();
       
    }

    void Update()
    {
        //Om du trycker på  activate spela husch ljudet och gör om boolen doesHuschSound till true
        if (Input.GetKey("space") && !doesHuschSound)
        {
            if (chargedHush < 1f)//1.5
            {
                chargedHush += Time.deltaTime;
                //chargedHush += startSize + (Time.deltaTime/2);
                //gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (chargedHush > 1 && chargedHush < 5)
            {
                    chargedHush += 3 * Time.deltaTime;
                //gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1);

            }
            gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1);
        }
        //Makes a chargedHush
        if (Input.GetKeyUp("space") && chargedHush > 0.6f)
        {
            //finetunear hur effektiv chargehush ska vara, work in progress
            //chargedHush /= 1.50f;
            Invoke("StopAudio", chargedHush);

            doesHuschSound = true;

            //picking long hush
            audioSource.clip = longHush;
            audioSource.Play();
            animatorKarin.SetBool("IsHushing", true);

            //Setting hushradius after how long hush was charged
            // collider2D.radius = chargedHush;
            gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1);
            if(chargedHush > 1)
            {
                lenghtOfHusch = 3f;

            }
            chargedHush = 0;
            playerController1.karinCantMove = true;

        }
        //Makes standard hush
        else if (Input.GetKeyUp("space") && !doesHuschSound && chargedHush<=0.6f)
        {
            chargedHush = 1;
            doesHuschSound = true;
            audioSource.clip = schhSound[Random.Range(0, schhSound.Length)];
            audioSource.Play();
            animatorKarin.SetBool("IsHushing", true);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            playerController1.karinCantMove = true;

        }
        //Om vi huschar håll boolen igång i längden "lengthOfHusch" sec stäng sedan av husch boolen 
        if (doesHuschSound)
        {
            huschTimer += Time.deltaTime;

            if (huschTimer >= lenghtOfHusch)
            {
                animatorKarin.SetBool("IsHushing", false);
                lenghtOfHusch = 0.5f;
                chargedHush = 0;
                doesHuschSound = false;
                StopAudio();
            }
        }
        //Om vi inte huschar ska husch timern vara på 0
        else if (!doesHuschSound)
        {
            animatorKarin.SetBool("IsHushing", false);
            huschTimer = 0;
            
            playerController1.karinCantMove = false;
        }
    }

    //Stopps chargehush after time of charge hush
    private void StopAudio()
    {
        audioSource.Stop();
        doesHuschSound = false;
        //collider2D.radius = standardRadius;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        
    }
}
