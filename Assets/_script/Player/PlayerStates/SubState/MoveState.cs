using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : AliveState
{
    public MoveState(Player player,PlayerStateMachine stateMachine,PlayerData playerData,string animBoolName):base(player,stateMachine,playerData,animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.CheckIfSouleFlip(1);
        Movement?.SetVelocityX(playerData.movementVelocity);
    }
}
