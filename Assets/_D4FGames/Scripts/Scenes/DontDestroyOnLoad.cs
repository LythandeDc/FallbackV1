using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public bool canDestroy = true;
    public string levelDestroy = "Intro";
    public string levelOk = "CharacterCreation";
    public string menuname = "Menu";
    Scene scene;

    /// <summary>
    /// AWAKE
    /// </summary>
    void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (canDestroy && scene.name != menuname && canDestroy && scene.name != levelOk)
            Destroy(transform.root.gameObject);
    }
}
