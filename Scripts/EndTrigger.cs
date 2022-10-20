using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public TheEnd inputScript;
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
 

    //while detected if we interact start the dialogue
    private void Update()
    {
        if (playerDetected)
        {

            inputScript.ShowCodeField();
        }
    }
}
