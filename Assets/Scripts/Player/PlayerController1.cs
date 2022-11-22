using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

