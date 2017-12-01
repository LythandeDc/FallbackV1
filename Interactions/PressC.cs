using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressC : MonoBehaviour
{
    public float plusy = 1f;
    public float plusx = 0.5f;

    public GameObject pressc;
    Vector3 currentPos;
    Transform presscposition;

    void Start()
    {
        pressc.SetActive(false);
        presscposition = pressc.GetComponent<Transform>();

        presscposition.localPosition = new Vector3(transform.position.x + plusx, transform.position.y + plusy, transform.position.z);
    }

    void Update()
    {
        currentPos = transform.localPosition;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "dialogue")
        {
            Debug.Log(currentPos.y);
            pressc.SetActive(true);
            presscposition.position = new Vector3(currentPos.x + plusx, currentPos.y + plusy, transform.position.z);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "dialogue")
        {
            pressc.SetActive(false);
        }
    }
}
