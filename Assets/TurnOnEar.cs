using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnEar : MonoBehaviour
{
    [SerializeField] GameObject Ear;
    void Start()
    {
        Ear.SetActive(true);
    }


}
