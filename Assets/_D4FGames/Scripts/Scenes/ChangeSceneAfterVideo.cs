using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChangeSceneAfterVideo : MonoBehaviour
{
    public string level = "Level1";
    public int secondsToWait = 40;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene(level);
    }
}
