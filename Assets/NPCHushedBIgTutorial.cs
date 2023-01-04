using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class NPCHushedBIgTutorial : MonoBehaviour
{
    [SerializeField] Animator animatorBook;
    [SerializeField] AnimationBoolFunctions boolFunctions;
    public Transform standingPosition;
    public Transform startPosition;
    float speed = 2f;
    bool hasRechedStartPosition = false;
    public bool hasBeenHushed = false;
    public bool startWalking = false;
    bool bookCanSpawn = true;

    public GameObject longHuschInformation;
    public GameObject staminaInformaion;
    public GameObject arrowToBook;
    SpriteRenderer arrowToBookRenderer;
    GameObject whiteBookTutorial;
    Image whiteBookPage;
    public GameObject book;

    bool haveTurnedPage = false;

    Animator myAnimator;
    AudioSource aS;

    public MakeHuschSound playerMakesHusch;

    void Awake()
    {
        // startPosition.position = this.transform.position;
        playerMakesHusch = FindObjectOfType<MakeHuschSound>();
        aS = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();

        whiteBookTutorial = GameObject.FindGameObjectWithTag("KAOSBOK");

        arrowToBook = GameObject.FindGameObjectWithTag("ArrowBook");
        arrowToBookRenderer = arrowToBook.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (startWalking && !hasRechedStartPosition)
        {
            WalkIn();
        }

        if (hasBeenHushed)
        {
            WalkOut();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Husch" && playerMakesHusch.doesHuschSound && playerMakesHusch.doesBigHush && hasRechedStartPosition)
        {
            hasBeenHushed = true;
            aS.Stop();

        }
    }


    void WalkIn()
    {
        aS.Play();
        transform.position = Vector3.MoveTowards(transform.position, standingPosition.position, speed * Time.deltaTime);
        if (transform.position == standingPosition.position)
        {
            myAnimator.SetBool("still", true);
            hasRechedStartPosition = true;
        }
    }

    void WalkOut()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosition.position, speed * Time.deltaTime);
        myAnimator.SetBool("hushed", true);
        longHuschInformation.SetActive(false);
        staminaInformaion.SetActive(false);

        //whiteBookPage = whiteBookTutorial.GetComponent<Image>();
        //whiteBookPage.enabled = true;
        //animate book
        if(animatorBook != null && !haveTurnedPage)
        {
            
            Debug.Log("Big husch!");
            if(boolFunctions != null)
            {
            boolFunctions.TurnPageSound();

            }
            animatorBook.SetBool("TurnPage", true);
            haveTurnedPage = true;
        }
        arrowToBookRenderer.enabled = true;
       

        if (bookCanSpawn && this.name == "NPCBigHush_0")
        {
            Vector3 temp = new Vector3(7.4f, 0f, 0);
            Instantiate(book, temp, transform.rotation);
            bookCanSpawn = false;

        }



    }
}
