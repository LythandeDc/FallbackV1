using UnityEngine;
using System.Collections;

public class EnemieController : MonoBehaviour
{
    public GameObject target; // la cible de l'enemie
    public PlayerController targetscript;
    public float distance; // la distance entre la cible et l'ennemi
    public float attack = 0.9f; // la distance d'attaque de l'ennemi avant d'attaquer
    public float run = 6.0f; // la distance d'attaque de l'ennemi avant de courir vers le player
    public float speed = 0.5f; // rapidité de l'ennemi
    public float pheight = -2.1f;
    public int xptogive = 10;
    public bool crunning = false;

    Animator Anim;

    public AudioClip SoundHit, SoundDead;

    public bool pause = false, dead = false, isAttacking = false;

    public int point = 20; // 20 points en tuant l'enemie
    public int enemieLife = 50; // vie de l'enemie
    public int attacklife = 10; // enlève 10 points 

    // Démarrage du jeu
    void Start ()
    {
        Anim = GetComponent<Animator> (); // on récupère l'animation de l'ennemi
        Anim.SetBool("attack", false);
        Anim.SetBool("walk", false);
        GetComponent<AudioSource>().volume = 0.8f;
    }
	
	// Mise à jour par frame
	void Update ()
    {
        // dans les parantèses 1 la position de l'ennemi, 2 la cible
        distance = Vector2.Distance(transform.position, target.transform.position);

        // Si la distance est plus petite que l'attaque et l'ennemi n'est pas en pause alors on fait déplacer l'ennemi
        if (distance < run && distance > attack && !pause && enemieLife != 0) 
        {
            Anim.SetBool("walk", true);
            Anim.SetBool("attack", false);
            Attack();
        }
        else if (distance < attack && !pause && enemieLife != 0)
        {
            Anim.SetBool("attack", true);
            Anim.SetBool("walk", false);
            Attack();
        }

        // L'enemie se déplace par rapport au mouvement du personnage
        if(enemieLife != 0)
        {
            if (transform.position.x > target.transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    // On fait déplacer l'ennemi vers la target 
    void Attack ()
    {
        if(target.transform.position.y <= pheight)
        {
            // Lerp est une interpolation entre deux valeurs selon une valeur. 
            // Le personnage va se déplacer où on lui dit d'aller
            transform.position = Vector2.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Anim.SetBool("attack", false);
            Anim.SetBool("walk", false);
        }
    }

    /// <summary>
    /// On Trigger Stay 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay2D(Collider2D col)
    {
        enemieLife = Mathf.Clamp(enemieLife, 0, 50);

        if (col.gameObject.tag == "attack" && targetscript.isAttacking == true && !dead)
        {
            enemieLife -= 10;
            Anim.SetBool("attack", false);
            Anim.SetBool("walk", false);

            if (enemieLife == 0)
            {
                Anim.SetTrigger("dead"); // trigger dead
                dead = true;

                if (SoundDead != null && GetComponent<AudioSource>().isPlaying == false)
                    GetComponent<AudioSource>().PlayOneShot(SoundDead); // Son du dead

                // GetComponent<EnemieController>().enabled = false; // on desactive le script pour que l'enemie ne marche plus
                GetComponent<BoxCollider2D>().enabled = false; // on desactive le box collider pour ne pas marcher sur la tete de l'ennemi
                GetComponent<Rigidbody2D>().isKinematic = true; // ça désactive le collider mais le perso reste à la meme place
                targetscript.tmpxp += xptogive;
                Debug.Log("currentxp : " + targetscript.tmpxp);

                StartCoroutine(DestroyGO());

                // Ajouter le score
                GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().AddScore(point);
            }
            else if (enemieLife > 0)
            {
                Anim.SetBool("hit", true); // trigger hit
                dead = false;
            }
        }
    }

    /// <summary>
    /// On Trigger Exit 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerExit2D(Collider2D col)
    {
        if(Anim.GetBool("hit") == true)
            Anim.SetBool("hit", false);
    }

    // On détruit l'enemie
    public IEnumerator DestroyGO()
    {
        crunning = true;
        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }

    // Détecter le player en collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && !dead)
        {
            StartCoroutine(hit(col.gameObject));
        }
    }

    /// <summary>
    /// On met en pause l'ennemi une seconde 
    /// avant de réattaquer le player
    /// </summary>
    /// <param name="col"></param>
    /// <returns></returns>
    IEnumerator hit(GameObject col)
    {
        if(SoundHit != null)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundHit);
        }
        pause = true;

        // Le player se déplace par rapport au mouvement de l'ennemie
        /*
        if (transform.position.x > target.transform.position.x)
            col.GetComponent<Rigidbody2D>().velocity = (-Vector2.right * 100 * Time.deltaTime);
        else
            col.GetComponent<Rigidbody2D>().velocity = (Vector2.right * 100 * Time.deltaTime);
        */

        // Reduire la vie
        target.GetComponent<PlayerController>().Anim.SetTrigger("hit");
        GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().RemoveHealth(attacklife);

        yield return new WaitForSeconds(1); // temporisation d'ici une seconde
        pause = false;
    }

    /// <summary>
    /// Stop Hit
    /// </summary>
    /// <returns></returns>
    IEnumerator StopHit()
    {
        yield return new WaitForSeconds(2);
        if(Anim.GetBool("hit") == true)
        {
            Anim.SetBool("hit", false);
        }
    }
}
