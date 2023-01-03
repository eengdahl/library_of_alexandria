using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongSize : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float speed;

    Transform startScale;
    private void Start()
    {
        startScale = transform;

    }
    public void Update()
    {
        float size = Mathf.PingPong(Time.time * speed, 1) * distance;//* 6 - 3
        transform.localScale = startScale.localScale + new Vector3(size, size, 0);
    }
}
