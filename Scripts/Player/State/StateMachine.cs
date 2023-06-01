using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public WalkingState walkingState;
    public RunningState runningState;
    public IdleState idleState;

    public StateMachine(PlayerController player)
    {
        this.walkingState = new WalkingState(player);
        this.runningState = new RunningState(player);
        this.idleState = new IdleState(player);
    }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public void FixedUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.FixedUpdate();
        }
    }
}
