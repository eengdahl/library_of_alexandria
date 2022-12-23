using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeInventory : MonoBehaviour
{
    private float timer;
    private float magnitude;
    private Vector3 startPos;
    private bool isShaking;
    private float limit;
    private float limitTimer;
    UIAbovePlayer uIAbovePlayer;

    private void Start()
    {
        uIAbovePlayer = GetComponent<UIAbovePlayer>();
    }

    public void StartShake(float time, float str,  float limiter = 0)
    {
        isShaking = true;
        timer = time;
        magnitude = str;
        limit = limiter;
        startPos = this.transform.position; // transform.position
    }

    void Update()
    {

        if (!isShaking)
        {
            uIAbovePlayer.shouldFollow = true;
        }
        if (timer <= 0) return;
        if (!isShaking) return;
        uIAbovePlayer.shouldFollow = false;
        timer -= Time.deltaTime;
        limitTimer -= Time.deltaTime;

        if (limitTimer > 0) return;
        limitTimer = limit;

        transform.position = startPos;
        transform.position += (Vector3)(Random.insideUnitCircle * magnitude);

        isShaking = !(timer <= 0); //kollar om timer inte är mindre än noll och gör isShaking till true
    }
}
