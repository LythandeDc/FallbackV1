using UnityEngine;
using System.Collections;
using UnityEngine.UI; // types UI
using System;

public class PlayerInterface : MonoBehaviour
{
    public Text TxtScore;
    public Text TxtTime;
    public Text TxtLife;
    public Text livesText;

    public int score;
    public int startingLives;
    public int currentLives;
    public int points = 10;

    public float timer = 0;
    public float Health;
    public float waitToRespawn = 1;

    private bool respawning;
    public bool respawnCall = false;

    public Image ImBar;

    public GameObject EndPoint;
    public GameObject playerMenu;
    public GameObject deathSplosion;

    public PlayerController thePlayer;

    public AudioClip gameOverMusic;
    private AudioSource Audio;

    public ResetOnRespawn[] objectsToReset;

    /// <summary>
    /// START
    /// </summary>
    void Start()
    {
        if (GameInformation.Health > 0)
            Health = GameInformation.Health;
        else
            Health = 100;

        Audio = GetComponent<AudioSource>(); // pour utiliser l'audiosource
        // AddScore(PlayerPrefs.GetInt("Score")); // on charge les points du niveau précédent
        thePlayer = FindObjectOfType<PlayerController>();
        objectsToReset = FindObjectsOfType<ResetOnRespawn>();

        if (GameInformation.Lives == 0)
            currentLives = startingLives;
        else
            currentLives = GameInformation.Lives;

        livesText.text = "Lives x " + currentLives;
    }

    /// <summary>
    /// UPDATE
    /// </summary>
    void Update()
    {
        // Menu
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            playerMenu.SetActive(true);
        }

        if (Health <= 0 && !respawning)
        {
            respawning = true;
            respawnCall = true;
        }

        AddTime();
    }

    /// <summary>
    /// ADD XP
    /// </summary>
    /// <param name="point"></param>
    public void AddScore(int point)
    {
        TxtScore.text = "XP " + thePlayer.tmpxp;
    }

    /// <summary>
    /// ADD TIME
    /// </summary>
    public void AddTime()
    {
        timer += Time.deltaTime; // Time.deltaTime will increase the value with 1 every second.
        TxtTime.text = "TIME : " + Mathf.RoundToInt(timer);
    }

    /// <summary>
    /// REMOVE HEALTH
    /// Pour enlever de la vie. 
    /// On utilise le float par rapport au filled de l'image UI
    /// </summary>
    /// <param name="val"></param>
    public void RemoveHealth(float val)
    {
        Health -= val; // on va lui enlever la valeur
        Health = Mathf.Clamp(Health, 0, 100); // minimum et max de vie
        GameInformation.Health = Health;
        ImBar.fillAmount = Health / 100;
        TxtLife.text = Health + " %";

        // Si la vie est finie le player meurt
        if (Health <= 0)
        {
            // Particles
            Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerDead();
        }
    }

    /// <summary>
    /// GIVE HEALTH
    /// Donner de la vie au Player
    /// </summary>
    /// <param name="val"></param>
    public void GiveHealth(float val)
    {
        Health += val; // on va lui met la valeur
        Health = Mathf.Clamp(Health, 0, 100); // minimum et max de vie
        GameInformation.Health = Health;
        ImBar.fillAmount = Health / 100;
        TxtLife.text = Health + " %";
    }

    /// <summary>
    /// RESPAWN
    /// </summary>
	public void Respawn()
    {
        RemoveLives(1);

        if (currentLives > 0)
        {
            StartCoroutine(RespawnCo());
        }
        else
        {
            thePlayer.GetComponent<AudioSource>().PlayOneShot(thePlayer.soundDead);
            thePlayer.GetComponent<PlayerController>().enabled = false; // le perso ne bouge plus
            thePlayer.GetComponent<Rigidbody2D>().isKinematic = true;
            thePlayer.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(thePlayer.LoadGameOver());
        }
    }

    public IEnumerator RespawnCo()
    {
        // On désactive le player
        thePlayer.gameObject.SetActive(false);

        // Particles
        Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);

        respawning = false;
        respawnCall = false;

        // on le réactive sur le point de controle
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
        // thePlayer.GetComponentInChildren<BoxCollider2D>().enabled = true;

        for (int i = 0; i < objectsToReset.Length; i++)
        {
            if(objectsToReset[i] != null)
            {
                objectsToReset[i].gameObject.SetActive(true);
                objectsToReset[i].ResetObject();
            }
        }
    }

    /// <summary>
    /// ADD LIVES
    /// </summary>
    /// <param name="livesToAdd"></param>
	public void AddLives(int livesToAdd)
    {
        // coinSound.Play();
        currentLives += livesToAdd;
        livesText.text = "Lives x " + currentLives;
    }

    /// <summary>
    /// REMOVE LIVES
    /// </summary>
    /// <param name="livesToRemove"></param>
	public void RemoveLives(int livesToRemove)
    {
        // coinSound.Play();
        currentLives -= livesToRemove;
        livesText.text = "Lives x " + currentLives;
    }
}