using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioMixer audioMixer;

    public static AudioManager instance;

    void Awake()
    {
        if (AudioManager.instance == null)
        {
            DontDestroyOnLoad(gameObject);
            AudioManager.instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        //Get the saved music volume, standard = 10f
        float music = PlayerPrefs.GetFloat("volume", 10f);

        //Set the music volume to the saved volume
        AdjustMusicVolume(music);
    }

    public void AdjustMusicVolume(float volume)
    {
        //Update AudioMixer
        audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
        //Update PlayerPrefs "Music"
        PlayerPrefs.SetFloat("volume", volume);
        //Save changes
        PlayerPrefs.Save();
    }
}

