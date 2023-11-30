using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEquipment : BaseStatItem
{
    public enum EquipmentTypes
    {
        HEAD,
        CHEST,
        SHOULDERS,
        FEET,
        NECK,
        EARRING,
        LEGS,
        RING
    }

    private EquipmentTypes equipmentType;
    private int spellEffectID;

    /// <summary>
    /// Equipment Type
    /// </summary>
    public EquipmentTypes EquipmentType
    {
        get { return equipmentType; }
        set { equipmentType = value; }
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
