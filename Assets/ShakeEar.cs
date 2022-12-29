using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEar : MonoBehaviour
{
    float shakeTimer;

    Vector3 startPosition;
    Shake shakeScript;
    NoiseHandeler noiseHandelerScript;
    public bool superRedBool;
    public bool shouldShakeYellow = true;
    public bool shouldShakeRed = true;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        shakeScript = GetComponent<Shake>();
        noiseHandelerScript = FindObjectOfType<NoiseHandeler>();
    }

    // Update is called once per frame
    void Update()
    {

        shouldShakeYellow = ShakeDaBooty(shouldShakeYellow,20);
        shouldShakeYellow = ResetShake(20, shouldShakeYellow);
        shouldShakeRed = ResetShake(66, shouldShakeRed);
        shouldShakeRed = ShakeDaBooty(shouldShakeRed,66);

        if(noiseHandelerScript.soundLevelInRoom > 80)
        {

            shakeTimer += Time.deltaTime;
            if (shakeTimer > 0.05)
            {
            transform.localPosition += (Vector3)(Random.insideUnitCircle * 0.1f);
            transform.localPosition = startPosition;
                shakeTimer = 0;
            }
        }
        else
        {
            transform.localPosition = startPosition;
        }

    }
    private bool ResetShake(int resetValue,bool colourBool)
    {
        if (noiseHandelerScript.soundLevelInRoom < resetValue && colourBool == false)
        {
            Debug.Log("Should reset bool");
            return colourBool = true;
        }
        else
        {
            return colourBool;
        }
    }
    private bool ShakeDaBooty(bool colourBool,int levelOfSound)
    {
        if (noiseHandelerScript.soundLevelInRoom > levelOfSound && colourBool) // noiseHandelerScript.soundLevelInRoom <= 22 &&
        {
            shakeScript.StartShake(1, 0.1f, this.transform.localPosition, 0.05f);
            return colourBool = false;
        }
        else
        {
            return colourBool;
        }

    }
}
