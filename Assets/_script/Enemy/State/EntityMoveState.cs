using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveState : State
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;

    public EntityMoveState(Enemy enemy,FiniteStateMachine stateMachine,EntityData entityData,string animBoolName):base(enemy,stateMachine,entityData,animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.CheckIfSouleFlip(1);
        Movement?.SetVelocityX(entityData.movementVelocity);

        if(Player.turn)
        {
            stateMachine.ChangeState(enemy.stopState);
        }
        else if(Player.dead || Player.goal)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
