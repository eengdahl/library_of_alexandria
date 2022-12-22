using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrow : MonoBehaviour
{
    //Size max and low settings
    Vector3 sizeIncrease = new Vector3(0.1f, 0.1f, 0);
    public Vector3 minSize = new Vector3(0.5f, 0.5f, 1);
    Vector3 maxSize = new Vector3(2, 2, 1);
    Collider2D collider;
    [SerializeField] Animator ashesAnimator;
    public bool isMaxSize;
    SpriteRenderer spriteRendererFire;
    [SerializeField] SpriteRenderer spriteAshes;
    [SerializeField] GameObject fireLight;
    [SerializeField] FireHusched fireHuschedScript;
    Animator animator;
    //husched timer
    float timerEndHusched;
    float timerHusched;

    //Size timers
    float timer;
    float timerExtra;
    public float timerEnd = 5;
    int randPicker;
    bool chill = false;

    //Sound
    public AudioClip sorry;
    AudioSource aS;
    bool soundPlayed = false;
    private void Start()
    {
        aS = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        spriteAshes.enabled = false;
        spriteRendererFire = GetComponent<SpriteRenderer>();
        timerExtra = Random.Range(0, 0.5f);
        collider = GetComponent<Collider2D>();
        gameObject.transform.localScale = minSize;
        timer += timerExtra;
        timerEndHusched = Random.Range(3, 5);


        randPicker = Random.Range(0, 11);



    }
    private void Update()
    {



        //fireHuschedScript make the fire not grow after being husched for a little while
        if (fireHuschedScript.fireIsHusched)
        {

            if (randPicker == 0)
            {
                Debug.Log("Is zero");

                if (!soundPlayed)
                {

                    aS.PlayOneShot(sorry,0.5f);
                    soundPlayed = true;
                }
                animator.SetBool("FireIsHusched", true);
                BeenHusched();

            }
            else if (randPicker > 0)
            {
                Debug.Log("Bigger than zero");
                chill = true;
                BeenHusched();
            }

        }

        //Activate collider when at certain size so player cant move past
        if (transform.localScale.x > maxSize.x / 2)
        {

            collider.enabled = true;
        }
        else if (transform.localScale.x <= maxSize.x / 2)
        {
            collider.enabled = false;
        }

        //Timer for size increase
        if (!fireHuschedScript.fireIsHusched)
        {
            randPicker = Random.Range(0, 11);
            soundPlayed = false;
            animator.SetBool("FireIsHusched", false);
            fireLight.SetActive(true);
            //spriteAshes.enabled = false;
            ashesAnimator.SetBool("ashesOn", false);
            spriteRendererFire.enabled = true;
            timer += Time.deltaTime;
            if (timer > timerEnd && gameObject.transform.localScale.x < maxSize.x)
            {
                gameObject.transform.localScale += sizeIncrease;
                timer = 0;
            }



            //Bool so new fire spawner script works
            if (gameObject.transform.localScale == maxSize)
            {
                isMaxSize = true;
            }
            else if (gameObject.transform.localScale.x < maxSize.x)
            {
                isMaxSize = false;
            }

        }
    }
    void ReduceSize()
    {
        chill = true;
        //soundPlayed = false;

    }
    void BeenHusched()
    {
        if (chill)
        {
            //randPicker = Random.Range(0, 11);
            fireLight.SetActive(false);
            ashesAnimator.SetBool("ashesOn", true);
            spriteAshes.enabled = true;
            spriteRendererFire.enabled = false;
            timerHusched += Time.deltaTime;
            transform.localScale = minSize;
            if (timerHusched > timerEndHusched)
            {
                chill = false;
                fireHuschedScript.fireIsHusched = false;
                timerHusched = 0;
                animator.SetBool("FireIsHusched", false);
            }
        }
    }

}
