using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBookIfNoTable : MonoBehaviour
{
    NPCBookPickUpScript npcBookPickUpScript; // I want the bool to see if NPC got a book (haveBook)
    NPCMovement nPCMovementScript; // I want the bool to see if they have a chair (hasChair)
    float timer;
    public float timerMax = 5f;
    float dropBookPicker;
    public GameObject blankBookObject;
    
    private void Start()
    {
        nPCMovementScript = GetComponentInParent<NPCMovement>();
        npcBookPickUpScript = GetComponent<NPCBookPickUpScript>();
    }

    private void Update()
    {
        //If npc has a book and no chair is empty/ found have  a chance of dropping the book
        if (npcBookPickUpScript.haveBook == true && nPCMovementScript.hasChair  == false)
        {
            //If timer reaches timerMax randomize if the book should be dropped
            timer += Time.deltaTime;
            if(timer >= timerMax)
            {
                //If the random picked number is in range drop book and mark the npc to have haveBook = false 
                dropBookPicker = Random.Range(1, 11);
                if(dropBookPicker >= 7)
                {
                    Instantiate(blankBookObject);
                    npcBookPickUpScript.haveBook = false;       
                }
                timer = 0; // Reset the timer
            }
        }
    }


}
