using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
    private float timer;
    private float magnitude;
    private Vector3 startPos;
    private bool isShaking;
    private float limit;
    private float limitTimer;
    

    public void StartShake(float time, float str, Vector3 startPosition, float limiter = 0)
    {
        isShaking = true;
        timer = time;
        magnitude = str;
        limit = limiter;
        startPos = startPosition; // transform.position
    }

    void Update()
    {
        
  
        if (timer <= 0) return;
        if (!isShaking) return;

        timer -= Time.deltaTime;
        limitTimer -= Time.deltaTime;

        if (limitTimer > 0) return;
        limitTimer = limit;

        transform.localPosition += (Vector3)(Random.insideUnitCircle * magnitude);
        transform.localPosition = startPos;

        isShaking = !(timer <= 0); //kollar om timer inte är mindre än noll och gör isShaking till true
    }
}
