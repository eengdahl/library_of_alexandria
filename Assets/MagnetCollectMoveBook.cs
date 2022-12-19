using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCollectMoveBook : MonoBehaviour
{
    GameObject playerMagnet;
    GameObject player;
    Vector3 playerPosition;
    bool moveAway = false;
    InventoryPlayer invPlayer;
    float speed = 1;
    float timer;
    int emptyInvSpots;
    int amountsOfSpots = 3;
    private void Start()
    {
        invPlayer = FindObjectOfType<InventoryPlayer>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {//Om inventory är fullt kör inte detta på böcker

        emptyInvSpots = amountsOfSpots - invPlayer.invSpotsUsed;
        if (emptyInvSpots <= 0)
        {
            moveAway = false;
            timer = 0;
        }
        if (moveAway)
        {
            timer += Time.deltaTime;

            if (timer < 0.2)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerPosition, -1 * speed * Time.deltaTime);
            }
            else
            {

                transform.position = Vector3.MoveTowards(transform.position, playerMagnet.transform.position, 12 * Time.deltaTime);
            }
            if (transform.position == playerMagnet.transform.position)
            {
                moveAway = false;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUpMagnet") && !invPlayer.inventoryFull)
        {

            playerMagnet = collision.gameObject;
            playerPosition = collision.transform.position;
            moveAway = true;

        }
    }

}
