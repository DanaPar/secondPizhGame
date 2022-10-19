using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Text component
    public TMP_Text dialogueText;
    //Dialogue list
    public List<string> dialogues;
    //Writing speed
    public float writingSpeed;
    //Index on dialogue
    private int index;
    //Character index
    private int charIndex;
    //started boolean
    private bool started;
    //wait for next boolean
    private bool waitForNext;

    private bool isEnded;

    public GameObject createTrigger;
    public GameObject destroyTrigger;

    private void Awake()
    {
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    //Start Dialogue
    public void StartDialogue()
    {
        if (started) return;
        if (!isEnded)
        {//boolean indicate that we have started
            started = true;
            //Show window
            ToggleWindow(true);
            //start with first dialogue
            GetDialogue(0);
        }   
        
    }

    private void GetDialogue(int i)
    {
        //start index at zero
        index = i;
        //reset character index
        charIndex = 0;
        //clear dialogue component text
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }
    //End dialogue
    public void EndDialogue()
    {
        //started is disabled
        started = false;
        waitForNext = false;
        StopAllCoroutines();
        //hide window
        ToggleWindow(false);
        isEnded = true;
        TriggerManager();
        
    }
    //Writing logic
    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);
        string currentDialogue = dialogues[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index
        charIndex++;
        //make sure reached end of sentence
        if(charIndex < currentDialogue.Length)
        {
            //wait x seconds
            yield return new WaitForSeconds(writingSpeed);
            //restart same process
            StartCoroutine(Writing());
        }
        else
        {
            //end this sentence and wait for next one
            waitForNext = true;
        }

    }

    private void Update()
    {
        if (!started) return;

        if(waitForNext && Input.GetKeyDown(KeyCode.Space))
        {
            waitForNext = false;
            index++;
            if(index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                EndDialogue();
            }
        }
    }

    public void TriggerManager()
    {
        Collider2D newTrigger = createTrigger.GetComponent<Collider2D>();
        Collider2D destroyableTrigger = destroyTrigger.GetComponent<Collider2D>();

        newTrigger.isTrigger = true;
        destroyableTrigger.isTrigger = false;
    }

}
