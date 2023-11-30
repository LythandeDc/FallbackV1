using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarriorClass : BaseCharacterClass
{
    public BaseWarriorClass()
    {
        CharacterClassName = "Warrior";
        CharacterClassDescription = "A strong and powerful hero.";
        Staminia = 15;
        Endurance = 12;
        Strength = 15;
        Intellect = 10;
        Agility = 10;
        Resistance = 15;

        Gold = 0;
        Health = 100;

        CurrentXP = 0;
    }
}
