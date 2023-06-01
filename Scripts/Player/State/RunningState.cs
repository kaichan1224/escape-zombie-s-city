using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RunningState : IState
{
    private PlayerController player;
    [SerializeField] private float runSpeed = 4000f;
    private Vector3 latestPos;
    private Vector3 runningVelocity;
    public RunningState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("[Run]");
        player.animator.SetBool("isRun", true);
    }

    public void Update()
    {
        if (player.playerInput.inputVector.magnitude == 0)
            player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.idleState);
        if(player.playerInput.shiftInput == 0 && player.playerInput.inputVector.magnitude != 0)
            player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.walkingState);
    }

    public void FixedUpdate()
    {
        runningVelocity = player.playerInput.inputVector.normalized * runSpeed;
        player.rb.velocity = (runningVelocity * Time.fixedDeltaTime);
        //前フレームとの位置の差から進行方向を割り出してその方向に回転します。
        //前フレームとの位置の差から進行方向を割り出してその方向に回転します。
        Vector3 screenPlayerPos = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector3 screenMousePos = Input.mousePosition;
        Vector3 differenceDis = new Vector3(screenMousePos.x, 0, screenMousePos.y) - new Vector3(screenPlayerPos.x, 0, screenPlayerPos.y);
        if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
        {
            Quaternion rot = Quaternion.LookRotation(differenceDis);
            rot = Quaternion.Slerp(player.rb.transform.rotation, rot, 0.2f);
            player.transform.rotation = rot;
        }
    }

    public void Exit()
    {
        player.animator.SetBool("isRun", false);
    }
}