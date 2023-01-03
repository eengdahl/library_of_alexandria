using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TimerForTItle : MonoBehaviour
{
    public SpriteRenderer continueButton;
    public TMP_Text continueText;
    public float timer;
    public AudioClip huschSound;
    AudioSource aS;
    void Start()
    {
        PlayerPrefs.SetInt("levelCompleted", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        aS = GetComponent<AudioSource>();
        continueButton.enabled = false;
        continueText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            continueButton.enabled = true;
            continueText.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            aS.PlayOneShot(huschSound);
            Invoke("LoadMenu", huschSound.length);
            
        }

    }
    void LoadMenu()
    {
        SceneManager.LoadScene("Meny");
    }
}
