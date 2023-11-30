using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float thex = 1;
    public float they = 3;

    public Dialogue dialogue;
    public DialogueManager manager;
    public GameObject target; // player
    public RectTransform mRectTransform;

    /// <summary>
    /// Trigger Dialogue
    /// </summary>
    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogue);
    }

    /// <summary>
    /// On Trigger Star 2D
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(target.GetComponent<PlayerController>().isTalking == true)
            {
                Debug.Log(target.transform.position.y + they);
                mRectTransform.anchoredPosition = new Vector2(target.transform.position.x + thex, target.transform.position.y + they);
            }
        }
    }

    /// <summary>
    /// On Trigger Exit 2D
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().anim.SetBool("isOpen", false);
            FindObjectOfType<DialogueManager>().isOpen = false;
            FindObjectOfType<DialogueManager>().canTalk = true;
        }
    }
}
