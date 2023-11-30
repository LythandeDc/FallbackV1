using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleRock : MonoBehaviour
{
    /// <summary>
    /// On collision enter 2D
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        Rock thisrock = FindObjectOfType<Rock>();
        thisrock.dropRockPoint.rotation = Quaternion.Euler(0, 0, 0);

        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("destroyed");

        if (col.gameObject.tag == "Player")
        {
            // Reduire la vie
            GameObject.Find("InterfaceCanvas").GetComponent<PlayerInterface>().RemoveHealth(10);
        }

        StartCoroutine(destroyRock());
    }

    /// <summary>
    /// Destroy Rock
    /// </summary>
    /// <param name="rock"></param>
    /// <returns></returns>
    IEnumerator destroyRock()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
