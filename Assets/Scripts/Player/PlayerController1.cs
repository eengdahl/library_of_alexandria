using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public float speed;
    float halfSpeed;
    public float fullSpeed;

    SpriteRenderer sprite;
    private Rigidbody2D rb;
    public Vector2 moveVelocity;
    public Vector2 inputAxis;
    bool facingRight = false;
    public bool karinCantMove = false;
    Animator animator;
    public bool isMoving;
    AllPlayerUpgradeables playerUpgradeables;
    private void Start()
    {
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        sprite = GetComponent<SpriteRenderer>();
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = playerUpgradeables.normalSpeed;
        halfSpeed = speed / 2;
        fullSpeed = speed;

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
        if (inputAxis.x>0 || inputAxis.x < 0 || inputAxis.y < 0|| inputAxis.y > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
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
        animator.SetFloat("IsMoving",rb.velocity.magnitude);
        
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
            Debug.Log("sprite flip");
            sprite.flipX = true;
        }

        else if (sprite.flipX == true){
            sprite.flipX = false;
        }
        //sprite.flipX = !sprite.flipX;
        ////assigns a the scale component to a variable temporarily
        //Vector3 tmpScale = gameObject.transform.localScale;
        //tmpScale.x *= -1;
        //gameObject.transform.localScale = tmpScale;
    }


}

