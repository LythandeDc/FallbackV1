using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInformation
{
    /// <summary>
    /// SAVE ALL INFORMATION
    /// </summary>
    public static void SaveAllInformation()
    {
        PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);
        PlayerPrefs.SetString("PLAYERCLASS", GameInformation.CharacterClassName);
        PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
        PlayerPrefs.SetInt("STAMINIA", GameInformation.Staminia);
        PlayerPrefs.SetInt("ENDURANCE", GameInformation.Endurance);
        PlayerPrefs.SetInt("INTELLECT", GameInformation.Intellect);
        PlayerPrefs.SetInt("STRENGTH", GameInformation.Strength);
        PlayerPrefs.SetInt("AGILITY", GameInformation.Agility);
        PlayerPrefs.SetInt("RESISTANCE", GameInformation.Resistance);

        PlayerPrefs.SetFloat("HEALTH", GameInformation.Health);

        PlayerPrefs.SetInt("GOLD", GameInformation.Gold);

        PlayerPrefs.SetInt("CURRENTXP", GameInformation.CurrentXP);

        PlayerPrefs.SetString("LEVELTOLOAD", GameInformation.LevelToLoad);

        if (GameInformation.Equipment1 != null)
        {
            PPSerialization.Save("EQUIPMENT1", GameInformation.Equipment1);
        }

        Debug.Log("Save all informations");
    }
}
