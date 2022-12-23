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
    GameObject player;
    public GameObject[] magnetBooks;
    void Start()
    {
        inventoryPlayerScript = FindObjectOfType<InventoryPlayer>();
        eButton.SetActive(false);
        upgradesScript = FindObjectOfType<AllPlayerUpgradeables>();
        ColourOfBooks();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && canReturn)
        {
            ReturnBooksMagnet(colourOfTheBook);
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
    
    void SpawnBookMagnetMove(string bookColour, Vector3 position)
    {
        
            Instantiate(magnetBooks[0], position, magnetBooks[0].transform.rotation);
            //Make a script on the book that finds the closest book shelf with tag
            //then make that transform its target
     
    }
    public void ReturnBooksMagnet(string bookColour)
    {
        for (int i = 0; i < upgradesScript.numberOfSlot; i++) //slots.Length
        {
            kid = FindChildWithTag(inventoryPlayerScript.slots[i], bookColour);

            if (kid != null && kid.tag == bookColour)
            {
                SpawnBookMagnetMove(bookColour,inventoryPlayerScript.slots[i].transform.position);
                Slot slot = inventoryPlayerScript.slots[i].GetComponent<Slot>();
                slot.DestroyBook();

            }
        }
    }
}
