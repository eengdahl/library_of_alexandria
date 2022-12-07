using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    Vector2 inputAxis;
    bool facingRight = false;
    public bool karinCantMove = false;
    Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (karinCantMove)
        {
            return;
        }

        inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = inputAxis.normalized * speed;

        //Added a quick way to get to menu by pressing esc
        //if (Input.GetButton("Cancel"))
        //{
            //SceneManager.LoadScene("Meny");
        //}

        ////Added a quick way to reset game 
        //if (Input.GetKey("r"))
        //{
        //    SceneManager.LoadScene("scene_main");
        //    SceneManager.
        //}


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

        if (karinCantMove)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        rb.velocity = moveVelocity;
        animator.SetFloat("IsMoving",rb.velocity.magnitude);
        

        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    private void flip()
    {
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

