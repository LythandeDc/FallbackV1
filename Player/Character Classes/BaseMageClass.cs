using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMageClass : BaseCharacterClass
{
    public BaseMageClass()
    {
        CharacterClassName = "Mage";
        CharacterClassDescription = "A wise Wizard, can cast spells !";
        Staminia = 12;
        Endurance = 14;
        Strength = 10;
        Intellect = 15;
        Agility = 13;
        Resistance = 15;

        Gold = 0;
        Health = 100;

        CurrentXP = 0;
    }
}
