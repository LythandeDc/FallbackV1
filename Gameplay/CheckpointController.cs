using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour
{
	public Sprite flagClosed;
	public Sprite flagOpen;

	private SpriteRenderer theSpriteRenderer;

	public bool checkpointActive;

	/// <summary>
    /// START
    /// </summary>
	void Start ()
    {
		theSpriteRenderer = GetComponent<SpriteRenderer>();
	}

    /// <summary>
    /// ON TRIGGER ENTER
    /// </summary>
    /// <param name="col"></param>
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			theSpriteRenderer.sprite = flagOpen;
			checkpointActive = true;
		}
	}
}
