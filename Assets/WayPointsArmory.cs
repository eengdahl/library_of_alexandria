using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsArmory : MonoBehaviour
{
    public Transform[] firstArray;
    public Transform[] secondArray;
    public Transform[] thirdArray;
    public Transform[] forthArray;
    List<Transform[]> arrayOfTransformArrays;
    
    // Start is called before the first frame update
    void Start()
    {
        arrayOfTransformArrays = new List<Transform[]>();
        arrayOfTransformArrays.Add(firstArray);
        arrayOfTransformArrays.Add(secondArray);
        arrayOfTransformArrays.Add(thirdArray);
        arrayOfTransformArrays.Add(forthArray);
    }
    
    public Transform[] GetArray(int index)
    {
        Transform[] returnArray;
        returnArray = arrayOfTransformArrays[index];

        return returnArray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
