using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // types UI

public class PlayerMenu : MonoBehaviour
{ 
    public Text TxtPlayerName;
    private bool paused;
    public GameObject thisMenu;
    // Objects à mettre en pause
    public GameObject[] objdisabled;
    public GameObject main;
    public GameObject stats;
    public GameObject options;
    public GameObject items;
    public PlayerController player;
    // Textes
    public Text TxtLevel;
    public Text TxtLife;
    public Text TxtStaminia;
    public Text TxtEndurance;
    public Text TxtStrength;
    public Text TxtIntellect;
    public Text TxtAgility;
    public Text TxtResistance;
    public Text TxtGold;
    public Text TxtXP;
    public Text TxtTime;

    public bool Paused { get; set; }

    /// <summary>
    /// START
    /// </summary>
    void Start ()
    {
        Paused = true;
        LoadInformation.LoadAllInformation();

        if (GameInformation.PlayerName != null)
            TxtPlayerName.text = GameInformation.PlayerName;
    }

    /// <summary>
    /// UPDATE
    /// </summary>
    void Update ()
    {
        if (Paused == true)
        {
            foreach (GameObject go in objdisabled)
            {
                if (go != null)
                {
                    go.SetActive(false);
                }
            }
        }

        if(thisMenu.activeSelf)
        {
            LoadInformation.LoadAllInformation();
            Paused = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ExitMenu());
        }

        float tmr = GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().timer; 
        TxtTime.text = "TIME : " + Mathf.RoundToInt(tmr);
    }

    /// <summary>
    /// DISABLE MENU
    /// </summary>
    public void DisableMenu()
    {
        main.SetActive(true);
        options.SetActive(false);
        items.SetActive(false);
        stats.SetActive(false);
        StartCoroutine(ExitMenu());
    }

    /// <summary>
    /// EXIT MENU
    /// </summary>
    /// <returns></returns>
    IEnumerator ExitMenu()
    {
        Paused = false;

        foreach (GameObject go in objdisabled)
        {
            if(go != null)
            {
                if((go.GetComponent<EnemieController>() != null &&
                   go.GetComponent<EnemieController>().dead == true &&
                   go.GetComponent<EnemieController>().crunning == true) ||
                   (go.GetComponent<EnemieNoFollow>() != null &&
                    go.GetComponent<EnemieNoFollow>().dead == true))
                {
                    Debug.Log("Objet " + go.name);
                    go.SetActive(false);
                }
                else
                {
                    Debug.Log("Objet " + go.name);
                    go.SetActive(true);
                }
            }
        }

        thisMenu.SetActive(false);
        yield return new WaitForSeconds(0.05f);
    }

    /// <summary>
    /// OPTIONS MENU
    /// </summary>
    public void OptionsMenu()
    {
        options.SetActive(true);
        main.SetActive(false);
        items.SetActive(false);
        stats.SetActive(false);
    }

    /// <summary>
    /// EXIT GAME
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// STATS MENU
    /// </summary>
    public void StatsMenu()
    {
        options.SetActive(false);
        main.SetActive(false);
        items.SetActive(false);
        stats.SetActive(true);
        TxtLevel.text = "Level " + player.tmpLevel;
        TxtLife.text = "Life " + player.TheHealth();
        TxtAgility.text = "Agility " + GameInformation.Agility;
        TxtIntellect.text = "Intellect " + GameInformation.Intellect;
        TxtStaminia.text = "Staminia " + GameInformation.Staminia;
        TxtEndurance.text = "Endurance " + GameInformation.Endurance;
        TxtResistance.text = "Resistance " + GameInformation.Resistance;
        TxtStrength.text = "Strength " + GameInformation.Strength;
        TxtXP.text = player.tmpxp + " XP"; // GameInformation.CurrentXP
        TxtGold.text = player.TheGold() + " coins";
    }

    /// <summary>
    /// ITEMS MENU
    /// </summary>
    public void ItemsMenu()
    {
        options.SetActive(false);
        main.SetActive(false);
        items.SetActive(true);
        stats.SetActive(false);
    }

    /// <summary>
    /// RETURN TO MAIN MENU
    /// </summary>
    public void ReturnMain()
    {
        main.SetActive(true);
        options.SetActive(false);
        items.SetActive(false);
        stats.SetActive(false);
    }

    public void ActiveSound()
    {

    }
}
