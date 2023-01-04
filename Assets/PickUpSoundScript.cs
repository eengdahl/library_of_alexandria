using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSoundScript : MonoBehaviour
{
    AudioSource aS;
    [SerializeField]AudioClip pickUpSound;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayPickUpSound()
    {
        aS.clip = pickUpSound;
        aS.Play();
    }
}
