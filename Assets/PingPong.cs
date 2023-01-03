using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float speed;
    Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * distance;//* 6 - 3
        transform.position = startPos + new Vector3(0, y, 0);
    }
}

