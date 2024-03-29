using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChecker : MonoBehaviour
{
    float halfSpeed;
    float normalSpeed;
    public PlayerController1 playerMovement;
    public SpriteMask spriteMask;
    AllPlayerUpgradeables playerUpgradeables;
    public bool inWater = false;
    private void Start()
    {
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        normalSpeed = playerUpgradeables.normalSpeed;
        halfSpeed = normalSpeed / 3;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            
        }
        if (collision.CompareTag("WaterInside"))
        {
            playerMovement.speed = halfSpeed;
            spriteMask.enabled = true;
            inWater = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            
            playerMovement.speed = normalSpeed;
        }
        if (collision.CompareTag("WaterInside"))
        {
            inWater = false;
            spriteMask.enabled = false;
            
        }
    }
}
