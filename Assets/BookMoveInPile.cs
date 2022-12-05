using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMoveInPile : MonoBehaviour
{
    Registration registrationScript;
    List<GameObject> registeredBooks;
    Vector3 moveTowards;
    GameObject followTarget;
    public bool turningLeft;
    public int thisIndex;
    
    private void Start()
    {
        bool turned = false;
        registrationScript = FindObjectOfType<Registration>();
        moveTowards = new Vector3(transform.position.x + 0.05f, transform.position.y, 0);

        //thisIndex = registeredBooks.IndexOf(this.gameObject);
        //transform.position = registeredBooks[thisIndex - 1].transform.position;
    }

    private void Update()
    {
        registeredBooks = registrationScript.registeredBooks;
        thisIndex = registeredBooks.IndexOf(this.gameObject);
        Debug.Log(registeredBooks.IndexOf(gameObject));
        if (registeredBooks.Count >= 7 && registeredBooks.IndexOf(this.gameObject) == 2) ; //registeredBooks.IndexOf(this.gameObject)==2 && 
        {
            
            Debug.Log("Should be moving now"+registeredBooks.IndexOf(this.gameObject));
            if(transform.position != moveTowards)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, moveTowards, 0.0001f + thisIndex / 100);
            }
            if (transform.position == moveTowards && !turningLeft)
            {
                moveTowards.x = moveTowards.x -= 0.1f+ thisIndex/20;
                turningLeft = true;
            }
            else if (transform.position == moveTowards && turningLeft)
            {
                moveTowards.x = moveTowards.x += 0.1f + thisIndex/20;
                turningLeft = false;
            }
            //gameObject.transform.position = Vector3.MoveTowards(transform.position, moveTowards, 0.02f);
        }


        //else if (registeredBooks.IndexOf(this.gameObject)> 2 && registeredBooks.Count > 7) // follow the book lower in the stack
        //{
           
        //    thisIndex = registeredBooks.IndexOf(this.gameObject);
        //    moveTowards.x = registeredBooks[thisIndex - 1].transform.position.x + thisIndex/200f;
        //    gameObject.transform.position = Vector3.MoveTowards(transform.position, moveTowards, 0.001f + thisIndex/500);
        //}
    }
}
