using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAllocationModule : MonoBehaviour
{
    private string[] statNames = new string[6] { "Staminia", "Endurance", "Intellect", "Strength", "Agility", "Resistance" };
    private string[] statDescriptions = new string[6] { "Health modifier", "Energy modifier", "Magical Damage modifier", "Physical Damage modifier", "Haste critical Strike modifier", "All Damage Reduction" };
    private bool[] statSelections = new bool[6];

    public int[] pointsToAllocate = new int[6]; // starting stat values for the chose class
    public int[] baseStatPoints = new int[6]; // Starting stat values for the chose class

    private int availPoints = 5;
    public bool didRunOnce = false;

    /// <summary>
    /// Display Stat Allocation Module
    /// </summary>
    public void DisplayStatAllocationModule()
    {
        if(!didRunOnce)
        {
            RetrieveStatBaseStatPoints();
            didRunOnce = true;
        }
        DisplayStatToggleSwitches();
        DisplayStatIncreaseDecreaseButtons();
    }

    /// <summary>
    /// Display Stat Selection Grid
    /// </summary>
    public void DisplayStatToggleSwitches()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            float result = 200 + (i * 80);

            GUI.skin.toggle.fontSize = 13;
            GUI.skin.toggle.alignment = TextAnchor.UpperCenter;
            GUI.skin.label.fontSize = 15;
            statSelections[i] = GUI.Toggle(new Rect(455, result + 14, 100, 60), statSelections[i], statNames[i]);
            GUI.Label(new Rect(560, result + 14, 100, 60), pointsToAllocate[i].ToString());

            // DISPLAY STAT DESCRIPTIONS
            if (statSelections[i])
            {
                GUI.Label(new Rect(460, result + 30, 150, 100), statDescriptions[i]);
            }
        }
    }

    /// <summary>
    /// DISPLAY STAT INCREATE DESCREASE BUTTONS
    /// </summary>
    private void DisplayStatIncreaseDecreaseButtons()
    {
        for(int i = 0; i < pointsToAllocate.Length; i++)
        {
            float result = 200 + (i * 80);

            if (pointsToAllocate[i] >= baseStatPoints[i] && availPoints > 0)
            {
                if (GUI.Button(new Rect(590, result + 10, 25, 25), "+"))
                {
                    pointsToAllocate[i] += 1;
                    --availPoints;
                }
            }

            if (pointsToAllocate[i] >= baseStatPoints[i])
            {
                if (GUI.Button(new Rect(420, result + 10, 25, 25), "-"))
                {
                    pointsToAllocate[i] -= 1;
                    ++availPoints;
                }
            }
        }
    }

    /// <summary>
    /// RETRIEVE STAT BASE STAT POINTS
    /// </summary>
    private void RetrieveStatBaseStatPoints()
    {
        BaseCharacterClass cClass = GameInformation.PlayerClass;
        pointsToAllocate[0] = cClass.Staminia;
        baseStatPoints[0]   = cClass.Staminia;
        pointsToAllocate[1] = cClass.Endurance;
        baseStatPoints[1]   = cClass.Endurance;
        pointsToAllocate[2] = cClass.Intellect;
        baseStatPoints[2]   = cClass.Intellect;
        pointsToAllocate[3] = cClass.Strength;
        baseStatPoints[3]   = cClass.Strength;
        pointsToAllocate[4] = cClass.Agility;
        baseStatPoints[4]   = cClass.Agility;
        pointsToAllocate[5] = cClass.Resistance;
        baseStatPoints[5]   = cClass.Resistance;
    }
}
