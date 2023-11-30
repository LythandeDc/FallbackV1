using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp
{
    public int maxPlayerLevel = 50;

    /// <summary>
    /// LEVEL UP CHARACTER
    /// </summary>
    public void LevelUpCharacter()
    {
        // check to see if current xp > than required xp
        if(GameInformation.CurrentXP > GameInformation.RequiredXP)
        {
            GameInformation.CurrentXP -= GameInformation.RequiredXP;
        }
        else
        {
            GameInformation.CurrentXP = 0;
        }

        if (GameInformation.PlayerLevel < maxPlayerLevel)
        {
            GameInformation.PlayerLevel += 1;
        }
        else
        {
            GameInformation.PlayerLevel = maxPlayerLevel;
        }

        // give player stat points
        // randomly decide to give up items
        // give them a move/ability
        // give money
        // determinate the next amount of required xp
        DetermineRequiredXP();
    }

    /// <summary>
    /// DETERMINE REQUIRED XP
    /// </summary>
    private void DetermineRequiredXP()
    {
        int temp = (GameInformation.PlayerLevel * 1000) + 250;
        GameInformation.RequiredXP = temp;
    }

    /// <summary>
    /// DETERMINE MONEY TO GIVE
    /// </summary>
    private void DetermineMoneyToGive()
    {
        if(GameInformation.PlayerLevel <= 10)
        {
            // give a certain amount of money
        }
    }
}
