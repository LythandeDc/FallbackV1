using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStatItem : BaseItem
{
    private int staminia;
    private int endurance;
    private int strength;
    private int intellect;

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
}
