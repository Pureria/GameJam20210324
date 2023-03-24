using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Core core;

    protected Enemy enemy;
    protected FiniteStateMachine stateMachine;
    protected EntityData entityData;

    protected bool isExitingState;

    private string animBoolName;

    public State(Enemy enemy,FiniteStateMachine stateMachine,EntityData entityData,string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.entityData = entityData;
        this.animBoolName = animBoolName;
        core = enemy.Core;
    }

    public virtual void Enter()
    {
        DoCheck();
        enemy.Anim.SetBool(animBoolName, true);
        isExitingState = false;
    }

    public virtual void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck() { }
}
