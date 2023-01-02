using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByStone : MonoBehaviour
{
    [SerializeField]PlayerController1 playerControllerScript;
    public bool stoned = false;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.speed <= playerControllerScript.fullSpeed && stoned)
        {
            playerControllerScript.speed = playerControllerScript.halfSpeed / 2;
        }

        if (stoned)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                playerControllerScript.speed = playerControllerScript.fullSpeed;
                timer = 0;
                stoned = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone"))
        {
            playerControllerScript.speed = playerControllerScript.halfSpeed/2;
            stoned = true;
        }
    }
}
