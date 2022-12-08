using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    GameObject kid;

    public void ReturnBooks(string bookColour)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            kid = FindChildWithTag(slots[i], bookColour);

            if (kid != null && kid.tag == bookColour)
            {
                Slot slot = slots[i].GetComponent<Slot>();
                slot.DestroyBook();
            }
        }
    }
    public GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }
}