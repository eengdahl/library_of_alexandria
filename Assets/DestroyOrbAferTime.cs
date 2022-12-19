using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOrbAferTime : MonoBehaviour
{
    public float destroyAfter;
 
    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }

}
