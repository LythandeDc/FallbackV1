using UnityEngine;
using System.Collections;

public class footSteps : MonoBehaviour {

    public AudioClip SoundfootSteps;
    private AudioSource Audio;
    public float PitchMin=0.9f,PitchMax=1.2f,VolMin=0.8f,VolMax=1.2f; // variables du volume. Pitch minimum, Pitch maximum, Minimum du volume, Maximum du Volume

	
	void Start () {
        Audio = GetComponent<AudioSource> ();
	}	
	
    // on joue avec le son
	void Update () {
	if(Input.GetAxis("Horizontal")!=0) 
        {
            if(!Audio.isPlaying && transform.parent.GetComponent<PlayerController>().isGrounded) // si l'audio source l'audio source ne joue pas et si le player is grounded
            {
                Audio.pitch = Random.Range (PitchMin, PitchMax); // pitch aléatoire de mes variables
                Audio.volume = Random.Range (VolMin, VolMax); // volume aléatoire de mes variables
                Audio.PlayOneShot (SoundfootSteps);
            }
        }
	}
}
