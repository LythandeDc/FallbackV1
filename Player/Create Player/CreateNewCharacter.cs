using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateNewCharacter : MonoBehaviour
{
    private BasePlayer newPlayer;
    private bool isMageClass;
    private bool isWarriorClass;
    private string playerName = "Enter Name";

	/// <summary>
    /// START
    /// </summary>
	void Start ()
    {
        newPlayer = new BasePlayer();
	}
	
	/// <summary>
    /// UPDATE
    /// </summary>
	void Update ()
    {
		
	}

    /// <summary>
    /// ON GUI
    /// </summary>
    void OnGUI()
    {
        playerName = GUILayout.TextArea(playerName, 15);
        isMageClass = GUILayout.Toggle(isMageClass, "Mage Class");
        isWarriorClass = GUILayout.Toggle(isWarriorClass, "Warrior Class");

        if(GUILayout.Button("Create") && playerName != "Enter Name")
        {
            if(isMageClass)
            {
                newPlayer.PlayerClass = new BaseMageClass();
            }
            else if(isWarriorClass)
            {
                newPlayer.PlayerClass = new BaseWarriorClass();
            }
            else
            {
                newPlayer.PlayerClass = new BaseWarriorClass();
            }

            CreateNewPlayer();
            StoreNewPlayerInfo();

            SaveInformation.SaveAllInformation();
        }

        if(GUILayout.Button("Load"))
        {
            SceneManager.LoadScene("test");
        }
    }

    /// <summary>
    /// CREATE NEW PLAYER
    /// </summary>
    private void CreateNewPlayer()
    {
        newPlayer.PlayerName = playerName;
        newPlayer.Strength = newPlayer.PlayerClass.Strength;
        newPlayer.PlayerLevel = 1;
        newPlayer.Staminia = newPlayer.PlayerClass.Staminia;
        newPlayer.Endurance = newPlayer.PlayerClass.Endurance;
        newPlayer.Intellect = newPlayer.PlayerClass.Intellect;
        newPlayer.Agility = newPlayer.PlayerClass.Agility;
        newPlayer.Resistance = newPlayer.PlayerClass.Resistance;
        newPlayer.Gold = newPlayer.PlayerClass.Gold;
    }

    /// <summary>
    /// STORE NEW PLAYER INFO
    /// </summary>
    private void StoreNewPlayerInfo()
    {
        GameInformation.PlayerName = newPlayer.PlayerName;
        GameInformation.PlayerLevel = newPlayer.PlayerLevel;
        GameInformation.Staminia = newPlayer.Staminia;
        GameInformation.Endurance = newPlayer.Endurance;
        GameInformation.Intellect = newPlayer.Intellect;
        GameInformation.Strength = newPlayer.Strength;
        GameInformation.Agility = newPlayer.Agility;
        GameInformation.Resistance = newPlayer.Resistance;
        GameInformation.Gold = newPlayer.Gold;

        DebugTheGUI();
    }

    /// <summary>
    /// DEBUG THE CURRENT PLAYER
    /// </summary>
    private void DebugTheGUI()
    {
        Debug.Log("Player Name : " + newPlayer.PlayerName);
        Debug.Log("Player Class : " + newPlayer.PlayerClass.CharacterClassName);
        Debug.Log("Player Level : " + newPlayer.PlayerLevel);
        Debug.Log("Player Staminia : " + newPlayer.Staminia);
        Debug.Log("Player Endurance : " + newPlayer.Endurance);
        Debug.Log("Player Intellect : " + newPlayer.Intellect);
        Debug.Log("Player Strength : " + newPlayer.Strength);
        Debug.Log("Player Agility : " + newPlayer.Agility);
        Debug.Log("Player Resistance : " + newPlayer.Resistance);
        Debug.Log("Player Gold : " + newPlayer.Gold);
    }
}
