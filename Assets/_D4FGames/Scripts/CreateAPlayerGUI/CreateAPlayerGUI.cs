using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAPlayerGUI : MonoBehaviour
{
    public enum CreateAPlayerStates
    {
        CLASSSELECTION, // display all class types
        STATALLOCATION, // allocate stats where the player wants too
        FINALSETUP      // add name and misc items gender
    }

    private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions();
    public static CreateAPlayerStates currentState;
    public Font customFont;
    public string level;

    /// <summary>
    /// START
    /// </summary>
    void Start()
    {
        currentState = CreateAPlayerStates.CLASSSELECTION;
        DisplayCreatePlayerFunctions.customFont = customFont;
        level = displayFunctions.level;
    }

    /// <summary>
    /// UPDATE
    /// </summary>
    void Update()
    {
        switch (currentState)
        {
            case (CreateAPlayerStates.CLASSSELECTION):
                break;
            case (CreateAPlayerStates.STATALLOCATION):
                break;
            case (CreateAPlayerStates.FINALSETUP):
                break;
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Button Right");
            displayFunctions.isClicked = true;
        }
        else
        {
            displayFunctions.isClicked = false;
        }

        if(level != displayFunctions.level)
        {
            displayFunctions.level = level;
        }
    }

    /// <summary>
    /// ON GUI
    /// </summary>
    void OnGUI()
    {
        displayFunctions.DisplayMainItems();

        if (currentState == CreateAPlayerStates.CLASSSELECTION)
        {
            // Display class selection function
            displayFunctions.DisplayClassSelections();
        }
        if (currentState == CreateAPlayerStates.STATALLOCATION)
        {
            // Display class selection function
            displayFunctions.DisplayStatAllocation();
        }
        if (currentState == CreateAPlayerStates.FINALSETUP)
        {
            // Display class selection function
            displayFunctions.DisplayFinalSetup();
        }
    }
}
