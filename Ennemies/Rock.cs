using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour
{
    public float timeBetweenDrops;
    private float timeBetweenDropStore;
    private float dropCount;

    public Transform leftPoint;
    public Transform rightPoint;
    public Transform dropRockPoint;

    public GameObject dropRock;

    public bool takeDamage;

    public int StartingHealth;
    private int currentHealth;

    private CameraController theCamera;
    private PlayerInterface theLevelManager;

    public bool waitingForRespawn, rocksActive, rockIsDestroy;

    // Use this for initialization
    void Start()
    {
        timeBetweenDropStore = timeBetweenDrops;
        dropCount = timeBetweenDrops;
        currentHealth = StartingHealth;

        theCamera = FindObjectOfType<CameraController>();

        theLevelManager = FindObjectOfType<PlayerInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rocksActive)
        {
            if (dropCount > 0)
            {
                dropCount -= Time.deltaTime;
            }
            else
            {
                int randomRotationZ = Random.Range(1, 159); 

                if(rockIsDestroy)
                    dropRockPoint.rotation = Quaternion.Euler(0, 0, 0);
                else
                    dropRockPoint.rotation = Quaternion.Euler(0, 0, randomRotationZ);

                dropRockPoint.position = new Vector3(Random.Range(leftPoint.position.x, rightPoint.position.x), dropRockPoint.position.y, dropRockPoint.position.z);
                Instantiate(dropRock, dropRockPoint.position, dropRockPoint.rotation);
                dropCount = timeBetweenDrops;
            }
        }
    }

    /// <summary>
    /// ON TRIGGER ENTER 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            rocksActive = true;
        }
    }

    /// <summary>
    /// On Trigger Exit 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            rocksActive = false;
        }

        if (col.tag == "Rock")
        {
            Animator anim = col.GetComponent<Animator>();
            rockIsDestroy = true;
            anim.SetTrigger("destroyed");
            StartCoroutine(destroyRock(col.gameObject));
        }
    }

    /// <summary>
    /// Destroy Rock
    /// </summary>
    /// <param name="rock"></param>
    /// <returns></returns>
    IEnumerator destroyRock(GameObject rock)
    {
        yield return new WaitForSeconds(1);
        Destroy(rock);
    }

    // Détecter le player en collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Reduire la vie
            GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().RemoveHealth(10);
        }
    }
}
