using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AliveState : PlayerState
{
    protected bool alive;

    protected bool turnInput;

    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;

    public AliveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    { }

    public override void DoCheck()
    {
        base.DoCheck();

        alive = player.alive;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        turnInput = player.inputHandler.turnInput;

        if(stateMachine.CurrentState == player.idleState)
        {

        }
        else if(!alive)
        {
            //TODO::AliveState::Deadステータスに移行
        }
        else if(turnInput) 
        {
            stateMachine.ChangeState(player.turnState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void PlayerDead() { alive = false; }
}
