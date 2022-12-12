using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSlot : MonoBehaviour
{
    private NPCInventory inventory;
    public int i;
    private void Start()
    {

        inventory = GameObject.FindGameObjectWithTag("Researcher").GetComponent<NPCInventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
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
