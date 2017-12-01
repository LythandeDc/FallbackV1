using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOneLevel : MonoBehaviour
{
    public string level = "IntroLevel1";

    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }
}
