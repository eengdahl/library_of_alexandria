using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairOccupied : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject table;
    public bool chairOccupied;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        chairOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(chairOccupied == false)
        {

            spriteRenderer.sortingOrder = 1;
        }
        else if  (chairOccupied == true)
        {
            spriteRenderer.sortingOrder = 0;
        }
    }
}
