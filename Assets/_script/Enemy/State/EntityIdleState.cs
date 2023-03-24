using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityIdleState : State
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;

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

        Movement?.SetVelocityZero();

        if (Player.gameStart && !Player.dead && !Player.goal)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
