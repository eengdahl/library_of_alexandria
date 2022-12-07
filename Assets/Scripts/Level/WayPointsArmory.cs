using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsArmory : MonoBehaviour
{
    //Walking arrays
    public Transform[] firstArray;
    public Transform[] secondArray;
    public Transform[] thirdArray;
    public Transform[] forthArray;
    public Transform[] fithArray;
    public Transform[] sixthArray;
    public Transform[] seventhArray;


    //The lists of transforms
    List<Transform[]> listOfWalkningTransformArrays;
    List<Transform[]> listOfExitArrays;
    List<Transform[]> listOfReasercherArrays;


    //Exit arrays
    public Transform[] firstExitArray;
    public Transform[] secondExitArray;
    public Transform[] thirdExitArray;
    public Transform[] forthExitArray;
    //Researcher arrays
    public Transform[] researcherArrayOne;
    public Transform[] researcherArrayTwo;

    // Start is called before the first frame update

    private void Awake()
    {
        //Researcher Arrays
        listOfReasercherArrays = new List<Transform[]>();
        listOfReasercherArrays.Add(researcherArrayOne);
        listOfReasercherArrays.Add(researcherArrayTwo);


        //Normal walking
        listOfWalkningTransformArrays = new List<Transform[]>();
        listOfWalkningTransformArrays.Add(firstArray);
        listOfWalkningTransformArrays.Add(secondArray);
        listOfWalkningTransformArrays.Add(thirdArray);
        listOfWalkningTransformArrays.Add(forthArray);
        listOfWalkningTransformArrays.Add(fithArray);
        listOfWalkningTransformArrays.Add(sixthArray);
        listOfWalkningTransformArrays.Add(seventhArray);
        //Exit Arrays //make NPC pick one of these depending on wich table they are sitting by and are done reading.
        listOfExitArrays = new List<Transform[]>();
        listOfExitArrays.Add(firstExitArray);
        listOfExitArrays.Add(secondExitArray);
        //listOfExitArrays.Add(thirdExitArray);
        //listOfExitArrays.Add(forthExitArray);
    }
    void Start()
    {
       
    }
    public Transform[] ResearcherGetArray(int index)
    {
        Transform[] returnArray;
        returnArray = listOfReasercherArrays[index];

        return returnArray;
    }
    public Transform[] GetArray(int index)
    {
        Transform[] returnArray;
        returnArray = listOfWalkningTransformArrays[index];

        return returnArray;
    }
    public Transform[] GetExitArray(int index)
    {
        Transform[] returnArray;
        returnArray = listOfExitArrays[index];

        return returnArray;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
