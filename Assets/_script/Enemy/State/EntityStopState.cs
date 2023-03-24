using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStopState : State
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;

    private bool range;

    public EntityStopState(Enemy enemy,FiniteStateMachine stateMachine,EntityData entityData,string animBoolName):base(enemy,stateMachine,entityData,animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        range = Player.range;

        Movement?.SetVelocityZero();
        if(range)
        {
            Movement?.SetVelocity(entityData.criticalMovementVelocity, entityData.angle.normalized, -1);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!range)
        {
            Movement?.SetVelocityX(entityData.slowMovementVelocity);
        }

        if(!Player.turn)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
        else if (Player.dead)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
