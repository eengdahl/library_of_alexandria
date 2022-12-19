using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCollectMoveOrb : MonoBehaviour
{
    GameObject playerMagnet;
    GameObject player;
    Vector3 playerPosition;
    bool moveAway = false;
    Stamina staminaScript;
    float speed = 1;
    float timer;
    float destroyTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        staminaScript = player.GetComponent<Stamina>();
    }
    void Update()
    {//Om inventory är fullt kör inte detta på böcker
        if (moveAway)
        {
            timer += Time.deltaTime;

            if (timer < 0.2)
            {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, -1 * speed * Time.deltaTime);         
            }
            else
            {
                destroyTimer += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, playerMagnet.transform.position, 30 * Time.deltaTime);
                if (transform.position == playerMagnet.transform.position && destroyTimer > 0.2f)
                {                  
                    staminaScript.stamina += 5;
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUpMagnet"))
        {
            
            playerMagnet = collision.gameObject;
            playerPosition = collision.transform.position;
            moveAway = true;
            
        }
    }
}
         