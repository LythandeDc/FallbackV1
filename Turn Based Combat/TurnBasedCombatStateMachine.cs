using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombatStateMachine : MonoBehaviour
{
    private bool hasAddedXP = false;

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        PLAYERANIMATE,
        ENEMYCHOICE,
        LOSE,
        WIN
    }

    private BattleStates currentState;

	/// <summary>
    /// START
    /// </summary>
	void Start ()
    {
        hasAddedXP = false;
        currentState = BattleStates.START;
    }
	
	/// <summary>
    /// UPDATE
    /// </summary>
	void Update ()
    {
        Debug.Log(currentState);
		switch(currentState)
        {
            case (BattleStates.START) :
                // SETUP BATTLE FUNCTION
                break;
            case (BattleStates.PLAYERCHOICE):
                break;
            case (BattleStates.PLAYERANIMATE):
                break;
            case (BattleStates.ENEMYCHOICE):
                break;
            case (BattleStates.LOSE):
                break;
            case (BattleStates.WIN):
                if(!hasAddedXP)
                {
                    IncreaseExpecience.AddExperience();
                }
                break;
        }
	}

    /// <summary>
    /// ON GUI
    /// </summary>
    void OnGUI()
    {
        if(GUILayout.Button("NEXT STATE"))
        {
            if(currentState == BattleStates.START)
            {
                currentState = BattleStates.PLAYERCHOICE;
            }
            else if (currentState == BattleStates.PLAYERCHOICE)
            { 
                {
                    currentState = BattleStates.PLAYERANIMATE;
                }
            }
            else if (currentState == BattleStates.PLAYERANIMATE)
            {
                {
                    currentState = BattleStates.ENEMYCHOICE;
                }
            }
            // if next state equal to ennemychoice and health > 0 BattleStates player choice
            // if next state equal to ennemychoice and ennemy health = 0 BattleStates win
            if(currentState == BattleStates.PLAYERANIMATE && GameInformation.Health > 0)
            {
                hasAddedXP = true;
            }
            // if next state equal to ennemychoice and player health = 0 BattleStates lose
        }
    }
}
