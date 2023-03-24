using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region StateVariables
    public FiniteStateMachine stateMachine { get; private set; }
    public EntityIdleState idleState { get; private set; }
    public EntityMoveState moveState { get; private set; }
    public EntityStopState stopState { get; private set; }


    [SerializeField] EntityData entityData;
    #endregion

    #region Component
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D movementCollider { get; private set; }
    #endregion

    #region other variables
    private Vector2 workspace;
    #endregion

    #region Unity CallbackFunction
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        stateMachine = new FiniteStateMachine();

        idleState = new EntityIdleState(this, stateMachine, entityData, "idle");
        moveState = new EntityMoveState(this, stateMachine, entityData, "move");
        stopState = new EntityStopState(this, stateMachine, entityData, "stop");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        movementCollider = GetComponent<BoxCollider2D>();

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        stateMachine.CurrentState.LogicUpdate();
    }
    #endregion

    #region Other Function
    #endregion
}
