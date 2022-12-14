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
   
    public bool isMaxSize;

    //Size timers
    float timer;
    float timerExtra;
    public float timerEnd = 5;

    private void Start()
    {
        timerExtra = Random.Range(0, 0.5f);
        collider = GetComponent<Collider2D>();
        gameObject.transform.localScale = minSize;
        timer += timerExtra;
    }
    private void Update()
    {

        //Timer for size increase
        timer += Time.deltaTime;
        if(timer > timerEnd && gameObject.transform.localScale.x < maxSize.x)
        {
            gameObject.transform.localScale += sizeIncrease;
            timer = 0;
        }

        //Activate collider when at certain size so player cant move past
        if (transform.localScale.x > maxSize.x / 2)
        {
            collider.enabled = true;
        }
        else if(transform.localScale.x <= maxSize.x / 2)
        {
            collider.enabled = false;
        }


        //Bool so new fire spawner script works
        if(gameObject.transform.localScale == maxSize)
        {
            isMaxSize = true;
        }
        else if (gameObject.transform.localScale.x < maxSize.x)
        {
            isMaxSize = false;
        }

    }

}
