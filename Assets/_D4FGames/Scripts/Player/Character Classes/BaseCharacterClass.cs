using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass : MonoBehaviour
{
    private string characterClassName;
    private string characterClassDescription;
    // Stats
    private int staminia; // health modifier
    private int endurance; // energy modifier
    private int intellect; // magical damage modifier
    private int strength; // physical damage modifier
    private int agility; // haste and crit modifier
    private int resistance; // all damage reduction
    private float health;

    private int gold; // in game currency

    // Xp
    private int currentXP;
    private int requiredXP;

    /// <summary>
    /// CharacterClassName
    /// </summary>
    public string CharacterClassName
    {
        get { return characterClassName; }
        set { characterClassName = value; }
    }

    /// <summary>
    /// CharacterClassDescription
    /// </summary>
    public string CharacterClassDescription
    {
        get { return characterClassDescription; }
        set { characterClassDescription = value; }
    }

    /// <summary>
    /// Staminia
    /// </summary>
    public int Staminia
    {
        get { return staminia; }
        set { staminia = value; }
    }

    /// <summary>
    /// Endurance
    /// </summary>
    public int Endurance
    {
        get { return endurance; }
        set { endurance = value; }
    }

    /// <summary>
    /// Strenght
    /// </summary>
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    /// <summary>
    /// Intellect
    /// </summary>
    public int Intellect
    {
        get { return intellect; }
        set { intellect = value; }
    }

    /// <summary>
    /// Current XP
    /// </summary>
    public int CurrentXP
    {
        get { return currentXP; }
        set { currentXP = value; }
    }

    /// <summary>
    /// Required XP
    /// </summary>
    public int RequiredXP
    {
        get { return requiredXP; }
        set { requiredXP = value; }
    }

    /// <summary>
    /// Agility
    /// </summary>
    public int Agility
    {
        get { return agility; }
        set { agility = value; }
    }

    /// <summary>
    /// Resistance
    /// </summary>
    public int Resistance
    {
        get { return resistance; }
        set { resistance = value; }
    }

    /// <summary>
    /// Gold
    /// </summary>
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    /// <summary>
    /// HEALTH
    /// </summary>
    public float Health
    {
        get { return health; }
        set { health = value; }
    }
}
