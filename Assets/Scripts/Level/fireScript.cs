using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScript : MonoBehaviour
{
    public AudioClip sorry;
    public AudioSource aS;
    public AudioClip fireSound;
    MakeHuschSound makeHuschSound;



    private void Awake()
    {
        aS = GetComponent<AudioSource>();
        makeHuschSound = FindObjectOfType<MakeHuschSound>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Husch" && makeHuschSound.doesHuschSound == true)
        {

            int easter;
            easter = Random.Range(0, 1000);
            if (easter > 998)
            {
                Debug.Log("ping");
                aS.clip = sorry;
                aS.loop = false;
                aS.volume = 0.5f;
                aS.Play();
                Invoke("ResetAudioSource", 1);
            }
        }
    }
    private void ResetAudioSource()
    {
        aS.volume = 0.1f;
        aS.clip = fireSound;
        aS.loop = true;
        aS.Play();
    }
}
