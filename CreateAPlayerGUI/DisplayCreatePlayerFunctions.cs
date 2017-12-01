using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayCreatePlayerFunctions
{
    private int classSelection;
    private string[] classSelectionName = new string[]
    {
        "Mage",
        "Warrior",
        "Archer",
        "Rogue",
        "Warlock",
        "Paladin"
    };
    private StatAllocationModule statAllocationModule = new StatAllocationModule();
    private string playerFirstName = "Enter first name"; // name
    private string playerLastName = "Enter last name"; // name
    private string playerBio = "Enter Player Bio"; // bio
    private bool isMale = true; // gender selection
    private int genderSelection; // gender selection
    private string[] genterTypes = new string[2] { "Male", "Female" };
    [SerializeField]
    string thestring = "";
    public string level = "Intro";
    public bool isClicked;
    public static Font customFont;

    /// <summary>
    /// DISPLAY CLASS SELECTIONS
    /// </summary>
    public void DisplayClassSelections()
    {
        // A list of toggle buttons and each button will be a different class
        // Selection grid
        GUI.color = new Color(18, 65, 80, 1);
        GUI.skin.font = customFont;
        classSelection = GUI.SelectionGrid(new Rect(120, 200, 250, 300), classSelection, classSelectionName, 2);
        GUI.color = Color.white;
        GUI.Label(new Rect(450, 200, 300, 300), FindClassDescription(classSelection));
        GUI.Label(new Rect(450, 250, 300, 300), FindClassStatValue(classSelection));
    }

    /// <summary>
    /// FIND CLASS DESCRIPTION
    /// </summary>
    /// <param name="classSelection"></param>
    /// <returns></returns>
    private string FindClassDescription(int classSelection)
    {
        if (classSelection == 0)
        {
            BaseCharacterClass tempClass = new BaseMageClass();
            return tempClass.CharacterClassDescription;
        }
        else if(classSelection == 1)
        {
            BaseCharacterClass tempClass = new BaseWarriorClass();
            return tempClass.CharacterClassDescription;
        }

        return "No class found";
    }

    /// <summary>
    /// FIND CLASS STAT VALUE
    /// </summary>
    /// <param name="classSelection"></param>
    /// <returns></returns>
    private string FindClassStatValue(int classSelection)
    {
        if (classSelection == 0)
        {
            BaseCharacterClass tempClass = new BaseMageClass();
            string tempStats = "Staminia " + tempClass.Staminia.ToString() + "\n" + "Endurance " + tempClass.Endurance.ToString() + "\n" + "Intellect " + tempClass.Intellect.ToString() + "\n" + "Strength " + tempClass.Strength.ToString() + "\n" + "Agility " + tempClass.Agility.ToString() + "\n" + "Resistance " + tempClass.Resistance.ToString();
            return tempStats;
        }
        else if (classSelection == 1)
        {
            BaseCharacterClass tempClass = new BaseWarriorClass();
            string tempStats = "Staminia " + tempClass.Staminia.ToString() + "\n" + "Endurance " + tempClass.Endurance.ToString() + "\n" + "Intellect " + tempClass.Intellect.ToString() + "\n" + "Strength " + tempClass.Strength.ToString() + "\n" + "Agility " + tempClass.Agility.ToString() + "\n" + "Resistance " + tempClass.Resistance.ToString();
            return tempStats;
        }

        return "No stats found";
    }

    /// <summary>
    /// DISPLAY STAT ALLOCATION
    /// </summary>
    public void DisplayStatAllocation()
    {
        // A list of stats with plus and minus buttons to add stats
        // logic to make sure the player cannot and more than stats given
        statAllocationModule.DisplayStatAllocationModule();
    }

    /// <summary>
    /// DISPLAY FINAL SETUP
    /// </summary>
    public void DisplayFinalSetup()
    {
        // name
        playerFirstName = GUI.TextArea(new Rect(120, 200, 170, 35), playerFirstName, 25);
        playerLastName = GUI.TextArea(new Rect(120, 245, 170, 35), playerLastName, 25);
        // gender
        // genderSelection = GUI.SelectionGrid(new Rect(300, 200, 100, 80), genderSelection, genterTypes, 1);
        // ad a description to your character
        playerBio = GUI.TextArea(new Rect(120, 290, 280, 255), playerBio, 255);
    }

    /// <summary>
    /// CHOOSE CLASS
    /// </summary>
    public void ChooseClass(int classSelection)
    {
        // Mage
        if(classSelection == 0)
        {
            GameInformation.PlayerClass = new BaseMageClass();
        }
        // Wizard
        else if (classSelection == 1)
        {
            GameInformation.PlayerClass = new BaseWarriorClass();
        }
        else
        {
            GameInformation.PlayerClass = new BaseWarriorClass();
        }
    }

    /// <summary>
    /// DISPLAY MAIN ITEMS
    /// </summary>
    public void DisplayMainItems()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        GUI.color = Color.white;
        // GUI.Label(new Rect(Screen.width/2 - 50, 20, 250, 100), "CREATE NEW PLAYER");

        GUI.color = new Color(18, 65, 80, 1);
        /*
        if (GUI.Button(new Rect(340, 300, 50, 50), "<<<"))
        {
            // turn transform tagged as player to the left
            player.Rotate(Vector2.up * 10);
        }

        if (GUI.Button(new Rect(470, 300, 50, 50), ">>>"))
        {
            // turn transform tagged as player to the right
            player.Rotate(Vector2.down * 10);
        }
        */

        // If we are not in the final setup then show a next button
        if (CreateAPlayerGUI.currentState != CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP)
        {
            if (GUI.Button(new Rect(Screen.width - 220, 560, 60, 40), "Next"))
            {
                if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.CLASSSELECTION)
                {
                    ChooseClass(classSelection);
                    CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION;
                }
                else if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION)
                {
                    GameInformation.Staminia = statAllocationModule.pointsToAllocate[0] + statAllocationModule.baseStatPoints[0];
                    GameInformation.Endurance = statAllocationModule.pointsToAllocate[1] + statAllocationModule.baseStatPoints[1];
                    GameInformation.Intellect = statAllocationModule.pointsToAllocate[2] + statAllocationModule.baseStatPoints[2];
                    GameInformation.Strength = statAllocationModule.pointsToAllocate[3] + statAllocationModule.baseStatPoints[3];
                    GameInformation.Agility = statAllocationModule.pointsToAllocate[4] + statAllocationModule.baseStatPoints[4];
                    GameInformation.Resistance = statAllocationModule.pointsToAllocate[5] + statAllocationModule.baseStatPoints[5];

                    CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP;
                }
            }
        }
        else if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP)
        {
            // Run the game
            if (GUI.Button(new Rect(800, 560, 80, 40), "Finish"))
            {
                GameInformation.LevelToLoad = "Level1";

                //  (playerFirstName != null && playerLastName != null)
                if (playerFirstName != "Enter first name" && playerLastName != "Enter last name")
                    GameInformation.PlayerName = playerFirstName + " " + playerLastName;
                else
                    GameInformation.PlayerName = "Ayduin" + " " + "Bouldersworn";

                thestring = classSelectionName[classSelection];
                GameInformation.PlayerLevel = 1;
                GameInformation.Gold = 0;
                GameInformation.CurrentXP = 0;
                GameInformation.CharacterClassName = thestring;

                
                if (genderSelection == 0)
                {
                    GameInformation.IsMale = true;
                }
                else
                {
                    GameInformation.IsMale = false;
                }

                // playerBio != null
                if (playerBio != "Enter Player Bio")
                    GameInformation.PlayerBio = playerBio;
                else
                    GameInformation.PlayerBio = "A great hero";

                GameInformation.Health = 100;
                SaveInformation.SaveAllInformation();
                Debug.Log("Make final save : " + GameInformation.PlayerName + " is a " + GameInformation.CharacterClassName + " :)");
                SceneManager.LoadScene(level);
            }
        }

        // If we are not in the classselection setup then show a button back
        if (CreateAPlayerGUI.currentState != CreateAPlayerGUI.CreateAPlayerStates.CLASSSELECTION)
        {
            if (GUI.Button(new Rect(200, 560, 60, 40), "Back"))
            {
                if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION)
                {
                    statAllocationModule.didRunOnce = false;
                    GameInformation.PlayerClass = null;
                    CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.CLASSSELECTION;
                }
                else if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP)
                {
                    CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION;
                }
            }
        }
    }
}
