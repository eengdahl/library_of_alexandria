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
    public GameObject speakerGreen0;
    public GameObject speakerGreen1;
    public GameObject speakerYellow0;
    public GameObject speakerYellow1;
    public GameObject speakerRed0;
    public GameObject speakerRed1;



    public void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void ChangeVolume()
    {
        if (volume.value > 0)
        {
            volumeImage.sprite = red;
            speakerRed0.SetActive(true);
            speakerRed1.SetActive(true);
            speakerGreen0.SetActive(false);
            speakerGreen1.SetActive(false);
            speakerYellow0.SetActive(false);
            speakerYellow1.SetActive(false);
        }
        if (volume.value > -40 && volume.value < 0)
        {
            volumeImage.sprite = yellow;
            speakerRed0.SetActive(false);
            speakerRed1.SetActive(false);
            speakerGreen0.SetActive(false);
            speakerGreen1.SetActive(false);
            speakerYellow0.SetActive(true);
            speakerYellow1.SetActive(true);
        }
        if (volume.value > -80 && volume.value < -40)
        {
            volumeImage.sprite = green;
            speakerRed0.SetActive(false);
            speakerRed1.SetActive(false);
            speakerGreen0.SetActive(true);
            speakerGreen1.SetActive(true);
            speakerYellow0.SetActive(false);
            speakerYellow1.SetActive(false);

        }

        audioManager.AdjustMusicVolume(volume.value);
    }
}
