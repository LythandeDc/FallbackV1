using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public bool canDestroy = true;
    public string levelDestroy = "Intro";

	/// <summary>
    /// AWAKE
    /// </summary>
	void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (canDestroy && scene.name == levelDestroy)
            Destroy(transform.root.gameObject);
    }
}
