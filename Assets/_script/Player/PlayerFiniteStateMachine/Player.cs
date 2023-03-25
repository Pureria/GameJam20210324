using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine stateMachine { get; private set; }
    public IdleState idleState { get; private set; }
    public MoveState moveState { get; private set; }
    public TurnState turnState { get; private set; }
    public DeadState deadState { get; private set; }

    [SerializeField] PlayerData playerData;

    public bool alive { get; private set; }
    #endregion

    #region Component
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D movementCollider { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }
    public AudioSource heartAS { get; private set; }

    public CollisionSenses CollisionSenses { get => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses); }
    private CollisionSenses collisionSenses;
    #endregion

    #region other variables
    private Vector2 workspace;

    public static bool dead;
    public static bool goal;
    public static bool gameStart;
    public static bool range { get; private set; }
    public static bool turn;

    public SpriteRenderer playerMask;

    [SerializeField] private Transform goalPos;
    #endregion

    #region Unity Callback Function
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        stateMachine = new PlayerStateMachine();

        alive = true;
        goal = false;
        idleState = new IdleState(this, stateMachine, playerData, "idle");
        moveState = new MoveState(this, stateMachine, playerData, "move");
        turnState = new TurnState(this, stateMachine, playerData, "turn");
        deadState = new DeadState(this, stateMachine, playerData, "dead");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        movementCollider = GetComponent<BoxCollider2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        heartAS = GetComponent<AudioSource>();

        stateMachine.Initialize(idleState);
        dead = false;
    }

    private void Update()
    {
        Core.LogicUpdate();
        stateMachine.CurrentState.LogicUpdate();        

        if (!gameStart)
        {
            heartAS.Stop();
            if (inputHandler.turnInput)
            {
                heartAS.Play();
                gameStart = true;
                inputHandler.turnInput = false;
            }
        }

        heartAS.volume = playerData.MaxVolume;
        if (CollisionSenses.cliticalRange)
        {
            heartAS.volume = 0f;
            range = true;
        }
        else if (CollisionSenses.minRange)
        {
            heartAS.pitch = playerData.minRange;
            range = false;
        }
        else if (CollisionSenses.middleRange)
        {
            heartAS.pitch = playerData.middleRange;
            range = false;
        }
        else if (CollisionSenses.maxRange)
        {
            heartAS.pitch = playerData.maxRange;
            range = false;
        }

        if(transform.position.x > goalPos.position.x)
        {
            gameManager.half = false;
            goal = true;
            stateMachine.ChangeState(idleState);
            heartAS.Stop();
            playerMask.color = new Color(0, 0, 0, 0);
            Debug.Log("ƒS[ƒ‹II");
        }

        if (dead && stateMachine.CurrentState != deadState)
        {
            gameManager.half = false;
            stateMachine.ChangeState(deadState);
            heartAS.Stop();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.layer == playerData.whatIsEnemyNo)
        {
            gameManager.half = false;
            stateMachine.ChangeState(deadState);
            heartAS.Stop();
        }
    }
    #endregion

    #region Other Function
    public void PlayerDead() => dead = true;
    #endregion
}
