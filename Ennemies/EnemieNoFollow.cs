using UnityEngine;
using System.Collections;

public class EnemieNoFollow : MonoBehaviour
{
    public Transform PtsA, PtsB;
    public float speed = 0.5f;

    bool Retour = false; // le sense de l'ennemi
    public bool dead = false;

    public int point = 20; // 20 points en tuant l'enemie mal
    public int attacklife = 10; // enlève 10 points
    public int xptogive = 10;
    public int enemieLife = 20;

    Animator Anim;
    public AudioClip SoundDead, SoundHit; // de l'ennemi

    public PlayerController targetscript;

    /// <summary>
    /// START
    /// </summary>
    void Start ()
    {
        Anim = GetComponent<Animator>();
	}
	
	/// <summary>
    /// UPDATE
    /// </summary>
	void Update ()
    {
        // Empeche de pousser en bas l'enemie
        if(transform.position.x > PtsB.transform.position.x)
        {
            transform.position = new Vector2(PtsB.transform.position.x, transform.position.y);
        }
        if (transform.position.x < PtsA.transform.position.x)
        {
            transform.position = new Vector2(PtsA.transform.position.x, transform.position.y);
        }

        if (!Retour)
        {
            transform.position = Vector2.MoveTowards(transform.position, PtsB.position, speed * Time.deltaTime); // MoveTowards permet de créer un vecteur de déplacement d'un point à un autre
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, PtsA.position, speed * Time.deltaTime);
        }
	}

    /// <summary>
    /// ON TRIGGER ENTER 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "PtsA")
        {
            Retour = false;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (col.gameObject.name == "PtsB")
        {
            Retour = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(col.gameObject.tag == "attack" && !dead)
        {
            dead = true;
            if(SoundDead != null)
                GetComponent<AudioSource>().PlayOneShot(SoundDead);

            Anim.SetTrigger("dead");
            GetComponent<Rigidbody2D>().isKinematic = true; // fixe le rigidbody où il est. ça désactive le collider mais le perso reste à la meme place
            // GetComponent<EnemieNoFollow>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false; // on desactive le box collider pour ne pas marcher sur la tete de l'ennemi
            // Ajouter le score
            GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().AddScore(point);
        }
    }

    // Mort de l'ennemi
    IEnumerator DestroyGO()
    {
        yield return new WaitForSeconds(2);
        // Destroy(gameObject);
        targetscript.tmpxp += xptogive;
        gameObject.SetActive(false);
    }

    // Détecter le player en collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && !dead)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundHit);
            // Reduire la vie
            GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().RemoveHealth(attacklife);
        }
    }
}
