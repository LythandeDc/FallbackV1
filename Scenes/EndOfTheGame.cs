using System.Collections;
using UnityEngine.UI; //pour transformer le texte du score
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheGame : MonoBehaviour {

    public string level = "MainMenu";

    void TheEnd()
    {
        // Sauvegardes ...

        SceneManager.LoadScene(level);
    }
}
