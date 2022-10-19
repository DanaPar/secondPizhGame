using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTrigger : MonoBehaviour
{
    public ValidateInput inputScript;
    private bool playerDetected;
    //Detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we triggered the player enable playerdetected and show indicator
        if (collision.tag == "Player")
        {
            playerDetected = true;
            
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //if we lost trigger the player disable playerdetected and hide indicator
        if (collision.tag == "Player")
        {
            playerDetected = false;
            
        }
    }

    //while detected if we interact start the dialogue
    private void Update()
    {
        if (playerDetected)
        {
           
            inputScript.ShowCodeField();
        }
    }

}
