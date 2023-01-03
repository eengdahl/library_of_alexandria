using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{

    public float speed;
    public float halfSpeed;
    public float fullSpeed;
    bool isPlayingAudio = false;

    SpriteRenderer sprite;
    private Rigidbody2D rb;
    public Vector2 moveVelocity;
    public Vector2 inputAxis;
    bool facingRight = false;
    public bool karinCantMove = false;
    Animator animator;
    public bool isMoving;
    AllPlayerUpgradeables playerUpgradeables;

    AudioSource aS;
    public AudioClip water;
    public AudioClip steps;
    private void Start()
    {
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        sprite = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = playerUpgradeables.normalSpeed;
        halfSpeed = speed / 2;
        fullSpeed = speed;

        aS = GetComponent<AudioSource>();

    }

    private void Update()
    {
        //Freezing karin from script MakeHushSound if longhushing
        if (karinCantMove)
        {
            animator.SetFloat("IsMoving", 0);
            rb.velocity = new Vector2(0, 0);
            return;
        }

        inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = inputAxis.normalized * speed;
        if (inputAxis.x > 0 || inputAxis.x < 0 || inputAxis.y < 0 || inputAxis.y > 0)
        {
            isMoving = true;

            if (!isPlayingAudio)
            {
                aS.Play();
                isPlayingAudio = true;
            }
        }
        else
        {
            isMoving = false;
            aS.Stop();
            isPlayingAudio = false;
        }


    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && facingRight)
        {
            flip();
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && !facingRight)
        {
            flip();
        }

        //Freezing karin from script MakeHushSound if longhushing
        if (karinCantMove)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetFloat("IsMoving", 0);
            return;
        }
        rb.velocity = moveVelocity;
        animator.SetFloat("IsMoving", rb.velocity.magnitude);

    }
    private void flip()
    {
        //Freezing karin from script MakeHushSound if longhushing
        if (karinCantMove)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetFloat("IsMoving", 0);
            return;
        }
        facingRight = !facingRight;
        if (sprite.flipX == false)
        {

            sprite.flipX = true;
        }

        else if (sprite.flipX == true)
        {
            sprite.flipX = false;
        }
    }

    public void WalkingOnWater(bool onOf)
    {
        if (onOf)
        {
            aS.clip = water;
            isPlayingAudio = false;
            aS.pitch = 0;
            if (!isPlayingAudio)
            {
                aS.pitch = 2;
                aS.Play();
                isPlayingAudio = true;
            }
        }
        else
        {
            aS.clip = steps;
            isPlayingAudio = false;
            aS.pitch = 2;
            if (!isPlayingAudio)
            {
                aS.Play();
                isPlayingAudio = true;
            }
        }
    }


}

