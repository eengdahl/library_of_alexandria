using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayBook : MonoBehaviour
{
   

    Vector3 startAngle; //refference to start
    float swaySpeed = 0.5f; //the speed of the sway
    public float maxSway = 0.03f;
    float finalSway;
    float timer;
    float offsetIncrease;
    Registration registrationScript;
    private void Start()
    {
        registrationScript = FindObjectOfType<Registration>();
        startAngle = transform.position;
        swaySpeed += registrationScript.registeredBooks.IndexOf(this.gameObject) / 100f;
        maxSway += registrationScript.registeredBooks.IndexOf(this.gameObject) / 100f;
    }
    private void Update()
    {       
        Debug.Log(registrationScript.registeredBooks.IndexOf(this.gameObject));
        timer = Time.deltaTime;
        finalSway = startAngle.x + Mathf.Sin(timer * swaySpeed) *maxSway;//maxSway instead of offsetIncrease to keep all same+ offsetIncrease
        transform.position = new Vector3(finalSway, startAngle.y, startAngle.z);
    }
}
