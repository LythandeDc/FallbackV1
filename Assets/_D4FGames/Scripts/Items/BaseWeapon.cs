using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : BaseStatItem
{
    public enum WeaponTypes
    {
        SWORD,
        STAFF,
        DAGGER,
        BOW,
        SHIELD,
        POLEARM
    }
    private WeaponTypes weaponType;
    private int spellEffectID; 

    /// <summary>
    /// Weapon Types
    /// </summary>
    public WeaponTypes WeaponType
    {
        get { return weaponType; }
        set { weaponType = value; }
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
