using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePotion : BaseStatItem
{
    public enum PotionTypes
    {
        HEALTH,
        ENERGY,
        STRENGTH,
        INTELLECT,
        VITALITY,
        ENDURANCE,
        SPEED
    }

    private PotionTypes potionType;
    private int spellEffectID;

    /// <summary>
    /// Potion Type
    /// </summary>
    public PotionTypes PotionType
    {
        get { return potionType; }
        set { potionType = value; }
    }

    /// <summary>
    /// Spell Effect ID
    /// </summary>
    public int SpellEffectID
    {
        get { return spellEffectID; }
        set { spellEffectID = value; }
    }
}
