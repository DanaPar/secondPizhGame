using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we triggered the player enable playerdetected and show indicator
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Room2");

        }
    }
}
