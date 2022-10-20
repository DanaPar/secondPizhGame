using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour
{
    
    public InputField inputfield;
    public string code;

    public GameObject window;
    private bool started;
    public float waitTime = 1;

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
        inputfield.Select();

    }
    public void CheckInput()
    {


        if (inputfield.text.ToUpper() == code)      // check inputfield contains the string password
        {
            Debug.Log("Game Finnished");     // just a debug.Log to show that the password is correct (can be removed)
            WebGLPluginJS.GameFinished();
            ToggleWindow(false);

        }
    }

}