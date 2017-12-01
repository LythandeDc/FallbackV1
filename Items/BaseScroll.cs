using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScroll : BaseStatItem
{
    private int spellEffectID;

    /// <summary>
    /// Spell Effect ID
    /// </summary>
    public int SpellEffectID
    {
        get { return spellEffectID; }
        set { spellEffectID = value; }
    }
}
