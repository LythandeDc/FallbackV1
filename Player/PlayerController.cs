using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Declarations de variables
    int[] Levels;
    int requiredXp;
    public int speed = 7, jump = 300; // vitesse de déplacement
    public int goldP;
    public int tmpxp; // currents xp
    public int tmpLevel; // current level

    public bool isGrounded = false; // permet de savoir si le player est au sol
    public bool isJumping = false; // permet de savoir si le player saute
    public bool isAttacking = false;
    public bool isTalking = false;
    public bool canMove;
    private bool onPlatform;

    public float onPlatformSpeedModifier;
    private float activeMoveSpeed;
    public float knockbackForce;
    public float knockbackLength;
    private float knockbackCounter;
    public float invincibilityLength;
    private float invincibilityCounter;

    public PlayerInterface theLevelManager;

    public Animator Anim;
    public AudioClip soundJump, soundDead, hurtSound; // on déclare les variables des sons
    private AudioSource Audio;
    public Coins TheCoinsC;
    public PlayerInterface pInterface;
    public GameObject Attack;
    public Rigidbody2D myRigidbody;
    public Vector3 respawnPosition;

    public DialogueManager dManager;
    private DialogueTrigger dTrigger;

    /// <summary>
    /// START
    /// </summary>
    void Start()
    {
        Anim = GetComponent<Animator>(); // il faut chercher le composant animator sur notre objet pour le charger
        Audio = GetComponent<AudioSource>(); // pour utiliser l'audiosource
        myRigidbody = GetComponent<Rigidbody2D>();
        theLevelManager = FindObjectOfType<PlayerInterface>();
        respawnPosition = transform.position;
        canMove = true;

        if (GameInformation.Gold > 0)
            goldP = GameInformation.Gold;
        else
            goldP = 0;

        if (GameInformation.PlayerLevel > tmpLevel)
            tmpLevel = GameInformation.PlayerLevel;
        else
            tmpLevel = 1;


        int maxlevel = 100;
        Levels = new int[maxlevel]; /* Level is an array of 100 integers */

        for (int i = 0; i < maxlevel; i++)
        {
            Levels[i] = i + 1;
        }
    }

    /// <summary>
    /// UPDATE
    /// </summary>
    void Update()
    {
        // Time.deltaTime sert à uniformiser la vitesse de déplacement selon la puissance de la machine
        // horizontal. input manager. l'axe sur les touches left et right. On recupère la valeur de la position.
        float h = Input.GetAxis("Horizontal"); 
        // pour déplacer un vecteur de translation un personnage de la gauche, droite, haut. 
        transform.Translate(Vector2.right * h * speed * Time.deltaTime); 

        if (onPlatform)
        {
            activeMoveSpeed = speed * onPlatformSpeedModifier;
            canMove = true;
            isGrounded = true;
        }
        else
        {
            activeMoveSpeed = speed;
        }

        if (isGrounded || isJumping)
        {
            if (h > 0) GetComponent<SpriteRenderer>().flipX = false; Anim.SetBool("walk", true); // droite
            if (h < 0) GetComponent<SpriteRenderer>().flipX = true; Anim.SetBool("walk", true); // gauche. Flip pour le sens de déplacement du player
            if (h == 0) Anim.SetBool("walk", false); // je repasse à idle
        }

        // DEAD
        if (Input.GetKeyDown(KeyCode.O)) // temporaire, pour tester le dead
        {
            playerDead();
        }

        // ATTACK
        if(Input.GetKeyDown(KeyCode.V))
        {
            Anim.SetBool("attack", true);
            isAttacking = true;

            foreach (Collider2D c in Attack.GetComponents<Collider2D>())
            {
                c.enabled = true;
            }
        }
        else
        {
            if (isAttacking)
            {
                Anim.SetBool("attack", false);
                isAttacking = false;
                StartCoroutine(LateCall());
            }
        }

        if(Input.GetMouseButton(0))
        {
            // Debug.Log("Mouse Button Right");
        }

        // TALK
        if (Input.GetKeyDown(KeyCode.C))
            isTalking = true;
        else
            isTalking = false;

        LevelPointsManager();        
        TheGold();
    }

    // Il se déclence à un temps donné. Ca soulage les ressources. Ca fonctionne aussi avec l'update mais c'est déconseillé.
    void FixedUpdate()
    {
        // si isGrounded = true alors on saute une seule et unique fois
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown("space")) && isGrounded && isJumping == false) 
        {
            Audio.PlayOneShot(soundJump);
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jump * Time.deltaTime; // Time.deltaTime pour uniformiser le saut. Pour bouger le personnage avec le temps
            Anim.SetTrigger("jump"); // on lance l'animation trigger pour sauter
            Anim.SetBool("walk", false); // il ne doit pas marcher pendant qu'il saute
            Anim.SetBool("attack", false);
            Debug.Log("Sauté");
        }
    }

    // lancer la méthode d'un autre script
    public void playerDead()
    {
        // Verification HightScore
        int score = GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().score; // Récuperer le score qui est dans le script interface
        int HS = PlayerPrefs.GetInt("HS"); // recupère le score

        if (score > HS)
        {
            PlayerPrefs.SetInt("HS", score);
        }

        Anim.SetTrigger("dead");
        Audio.PlayOneShot(soundDead);
        GetComponent<PlayerController>().enabled = false; // le perso ne bouge plus
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(LoadGameOver());
    }

    /// <summary>
    /// THE GOLD
    /// Fonction à updater dès qu'on fait une sauvegarde
    /// </summary>
    /// <returns></returns>
    public int TheGold()
    {
        if(GameInformation.Gold != 0)
            return goldP + GameInformation.Gold;
        else
            return goldP;
    }

    /// <summary>
    /// THE HEALT
    /// Fonction à updater dès qu'on fait une sauvegarde
    /// </summary>
    /// <returns></returns>
    public float TheHealth()
    {
        return pInterface.Health;
    }

    /// <summary>
    /// KNOCK BACK
    /// </summary>
    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        invincibilityCounter = invincibilityLength;
        // theLevelManager.invincible = true;
    }

    /// <summary>
    /// On Collision Enter
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = col.transform;
            // transform.position = col.transform.position;
            onPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            GameObject gc = GameObject.FindGameObjectWithTag("GC");
            transform.parent = gc.transform;
        }
    }

    /// <summary>
    /// On Trigger Enter 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "KillPlane")
        {
            // Si on meurt on reprend du point de controle
            // theLevelManager.currentLives = theLevelManager.currentLives - 1;
            if(theLevelManager.respawnCall == false)
            {
                theLevelManager.respawnCall = true;
                theLevelManager.Respawn();
            }
            Debug.Log(theLevelManager.currentLives);
        }

        if(col.tag == "Checkpoint")
        {
            respawnPosition = col.transform.position;
        }
    }

    /// <summary>
    /// On trigger stay 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "dialogue")
        {
            // TALK
            if(isTalking == true)
            {
                if (dManager.isOpen == false && dManager.canTalk == true)
                {
                    // Debug.Log("false. Is open : " + dManager.isOpen + ". Can talk : " + dManager.canTalk);
                    col.GetComponent<DialogueTrigger>().TriggerDialogue();
                }
                /*
                else if (dManager.isOpen == true && dManager.canTalk == false)
                {
                    Debug.Log("true. Is open : " + dManager.isOpen + ". Can talk : " + dManager.canTalk);
                    col.GetComponent<DialogueTrigger>().manager.DisplayNextSentence();
                }
                */
            }
        }
    }

    /// <summary>
    /// Level Points
    /// </summary>
    private void LevelPointsManager()
    {
        foreach (int value in Levels)
        {
            // Add level
            if (tmpLevel == value)
            {
                requiredXp = value * 50;

                if (tmpxp == requiredXp)
                {
                    tmpxp = 0;
                    tmpLevel += 1;
                }
            }
        }
    }

    /// <summary>
    /// LATE CALL
    /// SET ACTIVE FALSE TO ATTACK
    /// AFTER 4 SEC
    /// </summary>
    /// <returns></returns>
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(4);
        foreach (Collider2D c in Attack.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
    }

    /// <summary>
    /// LOAD GAME OVER
    /// </summary>
    /// <returns></returns>
    public IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }
}
