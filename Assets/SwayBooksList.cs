using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayBooksList : MonoBehaviour
{
    Vector3 startAngle; //refference to start
    float swaySpeed = 0.5f; //the speed of the sway
    public float maxSway = 0.03f;
    float finalSway;
    float timer;
    public bool toMany;
    public GameObject spawnPoint;
    Registration registrationScript;
    [SerializeField] int maxAmountOfBooks;
    private void Start()
    {
        registrationScript = FindObjectOfType<Registration>();
        toMany = false;
        startAngle = spawnPoint.transform.position;

    }
    private void Update()
    {
        
        if (registrationScript.registeredBooks.Count >= maxAmountOfBooks)
        {
            toMany = true;
        }

        if (!toMany) { 
        
        if (registrationScript.registeredBooks.Count >= 5)
        {
            for (int i = 0; i < registrationScript.registeredBooks.Count; i++)
            {
                if (i == 0)
                {

                    startAngle = spawnPoint.transform.position;
                }
                else
                {
                    startAngle = registrationScript.registeredBooks[i - 1].transform.position;
                }

                float swaySpeedThis = swaySpeed + (i / 100f); //Was good until 15+ books swaySpeed + (i / 200f)
                    float maxSwayThis = maxSway + (i / 600f);


                finalSway = startAngle.x + Mathf.Sin(timer * swaySpeedThis) * maxSwayThis;
                registrationScript.registeredBooks[i].transform.position = new Vector3(finalSway, startAngle.y + 0.1f, startAngle.z);
            }
            timer += Time.deltaTime;
        }
        else //If the books shouldnt sway give them x position as the same as spawnpoint;
        {
            for (int i = 0; i < registrationScript.registeredBooks.Count; i++)
            {

                if (i == 0)
                {

                    startAngle = spawnPoint.transform.position;
                }
                else
                {
                    startAngle = registrationScript.registeredBooks[i - 1].transform.position;
                }

                registrationScript.registeredBooks[i].transform.position = new Vector3(spawnPoint.transform.position.x, startAngle.y + 0.1f, 0);
            }
           }       
        }     
    }
}
