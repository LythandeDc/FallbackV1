using UnityEngine;
using System.Collections;

public class HoldItem : MonoBehaviour
{
    public bool canHold = false, canMove = false;
    public GameObject grab; // the object to grab
    public Transform target; // the target of the object to grab
    public Transform guide; // player
    private SpriteRenderer sprite;
    public const string LAYER_NAME = "Objects2";
    public const string LAYER_NAME_GRABBED = "Grabbed";

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        while (canHold == true && canMove == false)
        {
            canHold = false;
            canMove = true;
        }
    }

    // UPDATE
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (canHold == false && canMove == true &&
            grab.transform.parent.name == "Player" && grab.transform.parent.name != grab.name
            && grab.GetComponent<HoldItem>().enabled == true)
        {
            Debug.Log(guide.GetComponent<SpriteRenderer>().flipX);

            // DROITE
            if (h > 0 || guide.GetComponent<SpriteRenderer>().flipX == false)
            {
                grab.transform.position = new Vector3(guide.position.x + 1, guide.position.y, 0);
            }
            // GAUCHE
            if (h < 0 || guide.GetComponent<SpriteRenderer>().flipX == true)
            {
                grab.transform.position = new Vector3(guide.position.x - 1, guide.position.y, 0);
            }
        }

        if (canHold == true && canMove == false &&
            grab.transform.parent.name == "Player" && grab.transform.parent.name != grab.name
            && grab.GetComponent<HoldItem>().enabled == true)
        {
            // DROITE
            if (h > 0 || guide.GetComponent<SpriteRenderer>().flipX == false)
            {
                grab.transform.position = new Vector3(guide.position.x + 1, guide.position.y, 0);
            }
            // GAUCHE
            if (h < 0 || guide.GetComponent<SpriteRenderer>().flipX == true)
            {
                grab.transform.position = new Vector3(guide.position.x - 1, guide.position.y, 0);
            }
        }

        foreach (Transform child in guide)
        {
            if(child.CompareTag("grab"))
            {
                // Debug.Log("grab actif");
                // canHold = true;
                // canMove = false;
            }
        }
    } // update

    // On trigger
    void OnTriggerEnter2D(Collider2D col)
    {
        canHold = false;
        canMove = true;
        // Debug.Log("On Trigger Enter 2D " + gameObject.name);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (canHold == false && canMove == true && 
            grab.GetComponent<HoldItem>().enabled == true && 
            Input.GetKeyDown(KeyCode.X))
        {
            Pickup();
        }
    }

    // Exit
    void OnTriggerExit2D(Collider2D col)
    {
        canHold = false;
        canMove = true;
    }

    // PICKUP
    private void Pickup()
    {
        if (!grab)
            return;

        // je recupère tous les objets avec le tag grab
        GameObject[] thegrabs = GameObject.FindGameObjectsWithTag("grab");
        int thisObjects = 0; // utilitaire

        // Vérifier tous les objets de tipe grab
        for (int i = 0; i < thegrabs.Length; i++)
        {
            // Si tous les objets grab peuvent etre utilisés je rajoute un int
            if (canHold == false && canMove == true)
            {
                thisObjects += 1;
            }

            // Vérifier le tag dans les fils du player
            foreach (Transform tr in guide)
            { 
                // Si le tag est égal à le tag du fils du player alors je rajoute un int
                if (tr.tag == grab.tag)
                {
                    thisObjects += 1;
                }
            }

            // Si et seulement si un grab peu etre pris
            if (thisObjects == 1)
            {
                canHold = false;
                canMove = true;

                if (canHold == false && canMove == true &&
                    grab.transform.parent.name != "Player" &&
                    grab.transform.parent.name == grab.name)
                {
                    // We set the object parent to our guide empty object.
                    grab.transform.SetParent(guide);

                    // we apply the same rotation our main object (Camera) has.
                    grab.transform.localRotation = transform.rotation;
                    // We re-position the grab on our guide object
                    grab.transform.position = guide.position;
                    // Layer
                    sprite.sortingLayerName = LAYER_NAME_GRABBED;
                }
            }
            else
            {
                canHold = true;
                canMove = false;
            }
        }
    }

    // THROW DROP
    public void Throw()
    {
        Debug.Log("Throw " + gameObject.name);

        if (!grab)
            return;

        sprite.sortingLayerName = LAYER_NAME;
        grab.transform.SetParent(target);
        grab = this.gameObject;
        transform.position = grab.transform.position;

        canHold = true;
        canMove = false;
    }
} // END class