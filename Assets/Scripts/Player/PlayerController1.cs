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
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {


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
        rb.velocity = moveVelocity;

        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    private void flip()
    {
        facingRight = !facingRight;

        //assigns a the scale component to a variable temporarily
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
}

