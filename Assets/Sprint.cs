using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public float sprintSpeed;
    PlayerController1 playerController;
    float normalSpeed;
    Stamina staminaScript;
    private void Start()
    {
        staminaScript = GetComponent<Stamina>();
        playerController = GetComponent<PlayerController1>();
        normalSpeed = playerController.speed;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerController.isMoving )
        {
            staminaScript.stamina -= 8 * Time.deltaTime;
            if (staminaScript.stamina <= 0)
            {
                playerController.speed = normalSpeed;
            }
            else if (staminaScript.stamina > 0)
            {

                playerController.speed = sprintSpeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerController.speed = normalSpeed;
        }
    }
}
