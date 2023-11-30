using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // permet de gerer les scènes

public class GameOverScript : MonoBehaviour
{
	void Start ()
    {
        StartCoroutine(ChargeMenu());
        // PlayerPrefs.SetInt("Score", 0);
    }

    // Coroutine
    IEnumerator ChargeMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
}
