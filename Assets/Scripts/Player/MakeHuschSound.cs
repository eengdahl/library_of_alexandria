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
    SpriteRenderer spriteRenderer;
    Vector3 startSizeCharged = new Vector3(0.3f, 0.3f, 0);
    [SerializeField] float smallHuschCharged = 0.4f;
    AllPlayerUpgradeables playerUpgradeables;

    public float chargedHuschMax;

    // Start is called before the first frame update
    void Start()
    {
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        chargedHuschMax = playerUpgradeables.chargedHuschMax;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
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
            if (chargedHush > smallHuschCharged)
            {
            spriteRenderer.enabled = true;

            }
            if (chargedHush < chargedHuschMax)
            {
                chargedHush += Time.deltaTime;
                //chargedHush += startSize + (Time.deltaTime/2);
                //gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            //else if (chargedHush > 1 && chargedHush < 3)
            //{
            //        chargedHush += 1 * Time.deltaTime;
            //    //gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1);

            //}
            gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1) + startSizeCharged;
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
            gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1) + startSizeCharged;
            if(chargedHush > 1)
            {
                lenghtOfHusch = chargedHush/2;

            }
            chargedHush = 0;
            //playerController1.karinCantMove = true;
            playerController1.speed = playerController1.speed / 2;
            Invoke("StandardSpeed", lenghtOfHusch);

        }
        //Makes standard hush
        else if (Input.GetKeyUp("space") && !doesHuschSound && chargedHush<=0.6f)
        {
            spriteRenderer.enabled = false;
            chargedHush = smallHuschCharged;
            doesHuschSound = true;
            audioSource.clip = schhSound[Random.Range(0, schhSound.Length)];
            audioSource.Play();
            animatorKarin.SetBool("IsHushing", true);
            gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1);
            //playerController1.karinCantMove = true;
            playerController1.speed = playerController1.speed / 2f;
            Invoke("StandardSpeed", smallHuschCharged);
        }
        //Om vi huschar håll boolen igång i längden "lengthOfHusch" sec stäng sedan av husch boolen 
        if (doesHuschSound)
        {
            huschTimer += Time.deltaTime;

            if (huschTimer >= lenghtOfHusch)
            {
                spriteRenderer.enabled = false;
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
    void StandardSpeed()
    {
        playerController1.speed = playerController1.fullSpeed;
    }
}
