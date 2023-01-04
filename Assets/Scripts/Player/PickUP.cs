using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    private InventoryPlayer inventoryPlayer;
    public GameObject BookColour;
    AllPlayerUpgradeables playerUpgrades;
    public AudioClip pickUpSound;
    AudioSource aS;
    PickUpSoundScript pickUpSoundScript;
    private void Start()
    {
        pickUpSoundScript = FindObjectOfType<PickUpSoundScript>();
        aS = GetComponent<AudioSource>();
        playerUpgrades = FindObjectOfType<AllPlayerUpgradeables>();
        inventoryPlayer = GameObject.FindGameObjectWithTag ("BookPickUpZone").GetComponent<InventoryPlayer>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BookPickUpZone")) 
        {
            for (int i = 0; i < playerUpgrades.numberOfSlot; i++)
            {
                if (inventoryPlayer.isFull[i] == false)
                {
                    pickUpSoundScript.PlayPickUpSound();
                    //BOOK CAN BE ADDED TO INVENTORY
                    inventoryPlayer.isFull[i] = true;
                    Instantiate(BookColour, inventoryPlayer.slots[i].transform, false);
                    //aS.clip = pickUpSound;
                    //aS.Play();
                    AudioSource.PlayClipAtPoint(pickUpSound, transform.position, 1f);
                    
                    Destroy(gameObject);
                    break; //Stop the for loop if empty spot in inventory is found
                }
            }
        }


     
    }
}
