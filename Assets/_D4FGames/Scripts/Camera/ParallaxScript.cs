using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {

    // Variables
    float offset;
    public int speed; // vitesse de défilement
    public GameObject Player;

	void Update ()
    {
        // il faut diviser par speed sinon ce sera trop rapide
        offset = Player.transform.position.x / speed; 
        // Permet de bouger les layers par rapport à la vitesse de chaque couche.
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
