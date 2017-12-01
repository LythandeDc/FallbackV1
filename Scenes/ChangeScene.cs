using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string LevelToLoad;

    void LoadMenu ()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("Score", 0);
	}

    void LoadLevel()
    {
        PlayerPrefs.GetInt("Score");
        SceneManager.LoadScene(LevelToLoad);
    }

}
