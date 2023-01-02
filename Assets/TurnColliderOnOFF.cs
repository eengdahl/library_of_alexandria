using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnColliderOnOFF : MonoBehaviour
{
    Collider2D stoneCollider;
    [SerializeField] GameObject landingspot;
    float timer;
    bool hasCollided = false;
    [SerializeField] Collider2D walkIntoCollider;
    void Start()
    {
        walkIntoCollider.enabled = false;
        stoneCollider = GetComponent<Collider2D>();
        stoneCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == landingspot.transform.position)
        {
            if (!hasCollided)
            {
                stoneCollider.enabled = true;
                
            }
            timer += Time.deltaTime;
            if(timer > 0.1)
            {
                walkIntoCollider.enabled = true;
                stoneCollider.enabled = false;
                hasCollided = true;
            }
        }
    }
}
