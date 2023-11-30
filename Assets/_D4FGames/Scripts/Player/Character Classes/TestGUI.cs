using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour
{
    private BaseCharacterClass class1 = new BaseMageClass();
    private BaseCharacterClass class2 = new BaseWarriorClass();

    /// <summary>
    /// Start
    /// </summary>
    void Start ()
    {
        Debug.Log("Script Test GUI RUN");
    }
	
	/// <summary>
    /// UPDATE
    /// </summary>
	void Update ()
    {
		
	}

    /// <summary>
    /// On GUI
    /// </summary>
    private void OnGUI()
    {
        Debug.Log(class1.CharacterClassName);
        GUILayout.Label(class1.CharacterClassName);
        GUILayout.Label(class1.CharacterClassDescription);

        GUILayout.Label(class2.CharacterClassName);
        GUILayout.Label(class2.CharacterClassDescription);
    }
}
