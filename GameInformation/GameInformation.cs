using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour
{
    /// <summary>
    /// AWAKE
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public static bool IsMale { get; set; }
    public static string PlayerBio { get; set; }
    public static string PlayerName { get; set; }
    public static int PlayerLevel { get; set; }
    public static BaseCharacterClass PlayerClass { get; set; }
    public static string CharacterClassName { get; set; }
    public static int Staminia { get; set; }
    public static int Endurance { get; set; }
    public static int Intellect { get; set; }
    public static int Strength { get; set; }
    public static int Agility { get; set; }
    public static int Resistance { get; set; }

    public static int Gold { get; set; }
    public static float Health { get; set; }

    public static int CurrentXP { get; set; }
    public static int RequiredXP { get; set; }

    public static string LevelToLoad { get; set; }

    public static BaseEquipment Equipment1 { get; set; }
}
