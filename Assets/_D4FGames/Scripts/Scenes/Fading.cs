using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
    // the texture that will overlay the screen. This can be image or loading graphic
    public Texture2D fadeOutTexture;
    // the fading speed
    public float fadeSpeed = 0.8f;

    // the texture's order in the draw hierarchy : a low number means it renders on top
    private int drawDepth = -1000;
    // the texture's alpha value between 0 and 1
    private float alpha = 1.0f;
    // the direction to fade : in = -1 or out = 1
    private int fadeDir = -1;

	/// <summary>
    /// ON GUI
    /// </summary>
	void OnGUI ()
    {
        // fade out/in the alpha value using a direction, a speed Time.deltatime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // force (clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // set color of our GUI (in this cas our texture). All color values remain the same & the alpha is set to the alpha variable
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); // set the alpha value
        GUI.depth = drawDepth; // make the black texture render on top (drawn last)
        GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); // draw the texture to fit the entire screen area
	}
	
	/// <summary>
    /// Begin fade
    /// Sets fadeDir to the direction parameter making the scene fade -1 and out if 1
    /// </summary>
	public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed); // return the fadeSpeed variable so it's easy to time the Application.LoadLevel();
	}

    /// <summary>
    /// On Level Was Loaded
    /// OnLevelWasLoaded is called when a level is loaded. 
    /// It takes loaded level index(int) as a parameter so you can limit the fade in to certain scenes
    /// </summary>
    void OnLevelWasLoaded()
    {
        // alpha = 1 // use if the alpha is not set to 1 by default
        BeginFade(-1); // call the fade in function
    }
}
