using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrow : MonoBehaviour
{
    //Size max and low settings
    Vector3 sizeIncrease = new Vector3(0.1f, 0.1f, 0);
    public Vector3 minSize = new Vector3(0.3f, 0.3f, 1);
    Vector3 maxSize = new Vector3(1, 1, 1);

    
    public bool isMaxSize;

    //Size timers
    float timer;
    public float timerEnd = 5;

    private void Start()
    {
        gameObject.transform.localScale = minSize;
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
