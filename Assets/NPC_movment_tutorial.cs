using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_movment_tutorial : MonoBehaviour
{
    public GameObject Mad_NPC;
    public Transform target;
    float speed = 2;
    void Start() 
        {
//speed = 5f;
        }

        void Update() 
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                Mad_NPC.SetActive(true);
            }
        }
}
