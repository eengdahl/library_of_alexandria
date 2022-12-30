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
    [SerializeField] float smallHuschCharged = 0.4f;
    Vector3 startSizeCharged; 
    AllPlayerUpgradeables playerUpgradeables;
    public bool doesBigHush = false;


    //"shake"
    public float whenShake;

    //Stamina
    Stamina staminaScript;
    public float chargedHuschMax;

    //Husch cooldown;
    float coolDown;
    //Zoom
    public bool zoomIn = false;

    // Start is called before the first frame update
    void Start()
    {
        startSizeCharged = new Vector3(smallHuschCharged, smallHuschCharged, 0);
        staminaScript = FindObjectOfType<Stamina>();
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

        coolDown -= Time.deltaTime;
        //Om du trycker på  activate spela husch ljudet och gör om boolen doesHuschSound till true
        if (Input.GetKey("space") && !doesHuschSound && staminaScript.stamina>0)
        {
            if (chargedHush < smallHuschCharged)
            {
                chargedHush += Time.deltaTime;
            }
            if (chargedHush  > smallHuschCharged + 0.05f)
            {
                spriteRenderer.enabled = true;
                animatorKarin.SetBool("breath", true);
            }

            if (chargedHush < chargedHuschMax && staminaScript.stamina > 0 && chargedHush  > smallHuschCharged )
            {
                
                if (chargedHush > smallHuschCharged)
                {
                    staminaScript.stamina -= chargedHush * Time.deltaTime * 8;
                }
                if (chargedHush >= chargedHuschMax / 2)
                {
                    chargedHush += Time.deltaTime / 4;
                }
                else 
                {
                    chargedHush += Time.deltaTime;
                }
            }
            
            //"Shake the husch"
            if (chargedHush > chargedHuschMax/1.5f && Input.GetKey("space") && chargedHush < chargedHuschMax) //chargedHuschMax - chargedHush > whenShake
            {
                zoomIn = true;
                float scale = chargedHush + startSizeCharged.x + Mathf.Sin(Time.time * 20) * 0.05f;
                transform.localScale = new Vector3(scale, scale, 0);
            }
            //Increase size
            else
            {
                gameObject.transform.localScale = startSizeCharged + new Vector3(chargedHush, chargedHush, 1);
            }
        }
        //Makes a chargedHush
        if (Input.GetKeyUp("space") && chargedHush > smallHuschCharged)
        {
            doesBigHush = true;
            zoomIn = false;
            //finetunear hur effektiv chargehush ska vara, work in progress

            Invoke("StopAudio", chargedHush);

            doesHuschSound = true;

            //picking long hush
            audioSource.clip = longHush;
            audioSource.Play();

            animatorKarin.SetBool("makeBreath", true);
            animatorKarin.SetBool("breath", false);

            animatorKarin.SetBool("IsHushing", true);

            //Setting hushradius after how long hush was charged
            gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1) + startSizeCharged;
            if (chargedHush > 1)
            {
                lenghtOfHusch = chargedHush / 2;

            }
            chargedHush = 0;
            //playerController1.karinCantMove = true;
            playerController1.speed = playerController1.speed * 4;
            Invoke("StandardSpeed", lenghtOfHusch);


        }
        //Makes standard hush
        else if (Input.GetKeyUp("space") && !doesHuschSound && chargedHush <= smallHuschCharged && coolDown <= 0)
        {
            coolDown = 1f;
            spriteRenderer.enabled = false;
            chargedHush = smallHuschCharged;
            doesHuschSound = true;
            audioSource.clip = schhSound[Random.Range(0, schhSound.Length)];
            audioSource.Play();
            animatorKarin.SetBool("makeBreath", true);
            animatorKarin.SetBool("IsHushing", true);
            gameObject.transform.localScale = new Vector3(chargedHush, chargedHush, 1);
            //playerController1.karinCantMove = true;
            playerController1.speed = playerController1.speed * 2f;
            Invoke("StandardSpeed", smallHuschCharged);

        }

        //Om vi huschar håll boolen igång i längden "lengthOfHusch" sec stäng sedan av husch boolen 
        if (doesHuschSound)
        {
            huschTimer += Time.deltaTime;
            if (huschTimer >= lenghtOfHusch)
            {
                
                animatorKarin.SetBool("IsHushing", false);
                //lenghtOfHusch = 0.5f;
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
        doesBigHush = false;
        spriteRenderer.enabled = false;
        audioSource.Stop();
        doesHuschSound = false;
        animatorKarin.SetBool("makeBreath", false);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
    void StandardSpeed()
    {
        playerController1.speed = playerController1.fullSpeed;
    }
}
