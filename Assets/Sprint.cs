using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public float sprintSpeed;
    PlayerController1 playerController;
    float normalSpeed;
    Stamina staminaScript;
    AllPlayerUpgradeables playerUpgradeables;
    private void Start()
    {
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        staminaScript = GetComponent<Stamina>();
        playerController = GetComponent<PlayerController1>();
        normalSpeed = playerUpgradeables.normalSpeed;
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

                playerController.speed = playerUpgradeables.sprintSpeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerController.speed = playerUpgradeables.normalSpeed;
        }
    }
}
