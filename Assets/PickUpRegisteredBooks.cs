using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRegisteredBooks : MonoBehaviour
{
    Registration registrationScript; //Get the amount registered from this script and remove amount when book is picked up + get registered book list and remove from there
    private InventoryPlayer inventoryPlayer;
    public List <GameObject> bookColours;


    private void Start()
    {
        registrationScript = FindObjectOfType<Registration>();
        inventoryPlayer = GameObject.FindGameObjectWithTag("BookPickUpZone").GetComponent<InventoryPlayer>();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "BookPickUpZone")
    //    {
    //        for (int i = 0; i > registrationScript.; i++)
    //        {

    //        }
    //    }
    //}
}
