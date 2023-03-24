using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine stateMachine { get; private set; }
    public IdleState idleState { get; private set; }
    public MoveState moveState { get; private set; }

    [SerializeField] PlayerData playerData;
    #endregion

    #region Component
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D movementCollider { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }
    #endregion

    #region other variables
    private Vector2 workspace;

    public bool gameStart;
    #endregion

    #region Unity Callback Function
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        stateMachine = new PlayerStateMachine();

        idleState = new IdleState(this, stateMachine, playerData, "idle");
        moveState = new MoveState(this, stateMachine, playerData, "move");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        movementCollider = GetComponent<BoxCollider2D>();
        inputHandler = GetComponent<PlayerInputHandler>();

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
