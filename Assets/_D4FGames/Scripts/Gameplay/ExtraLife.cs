using UnityEngine;
using System.Collections;

public class ExtraLife : MonoBehaviour
{
	public int livesToGive;
    // public GameObject checkpoint;
    // public bool isCheckpoint;
    private PlayerInterface theLevelManager;

	// Use this for initialization
	void Start ()
    {
		theLevelManager = FindObjectOfType<PlayerInterface>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			theLevelManager.AddLives(livesToGive);
			gameObject.SetActive(false);
		}
	}
}
