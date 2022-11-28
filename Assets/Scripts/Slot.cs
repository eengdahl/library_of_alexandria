using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private InventoryPlayer inventory;
    public int i;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("BookPickUpZone").GetComponent<InventoryPlayer>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void DestroyBook()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
