using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnState : AliveState
{
    public TurnState(Player player ,PlayerStateMachine stateMachine,PlayerData playerData,string animBoolName):base(player,stateMachine,playerData,animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Movement?.SetVelocityZero();
        Player.turn = true;

        player.playerMask.color = new Color(0, 0, 0, 0);
    }

    public override void Exit()
    {
        base.Exit();
        Player.turn = false;

        player.playerMask.color = new Color(0, 0, 0, 255);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!player.inputHandler.turnInput)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
