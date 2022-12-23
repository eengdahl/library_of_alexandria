//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ShakeInventoryTest : MonoBehaviour
//{

//    //shake based on rotation instead of postion
//    private float timer;
//    private float magnitude;
//    private Quaternion startRot;
//    private bool isShaking;
//    private float limit;
//    private float limitTimer;


//    public void StartShake(float time, float str, Quaternion startPosition, float limiter = 0)
//    {
//        isShaking = true;
//        timer = time;
//        magnitude = str;
//        limit = limiter;
//        startRot = startPosition; // transform.position
//    } 
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (timer <= 0) return;
//        if (!isShaking) return;

//        timer -= Time.deltaTime;
//        limitTimer -= Time.deltaTime;

//        if (limitTimer > 0) return;
//        limitTimer = limit;

//        transform.rotation = startRot;
//        transform.rotation += (Quaternion.Euler)(Random.insideUnitCircle * magnitude);

//        isShaking = !(timer <= 0); //kollar om timer inte är mindre än noll och gör isShaking till true
//    }
//}

