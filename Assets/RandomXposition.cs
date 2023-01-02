using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomXposition : MonoBehaviour
{
    public float randomX;
    float randomY;
    // Start is called before the first frame update
    void Start()
    {
        randomY = Random.Range(-1f, 1f);
        randomX = Random.Range(-0.3f, 0.3f);
        transform.position += new Vector3(randomX, randomY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
