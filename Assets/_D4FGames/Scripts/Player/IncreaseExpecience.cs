using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IncreaseExpecience
{
    private static int xpToGive;
    private static LevelUp levelUpScript = new LevelUp();

    /// <summary>
    /// ADD EXPERIENCE
    /// </summary>
    public static void AddExperience()
    {
        // Each level give 100 points
        xpToGive = GameInformation.PlayerLevel * 100;
        GameInformation.CurrentXP += xpToGive;
        CheckToSeeIfPlayerLeveled();
    }

    /// <summary>
    /// ADD EXPLORATION EXPERIENCE FROM BATTLE LOSS
    /// </summary>
    public static void AddExplorationExperienceFromBattleLoss()
    {
        xpToGive = GameInformation.PlayerLevel * 10;
        GameInformation.CurrentXP += xpToGive;
        CheckToSeeIfPlayerLeveled();
    }

    /// <summary>
    /// ADD EXPLORATION EXPERIENCE
    /// </summary>
    public static void AddExplorationExperience()
    {
        xpToGive = GameInformation.PlayerLevel * 5;
        GameInformation.CurrentXP += xpToGive;
        CheckToSeeIfPlayerLeveled();
    }

    /// <summary>
    /// CHECK TO SEE IF PLAYER LEVELED UP
    /// </summary>
    public static void CheckToSeeIfPlayerLeveled()
    {
        if (GameInformation.CurrentXP >= GameInformation.RequiredXP)
        {
            Debug.Log("Leveled Up");
            // the the player has leveled up
            levelUpScript.LevelUpCharacter();
            // CREATE LEVEL UP SCRIPT
        }
    }
}
