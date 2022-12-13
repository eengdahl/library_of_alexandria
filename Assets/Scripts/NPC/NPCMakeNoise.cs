using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMakeNoise : MonoBehaviour
{
    public float timer;
    public AudioSource aS;
    public AudioClip[] nosie;
    public bool makingNosie = false;
    public float chanceOfMakingSound;//if smaller or same than this number make sound
    public NPCMovement npcMovement;
    [SerializeField] SpriteRenderer exclamationMark;
    Animator myAnimator;
    void Start()
    {
        aS = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
        timer = 0;

        exclamationMark = transform.GetChild(5).gameObject.GetComponent<SpriteRenderer>();
        exclamationMark.enabled = false;

        //Setting Diffrent Noiceclipp
        Random.Range(0, nosie.Length);
        aS.clip = nosie[Random.Range(0, nosie.Length)];
        if(gameObject.tag == ("NPC"))
        {

        npcMovement = GetComponent<NPCMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //Make the timer increase chance of making noise 
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            if (gameObject.CompareTag("NPC")) //Only do this on NPC and not researchers
            {

            float startMakingSoundPicker = Random.Range(1f, 10f);
            if (npcMovement.isSeated == true)
            {
                if (startMakingSoundPicker <= chanceOfMakingSound)
                {
                    makingNosie = true;
                }
            }
            if(npcMovement.isSeated == false)
            {
                if (startMakingSoundPicker * 2  <= chanceOfMakingSound)
                {
                    makingNosie = true;
                }
            }
            }


            timer = 0;
        }

        if (makingNosie == true)
        {
            timer = 0;
            aS.enabled = true;
            myAnimator.SetBool("noise", true);




        }
        else if (makingNosie == false)
        {
            myAnimator.SetBool("muchNoise", false);
            myAnimator.SetBool("noise", false);
            aS.enabled = false;
        }
    }


  
   
    
}
