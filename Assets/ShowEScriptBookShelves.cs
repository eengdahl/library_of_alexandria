using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowEScriptBookShelves : MonoBehaviour
{
    [SerializeField] GameObject eButton;
    InventoryPlayer inventoryPlayerScript;
    AllPlayerUpgradeables upgradesScript;
    GameObject kid;
    bool canReturn = false;
    string colourOfTheBook;
    void Start()
    {
        inventoryPlayerScript = FindObjectOfType<InventoryPlayer>();
        eButton.SetActive(false);
        upgradesScript = FindObjectOfType<AllPlayerUpgradeables>();
        ColourOfBooks();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && canReturn)
        {
            inventoryPlayerScript.ReturnBooks(colourOfTheBook);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BookPickUpZone")
        {
            ShowE(colourOfTheBook);
            canReturn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BookPickUpZone")
        {
            canReturn = false;
            eButton.SetActive(false);

        }
    }
    public void ShowE(string bookColour)
    {
        eButton.SetActive(false);
        for (int i = 0; i < upgradesScript.numberOfSlot; i++) //slots.Length
        {
            kid = FindChildWithTag(inventoryPlayerScript.slots[i], bookColour);

            if (kid != null && kid.tag == bookColour)
            {

                eButton.SetActive(true);
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

    void ColourOfBooks()
    {
        if (gameObject.tag == "Bookshelf Blue")
        {
            colourOfTheBook = "Book Blue";
        }
        else if (gameObject.tag == "Bookshelf Red")
        {
            colourOfTheBook = "Book Red";
        }
        else if (gameObject.tag == "Bookshelf Green")
        {
            colourOfTheBook = "Book Green";
        }
    }
}
