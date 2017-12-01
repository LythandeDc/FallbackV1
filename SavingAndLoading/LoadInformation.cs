using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInformation
{
    /// <summary>
    /// LOAD ALL INFORMATION
    /// </summary>
    public static void LoadAllInformation()
    {
        GameInformation.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
        GameInformation.CharacterClassName = PlayerPrefs.GetString("PLAYERCLASS"); 
        GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYERLEVEL");
        GameInformation.LevelToLoad = PlayerPrefs.GetString("LEVELTOLOAD");
        GameInformation.Staminia = PlayerPrefs.GetInt("STAMINIA");
        GameInformation.Endurance = PlayerPrefs.GetInt("ENDURANCE");
        GameInformation.Intellect = PlayerPrefs.GetInt("INTELLECT");
        GameInformation.Strength = PlayerPrefs.GetInt("STRENGTH");
        GameInformation.Agility = PlayerPrefs.GetInt("AGILITY");
        GameInformation.Resistance = PlayerPrefs.GetInt("RESISTANCE");

        GameInformation.Lives = PlayerPrefs.GetInt("LIVES");
        GameInformation.LevelToLoad = PlayerPrefs.GetString("LEVELTOLOAD");

        GameInformation.Gold = PlayerPrefs.GetInt("GOLD");
        GameInformation.Health = PlayerPrefs.GetFloat("HEALTH");

        GameInformation.CurrentXP = PlayerPrefs.GetInt("CURRENTXP");

        if (PlayerPrefs.GetString("EQUIPMENT1") != null)
        {
            GameInformation.Equipment1 = (BaseEquipment)PPSerialization.Load("EQUIPMENT1");
        }
    }
}
