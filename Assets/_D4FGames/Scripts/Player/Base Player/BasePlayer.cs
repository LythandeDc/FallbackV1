using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer
{
    // PARAMETERS
    private string playerName;
    private int playerLevel = 1; // the level of the player (not of the scene level)
    private BaseCharacterClass playerClass; 
    // Stats
    private int staminia; // health modifier
    private int endurance; // energy modifier
    private int intellect; // magical damage modifier
    private int strength; // physical damage modifier
    private int agility; // haste and crit modifier
    private int resistance; // all damage reduction

    private int gold; // in game currency

    // Xp
    private int currentXP; 
    private int requiredXP;
    private int statPointsToAllocate;

    /// <summary>
    /// PLAYER NAME
    /// public string PlayerName { get; set; }
    /// </summary>
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    /// <summary>
    /// PLAYER LEVEL
    /// </summary>
    public int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel = value; }
    }

    /// <summary>
    /// Intellect
    /// </summary>
    public BaseCharacterClass PlayerClass
    {
        get { return playerClass; }
        set { playerClass = value; }
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
    /// Stat Points To Allocate
    /// </summary>
    public int StatPointsToAllocate
    {
        get { return statPointsToAllocate; }
        set { statPointsToAllocate = value; }
    }
}
