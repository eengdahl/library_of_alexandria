using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaOrbMoveToPlayer : MonoBehaviour
{
    GameObject player;
    bool moveToPlayer = false;
    Stamina staminaScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        staminaScript = player.GetComponent<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
            if (transform.position == player.transform.position)
            {
                staminaScript.stamina += 5;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("BookPickUpZone"))
        {
            moveToPlayer = true;
        }
    }
}
