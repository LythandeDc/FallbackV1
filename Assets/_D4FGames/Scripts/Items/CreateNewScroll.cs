using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewScroll : MonoBehaviour
{
    private BaseScroll newScroll;

	/// <summary>
    /// START
    /// </summary>
	void Start ()
    {
        CreateScroll();
        Debug.Log(newScroll.ItemName);
        Debug.Log(newScroll.ItemDescription);
        Debug.Log(newScroll.ItemID.ToString());
        Debug.Log(newScroll.SpellEffectID.ToString());
    }

    /// <summary>
    /// CREATE SCROLL
    /// </summary>
    private void CreateScroll()
    {
        newScroll = new BaseScroll();
        newScroll.ItemName = "Scroll";
        newScroll.ItemDescription = "This is a powerful scroll ! ";
        newScroll.ItemID = Random.Range(1, 101);
        newScroll.SpellEffectID = Random.Range(500, 1001);
    }
	
	/// <summary>
    /// UPDATE
    /// </summary>
	void Update ()
    {
		
	}
}
