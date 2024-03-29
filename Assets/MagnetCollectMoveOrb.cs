using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCollectMoveOrb : MonoBehaviour
{
    AudioSource aS;
    GameObject playerMagnet;
    GameObject player;
    Vector3 playerPosition;
    bool moveAway = true;
    Stamina staminaScript;
    float speed = 1;
    float timer;
    float destroyTimer;
    PickUpSoundsStamina pickUpSounds;
    private void Start()
    {
        aS = GetComponent<AudioSource>();
        pickUpSounds = FindObjectOfType<PickUpSoundsStamina>();
        playerMagnet = GameObject.FindGameObjectWithTag("PickUpMagnet");
        player = GameObject.FindGameObjectWithTag("Player");
        staminaScript = player.GetComponent<Stamina>();
    }
    void Update()
    {//Om inventory �r fullt k�r inte detta p� b�cker
        if (moveAway)
        {
            timer += Time.deltaTime;

            if (timer < 0.2)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerPosition, -1 * speed * Time.deltaTime);
            }
            else
            {
                destroyTimer += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, playerMagnet.transform.position, 30 * Time.deltaTime);
                if (transform.position == playerMagnet.transform.position && destroyTimer > 0.2f)
                {
                    staminaScript.stamina += 5;
                    int indexPicker;
                    indexPicker = Random.Range(0, pickUpSounds.audioClipList.Count);
                    AudioSource.PlayClipAtPoint(pickUpSounds.audioClipList[indexPicker], transform.position, 0.8f);
                    //pickUpSounds.PlayPickUpSoundStamina();
                    Destroy(gameObject);
                }
            }
        }
    }
}

