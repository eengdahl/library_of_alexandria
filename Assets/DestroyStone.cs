using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : MonoBehaviour
{
    [SerializeField]GameObject Stone;
    [SerializeField] GameObject landingspot;
    float timer;

    private void Update()
    {
        if(Stone.transform.position == landingspot.transform.position)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                Destroy(gameObject);
            }
        }
    }


}
