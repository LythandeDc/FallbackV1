using UnityEngine;
using System.Collections;

public class isGroundedScript : MonoBehaviour
{
    public AudioClip soundGroud; // qui stoque l'audioclip
    private AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // quand quelque chose pénètre dans le trigger
    void OnTriggerEnter2D(Collider2D col)
    {
        // on cherche le parent (player) et on cherche la variable is grounded
        // transform.parent.GetComponent<PlayerController>().isGrounded = true; 
        Audio.pitch = 1; // valeur normale. différence entre le footstep et le volume de contact (jump)
        if(soundGroud != null)
        {
            Audio.volume = 1; // valeur normale
            Audio.PlayOneShot(soundGroud); // on lance le son de jump
        }
    }

    // on cherche le parent (player) et on cherche la variable is grounded
    void OnTriggerStay2D(Collider2D col)
    {
        transform.parent.GetComponent<PlayerController>().isGrounded = true; 
        transform.parent.GetComponent<PlayerController>().isJumping = false;
        transform.parent.GetComponent<PlayerController>().canMove = true;
    }

    // on passe le trigger à false
    void OnTriggerExit2D(Collider2D col)
    {
        transform.parent.GetComponent<PlayerController>().isGrounded = false;
        transform.parent.GetComponent<PlayerController>().isJumping = true;
        transform.parent.GetComponent<PlayerController>().canMove = false;
    }
}
