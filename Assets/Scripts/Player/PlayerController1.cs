using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public float speed;
    float halfSpeed;
    float fullSpeed;


    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    Vector2 inputAxis;
    bool facingRight = false;
    public bool karinCantMove = false;
    Animator animator;
    private void Start()
    {
        halfSpeed = speed / 2;
        fullSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Freezing karin from script MakeHushSound if longhushing
        if (karinCantMove)
        {
            return;
        }

        inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = inputAxis.normalized * speed;


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
            return;
        }
        facingRight = !facingRight;

        //assigns a the scale component to a variable temporarily
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }


}

