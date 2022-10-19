using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateInput : MonoBehaviour
{
    public Dialogue dialogueScript;
    public InputField inputfield;
    public string code;

    public GameObject window;
    private bool started;


    private void Awake()
    {
        ToggleWindow(false);
    }

    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ShowCodeField()
    {
        if (started) return;
            started = true;
            //Show window
            ToggleWindow(true);
        
    }
    public void CheckInput()
    {
       

        if (inputfield.text.ToUpper() == code)      // check inputfield contains the string password
        {
            Debug.Log("Password accepted");     // just a debug.Log to show that the password is correct (can be removed)
            ToggleWindow(false);
            dialogueScript.StartDialogue();

        }
    }

}
