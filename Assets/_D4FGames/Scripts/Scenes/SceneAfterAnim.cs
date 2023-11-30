using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAfterAnim : MonoBehaviour {
    public string level = "Level1";

    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
        Destroy(GameObject.FindWithTag("Music"));
    }
}
