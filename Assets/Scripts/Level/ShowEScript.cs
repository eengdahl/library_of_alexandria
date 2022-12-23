using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowEScript : MonoBehaviour
{
    [SerializeField] GameObject eButton;
    Registration registrationScript;
    InventoryPlayer inventoryPlayerScript;
    AllPlayerUpgradeables playerUpgrades;
    bool shouldDisplayE;
    void Start()
    {
        playerUpgrades = FindObjectOfType<AllPlayerUpgradeables>();
        shouldDisplayE = false;
        inventoryPlayerScript = FindObjectOfType<InventoryPlayer>();
        registrationScript = FindObjectOfType<Registration>();
        eButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        shouldDisplayE = false;
        for (int i = 0; i < playerUpgrades.numberOfSlot; i++)
        {       
           if( inventoryPlayerScript.isFull[i] == false)
            {
                shouldDisplayE = true;
            }
        }
        if (registrationScript.amountRegistered <= 0)
        {
            eButton.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "BookPickUpZone" && registrationScript.amountRegistered > 0 && shouldDisplayE == true)
        {
            eButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "BookPickUpZone")
        {
            eButton.SetActive(false);
        }
    }
}
