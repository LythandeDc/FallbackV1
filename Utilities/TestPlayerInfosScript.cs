using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerInfosScript : MonoBehaviour
{
	/// <summary>
    /// START
    /// </summary>
	void Start ()
    {
        LoadInformation.LoadAllInformation();

        Debug.Log("Load Infos");
        Debug.Log("Player Name : " + GameInformation.PlayerName);
        Debug.Log("Player Class : " + GameInformation.CharacterClassName);
        Debug.Log("Player Level : " + GameInformation.PlayerLevel);
        Debug.Log("Player Health : " + GameInformation.Health);
        Debug.Log("Player Staminia : " + GameInformation.Staminia);
        Debug.Log("Player Endurance : " + GameInformation.Endurance);
        Debug.Log("Player Intellect : " + GameInformation.Intellect);
        Debug.Log("Player Strength : " + GameInformation.Strength);
        Debug.Log("Player Agility : " + GameInformation.Agility);
        Debug.Log("Player Resistance : " + GameInformation.Resistance);
        Debug.Log("Player Gold : " + GameInformation.Gold);
    }
	
	/// <summary>
    /// UPDATE
    /// </summary>
	void Update ()
    {
		
	}
}
