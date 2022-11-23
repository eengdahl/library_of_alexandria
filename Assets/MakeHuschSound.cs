using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHuschSound : MonoBehaviour
{
    public AudioClip schhSound;
    AudioSource audioSource;
    MakeNPCStop makeNpcStop;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        makeNpcStop = GetComponent<MakeNPCStop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.Play();
        }
            
    }
}
