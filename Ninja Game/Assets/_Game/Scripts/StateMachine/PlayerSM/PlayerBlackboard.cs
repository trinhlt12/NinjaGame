using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerBlackboard : Blackboard
    {
        public Player player;
        public LayerMask groundLayer;
        public CapsuleCollider2D playerCollider;        
        public IMovingPlatform currentMovingPlatform;
        
        public Vector3 savePoint;

        public float speed;
        public float jumpForce;
        public float horizontal;
        public float lastXVelocity;
        public float attackCooldown = 2.0f;
        public float lastAttackTime = -1f;
        
        public bool isFacingRight;
        public bool isGrounded;
        public bool isDead;
        public bool isAttacking = false;
        
        public PlayerIdleState playerIdleState { get; private set; }
        public PlayerRunState playerRunState { get; private set; }
        public PlayerJumpState playerJumpState { get; private set; }
        public PlayerAttackState playerAttackState { get; private set; }
        public PlayerFallState playerFallState { get; private set; }
        public PlayerDieState playerDieState { get; private set; }
        
        public PlayerBlackboard(Player player)
        {
            this.player = player;
            this.rigidbody2D = player.GetComponent<Rigidbody2D>();
            this.animator = player.GetComponent<Animator>();
        }

        public override void InitializeStates<T>(StateMachine<T> stateMachine)
        {
            base.InitializeStates(stateMachine);
            if (stateMachine is StateMachine<PlayerBlackboard> playerStateMachine)
            {
                playerIdleState = new PlayerIdleState(playerStateMachine, this, "idle");
                playerRunState = new PlayerRunState(playerStateMachine, this, "run");
                playerJumpState = new PlayerJumpState(playerStateMachine, this, "jump");
                playerAttackState = new PlayerAttackState(playerStateMachine, this, "attack");
                playerFallState = new PlayerFallState(playerStateMachine, this, "fall");
                playerDieState = new PlayerDieState(playerStateMachine, this, "die");
            }
        }
        
        public void SetSavePoint(Vector3 newSavePoint)
        {
            savePoint = newSavePoint;
        }
    }
}