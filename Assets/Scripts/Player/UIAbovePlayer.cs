using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbovePlayer : MonoBehaviour
{
    public float yAxis = 1.7f;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yAxis, 0);
    }
}
