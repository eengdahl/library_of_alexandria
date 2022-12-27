using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicSetting : MonoBehaviour
{
    public Sprite green;
    public Sprite yellow;
    public Sprite red;
    public Slider volume;
    public Image volumeImage;
    public AudioManager audioManager;


    public void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void ChangeVolume()
    {
        if (volume.value > 0)
        {
            volumeImage.sprite = red;
        }
        if (volume.value > -40 && volume.value < 0)
        {
            volumeImage.sprite = yellow;
        }
        if (volume.value > -80 && volume.value < -40)
        {
            volumeImage.sprite = green;
        }

        audioManager.AdjustMusicVolume(volume.value);
    }
}
