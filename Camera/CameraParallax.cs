using UnityEngine;
using System.Collections;

public class CameraParallax : MonoBehaviour
{
    // Variables
    public GameObject Player; // gameobject du player
    	
	// Update is called once per frame
	void Update ()
    {
        GameObject movingp = GameObject.FindGameObjectWithTag("Player");
        if(movingp != null)
            transform.position = new Vector3(movingp.transform.position.x, transform.localPosition.y, transform.localPosition.z);
	}
}
