using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
    //private float timer;
    //private float magnitude;
    //private Vector3 startPos;
    //private bool isShaking;
    //private float limit;
    //private float limitTimer;
    public float timer;
    public float magnitude;
    public Vector3 startPos;
    public bool isShaking;
    public float limit;
    public float limitTimer;

    public void StartShake(float time, float str, Vector3 startPosition, float limiter = 0)
    {
        isShaking = true;
        timer = time;
        magnitude = str;
        limit = limiter;
        startPos = startPosition; //Why not transform.position??
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.O)) StartShake(1, 0.1f, this.transform.position, 0.05f);//kommentera bort och och använd för att calla funktionen

        if (timer <= 0) return;//
        if (!isShaking) return;

        timer -= Time.deltaTime;
        limitTimer -= Time.deltaTime;

        if (limitTimer > 0) return;
        limitTimer = limit;

        transform.position = startPos;
        transform.position += (Vector3)(Random.insideUnitCircle * magnitude);

        isShaking = !(timer <= 0); //kollar om timer inte är mindre än noll och gör isShaking till true
    }
}
