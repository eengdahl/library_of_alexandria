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

    //particell effects;
    [SerializeField] GameObject dust;
    [SerializeField] GameObject water;
    private void Start()
    {
        playerUpgradeables = FindObjectOfType<AllPlayerUpgradeables>();
        normalSpeed = playerUpgradeables.normalSpeed;
        halfSpeed = normalSpeed / 3;
    }
    private void Update()
    {
        if (inWater)
        {
            dust.SetActive(false);
            water.SetActive(true);
        }
        else
        {
            dust.SetActive(true);
            water.SetActive(false);
        }

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
            playerMovement.WalkingOnWater(inWater);


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
            playerMovement.WalkingOnWater(inWater);

        }
    }
}
