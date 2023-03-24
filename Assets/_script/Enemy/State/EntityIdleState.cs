using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityIdleState : State
{
    public EntityIdleState(Enemy enemy,FiniteStateMachine stateMachine,EntityData entityData,string animBoolName):base(enemy,stateMachine,entityData,animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Player.gameStart && !Player.dead)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
