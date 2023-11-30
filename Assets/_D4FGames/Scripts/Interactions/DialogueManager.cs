using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;

    public bool isOpen, canTalk = false;

    public Animator anim;
    public GameObject dialogueSuperB;

    /// <summary>
    /// START
    /// </summary>
    void Start ()
    {
        canTalk = true;
        sentences = new Queue<string>();
        anim.SetBool("isOpen", false);
    }

    /// <summary>
    /// START DIALOGUE
    /// </summary>
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
        anim.SetBool("isOpen", true);
        isOpen = true;

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    /// <summary>
    /// DISPLAY NEXT SENTENCE
    /// </summary>
    public void DisplayNextSentence()
    {
        canTalk = false;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    /// <summary>
    /// TYPE SENTENCE
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    
    /// <summary>
    /// END DIALOGUE
    /// </summary>
    void EndDialogue()
    {
        Debug.Log("End of conversation");
        anim.SetBool("isOpen", false);
        isOpen = false;
        canTalk = true;
    }

    void Update()
    {
        if (canTalk == true)
        {
            //if(FindObjectOfType<PlayerController>() != null)
                //Debug.Log("Player is talking : " + FindObjectOfType<PlayerController>().GetComponent<PlayerController>().isTalking);
            // DisplayNextSentence();
        }
    }
}
