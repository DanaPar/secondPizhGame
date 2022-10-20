using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScene : MonoBehaviour
{

    public Dialogue dialogueScript;
    // Start is called before the first frame update
    void Start()
    {
        dialogueScript.StartDialogue();
    }

   
}
