using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController player;
    public IdleState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("[Idle]");
        player.animator.SetBool("isIdle", true);
    }

    public void Update()
    {
        //移動していたら
        if (player.playerInput.inputVector.magnitude != 0)
        {
            if (player.playerInput.shiftInput == 1)
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.runningState);
            else
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.walkingState);
        }
    }

    public void Exit()
    {
        player.animator.SetBool("isIdle", false);
    }
}
