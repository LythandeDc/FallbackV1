using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getLife : MonoBehaviour
{
    public int thelife = 10;
    public AudioClip getHearth;
    public GameObject checkPoint;

    private SpriteRenderer spritelife;
    private CircleCollider2D circlelife;
    private Animator anim;

    /// <summary>
    /// START
    /// </summary>
    void Start()
    {
        spritelife = gameObject.GetComponent<SpriteRenderer>();
        circlelife = gameObject.GetComponent<CircleCollider2D>();
        anim = gameObject.GetComponent<Animator>();

        if (checkPoint != null)
        {
            spritelife.enabled = false;
            circlelife.enabled = false;
        }
    }

    /// <summary>
    /// UPDATE
    /// </summary>
    void Update()
    {
        if(checkPoint != null)
        {
            if (checkPoint.GetComponent<CheckpointController>().checkpointActive == true)
            {
                spritelife.enabled = true;
                anim.SetTrigger("hgo");
                StartCoroutine("AfterAnim");
            }
        }            
    }

    /// <summary>
    /// On Trigger Enter 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Collision avec le coeur !");
            if(getHearth)
                GetComponent<AudioSource>().PlayOneShot(getHearth);
            // Donner de la vie
            GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().GiveHealth(thelife);
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }

    /// <summary>
    /// AFTER ANIM
    /// </summary>
    /// <returns></returns>
    IEnumerator AfterAnim()
    {
        yield return new WaitForSeconds(1);
        circlelife.enabled = true;
    }
}