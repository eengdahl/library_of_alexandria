using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomWhenHusching : MonoBehaviour
{
    // The rate at which the camera will zoom, in units per second
    public float zoomRate = 1.0f;
    MakeHuschSound makeHuschSoundScript;
    float newSize;
    private void Start()
    {
        makeHuschSoundScript = FindObjectOfType<MakeHuschSound>();
    }
    void Update()
    {
        // Increase the camera's size by the zoom rate on each frame
        //Camera.main.orthographicSize -= zoomRate * Time.deltaTime;
        if (makeHuschSoundScript.zoomIn)
        {
        newSize = Camera.main.orthographicSize - zoomRate * Time.deltaTime;

        }
        else
        {
            newSize = Camera.main.orthographicSize + zoomRate * Time.deltaTime;
        }
        // Clamp the camera size within a certain range
        newSize = Mathf.Clamp(newSize, 3.8f, 3.9f);

        Camera.main.orthographicSize = newSize;
    }
}
