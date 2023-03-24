using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AliveState
{
    public IdleState(Player player,PlayerStateMachine stateMachine,PlayerData playerData,string animBoolName):base(player,stateMachine,playerData,animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Player.gameStart)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
