using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeInventoryRotate : MonoBehaviour
{

    float tiltSpeed = 40;
    float angle;
    float targetAngle;
    bool shouldRotate;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        targetAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, tiltSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, angle);

        if(shouldRotate == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f && timer < 0.2f)
            {
                Debug.Log("Should Rotate");
                targetAngle = 6;
            }
            else if (timer >= 0.3f && timer < 0.4f)
            {
                targetAngle = -6;
            }
            else if (timer >= 0.5)
            {              
                targetAngle = 0;
                shouldRotate = false;
                timer = 0;
            }
        }
        //if(shouldRotate == true)
    }

    public void RotateInventory()
    {
        shouldRotate = true;
    }
}
