using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFall : MonoBehaviour
{
    Vector3 targetPos;
    SwayBooksList swayBooksScript;
    Registration registrationScript;
    float randomX;
    
    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(-0.8f, 0.8f);
        swayBooksScript = FindObjectOfType<SwayBooksList>();
        registrationScript = FindObjectOfType<Registration>();
        int thisIndex = registrationScript.registeredBooks.IndexOf(this.gameObject);
        targetPos = new Vector3(transform.position.x+randomX, transform.position.y - (0.2f*thisIndex), 0);      
    }

    // Update is called once per frame
    void Update()
    {
        if(swayBooksScript.toMany == true)
        {
           transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.2f);
            try
            {               
                registrationScript.registeredBooks.Remove(this.gameObject);
            }
            catch (System.Exception)
            {

                Debug.Log("Try failed");
                throw;
            }
            
        }
    }
}
