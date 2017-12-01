using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndPointScript : MonoBehaviour
{
    Animator Anim;
    public string LevelToLoad;
    public AudioClip SoundWin;


    // Use this for initialization
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            // win
            // Anim.SetTrigger("win");

            // Musique du level du canvas stop
            var theCanvas = GameObject.FindWithTag("InterfaceCanvas").GetComponent<AudioSource>();

            if (theCanvas.isPlaying)
            {
                theCanvas.Stop();
                Debug.Log("Musique arretée");
            }
            else
            {
                Debug.Log("Pas de son dans le canvas du level");
            }
            // end canvas

            GetComponent<AudioSource>().PlayOneShot(SoundWin);
            GetComponent<BoxCollider2D>().enabled = false; // on désactive le box collider

            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        // Passage des variables
        GameInformation.LevelToLoad = LevelToLoad;
        GameInformation.Gold = GameObject.Find("Player").GetComponent<PlayerController>().TheGold();
        GameInformation.CurrentXP = GameObject.Find("Player").GetComponent<PlayerController>().tmpxp;
        GameInformation.Health = GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().Health;
        GameInformation.PlayerLevel = GameObject.Find("Player").GetComponent<PlayerController>().tmpLevel;
        SaveInformation.SaveAllInformation();

        float fadeTime = GameObject.Find("GameController").GetComponent<Fading>().BeginFade(2);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(LevelToLoad);
    }
}
