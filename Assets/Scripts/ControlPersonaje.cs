using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{



    private enum PlayerState
    {
        Idle,
        IdleBreaker,
        Walk,
        Run,
        Jump
    }

    public Animator AnimatorController;
    private PlayerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        SetState(PlayerState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerState newState = determinateState();
        if (newState != currentState)
            SetState(newState);
    }

    private void SetState(PlayerState newState)
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                AnimatorController.SetBool("Idle", false);
                break;

            case PlayerState.IdleBreaker:
                AnimatorController.SetBool("IdleBreaker", false);
                break ;
            case PlayerState.Walk:
                AnimatorController.SetBool("Walk", false);
                break;
            case PlayerState.Run:
                AnimatorController.SetBool("Run", false);
                break;
            case PlayerState.Jump:
                AnimatorController.SetBool("Jump", false) ;
                break;
        }

        switch (newState)
        {
            case PlayerState.Idle:
                AnimatorController.SetBool("Idle", true);
                break;
            case PlayerState.IdleBreaker:
                AnimatorController.SetBool("IdleBreaker", true);
                break;
            case PlayerState.Walk:
                AnimatorController.SetBool("Walk", true);
                break;
            case PlayerState.Run:
                AnimatorController.SetBool("Run", true);
                break;
            case PlayerState.Jump:
                AnimatorController.SetBool("Jump", true);
                break;
        }
        currentState = newState;
    }

    private PlayerState determinateState()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            return PlayerState.IdleBreaker;

        else if (IsJumping())
        {
            return PlayerState.Jump;
        }
        else if (IsRunning())
        {
            return PlayerState.Run;
        }
        else if (IsWalking())
        {
            return PlayerState.Walk;
        }
        else
        {
            return PlayerState.Idle;
        }
    }

    private bool IsWalking()
    {
        return Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift);
    }
    private bool IsRunning()
    {
        return Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift);
    }

    private bool IsJumping()
    {
        return Input.GetKey(KeyCode.A);
    }
}
