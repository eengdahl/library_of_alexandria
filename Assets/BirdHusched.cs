using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHusched : MonoBehaviour
{
    MakeHuschSound makeHuschSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        makeHuschSound = FindObjectOfType<MakeHuschSound>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Husch" && makeHuschSound.doesHuschSound == true)
        {
            Debug.Log("should top sound");
            audioSource.volume = 0;
        }
    }
}
