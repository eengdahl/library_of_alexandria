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
        startPosition = transform.localPosition;
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
                Debug.Log("Should shake Screen");
                transform.localPosition += (Vector3)(Random.insideUnitCircle * 0.1f); //0.1f
                shakeTimer = 0;
            }
            else
            {
                //transform.localPosition = startPosition;

            }
        }
        else
        {
            transform.localPosition = startPosition;

        }
    }
}
