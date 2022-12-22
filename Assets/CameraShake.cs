using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    NoiseHandeler noiseHandelerScript;
    Shake shakeScript;
    public ShakeEar shakeEarScript;
    Vector3 startPosition;
    float shakeTimer = 0.05f;
    void Start()
    {
        startPosition = transform.position;
        noiseHandelerScript = FindObjectOfType<NoiseHandeler>();
        shakeScript = GetComponent<Shake>();
    }


    void Update()
    {
        if (noiseHandelerScript.soundLevelInRoom > 90 && noiseHandelerScript.soundLevelInRoom<100)
        {
            shakeTimer += Time.deltaTime;
            if (shakeTimer > 0.05)
            {
                transform.position = startPosition;
                transform.position += (Vector3)(Random.insideUnitCircle * 0.1f);
                shakeTimer = 0;
            }
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
