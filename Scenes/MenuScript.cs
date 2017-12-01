using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // permet de gerer les scènes
using UnityEngine.UI; //pour transformer le texte du score

public class MenuScript : MonoBehaviour
{
    Text txtHs;

    void Start()
    {
        // txtHs = transform.Find("Hightscore").GetComponent<Text>(); // on cherche l'enfant qui s'appelle Hightscore
        // txtHs.text = "HIGHT SCORE " + PlayerPrefs.GetInt("HS");
    }

    public void Play()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("CharacterCreation");
    }

    public void Continue()
    {
        LoadInformation.LoadAllInformation();
        SceneManager.LoadScene(GameInformation.LevelToLoad);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
