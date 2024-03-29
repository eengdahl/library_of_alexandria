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
    WaterChecker waterCheckerScript;
    Animator self;
    private void Start()
    {
        waterCheckerScript = FindObjectOfType<WaterChecker>();
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        staminaScript = GetComponent<Stamina>();
        playerController = GetComponent<PlayerController1>();
        normalSpeed = playerUpgradeables.normalSpeed;
        self= GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerController.isMoving)
        {
            if (!waterCheckerScript.inWater)
            {
                staminaScript.stamina -= 8 * Time.deltaTime;
                if (staminaScript.stamina <= 0)
                {
                    playerController.speed = normalSpeed;
                }
                else if (staminaScript.stamina > 0)
                {
                    self.SetBool("Sprint", true);
                    playerController.speed = playerUpgradeables.sprintSpeed;
                }

            }
            else if (waterCheckerScript.inWater)
            {
                playerController.speed = normalSpeed / 2;
            }

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (!waterCheckerScript.inWater)
            {
                playerController.speed = playerUpgradeables.normalSpeed;
                self.SetBool("Sprint", false);
            }
            else if (waterCheckerScript.inWater)
            {
                playerController.speed = playerUpgradeables.normalSpeed / 2;
                self.SetBool("Sprint", false);
            }
        }
    }
}
