using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSoundsStamina : MonoBehaviour
{
    AudioSource aS;
    public List<AudioClip> audioClipList;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
       // audioClipList = new List<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayPickUpSoundStamina()
    {
        int soundPicker = Random.Range(0, audioClipList.Count);
        AudioClip aC = audioClipList[soundPicker];
        aS.clip = aC;
        aS.Play();
    }


}
