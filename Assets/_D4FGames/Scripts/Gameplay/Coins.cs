using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int point = 10;
    AudioSource audioSource;
    public AudioClip getCoin;
    public int gold;
    public float volume = 1.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           // Play the sound only on the trigger
            audioSource.PlayOneShot(getCoin, volume);
            // Add score
            GameObject.Find("Player").GetComponent<PlayerController>().goldP += point;

            Debug.Log(gold + " dans trigger");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
