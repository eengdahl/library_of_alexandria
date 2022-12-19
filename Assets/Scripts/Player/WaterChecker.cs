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
    private void Start()
    {
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        normalSpeed = playerUpgradeables.normalSpeed;
        halfSpeed = normalSpeed / 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            
            playerMovement.speed = halfSpeed;
        }
        if (collision.CompareTag("WaterInside"))
        {
            spriteMask.enabled = true;
            
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
            spriteMask.enabled = false;
            
        }
    }
}
