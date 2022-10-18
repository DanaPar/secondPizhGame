using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    //Player
    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    //Animations
    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_DOWN = "Player_down";
    const string PLAYER_UP = "Player_up";
    const string PLAYER_RIGHT = "Player_right";
    const string PLAYER_LEFT = "Player_left";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical !=0)
            {
                inputHorizontal *= speedLimiter;
                inputHorizontal *= speedLimiter;
            }
            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            if(inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_RIGHT);
            }
            else if(inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_LEFT);
            }
            else if(inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_UP);
            }
            else if(inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_DOWN);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    //Animation chnger
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}

