using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsArmory : MonoBehaviour
{
    public Transform[] firstArray;
    public Transform[] secondArray;
    public Transform[] thirdArray;
    public Transform[] forthArray;
    List<Transform[]> listOfTransformArrays;

    // Start is called before the first frame update

    private void Awake()
    {
        listOfTransformArrays = new List<Transform[]>();
        listOfTransformArrays.Add(firstArray);
        listOfTransformArrays.Add(secondArray);
        listOfTransformArrays.Add(thirdArray);
        listOfTransformArrays.Add(forthArray);
    }
    void Start()
    {
        //listOfTransformArrays = new List<Transform[]>();
        //listOfTransformArrays.Add(firstArray);
        //listOfTransformArrays.Add(secondArray);
        //listOfTransformArrays.Add(thirdArray);
        //listOfTransformArrays.Add(forthArray);
    }
    
    public Transform[] GetArray(int index)
    {
        Transform[] returnArray;
        returnArray = listOfTransformArrays[index];

        return returnArray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
