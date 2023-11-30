using UnityEngine;
using System.Collections;

public class ResetOnRespawn : MonoBehaviour
{
	private Vector3 startPosition;
	private Quaternion startRotation;
	private Vector3 startLocalScale;

	private Rigidbody2D myRigidbody;
    private BoxCollider2D boxcollider;

	/// <summary>
    /// START
    /// </summary>
	void Start ()
    {
		startPosition = transform.position;
		startRotation = transform.rotation;
		startLocalScale = transform.localScale;

		if(gameObject.GetComponent<Rigidbody2D>() != null)
		{
			myRigidbody = GetComponent<Rigidbody2D>();
        }

        if(gameObject.GetComponent<BoxCollider2D>() != null)
        {
            boxcollider = GetComponent<BoxCollider2D>();
        }
    }

    /// <summary>
    /// RESET OBJECT
    /// </summary>
	public void ResetObject()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;

        if (myRigidbody != null)
        {
            myRigidbody.velocity = Vector3.zero;
        }

        if (boxcollider != null && boxcollider.enabled == false)
        {
            boxcollider.enabled = true;
        }

        if (this.GetComponent<EnemieController>() != null)
        {
            if (gameObject.activeSelf == true &&
                GetComponent<EnemieController>().enemieLife == 0 &&
                GetComponent<EnemieController>().dead == true)
            {
                GetComponent<EnemieController>().enemieLife = 50;
                GetComponent<EnemieController>().dead = false;
                GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<EnemieController>().crunning = false; 
            }
        }

        if (this.GetComponent<EnemieNoFollow>() != null &&
            GetComponent<EnemieNoFollow>().dead == true)
        {
            GetComponent<EnemieNoFollow>().dead = false;
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
