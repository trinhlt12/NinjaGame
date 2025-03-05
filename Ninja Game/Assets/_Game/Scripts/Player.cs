using _Game.Scripts.StateMachine;
using _Game.Scripts.StateMachine.PlayerSM;
using UnityEngine;

namespace _Game.Scripts
{
    public partial class Player : Character
    {
        #region VARIABLES

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private CapsuleCollider2D playerCollider;
        
        public PlayerBlackboard playerBB;

        private bool _isIdle;
        private bool _isJumping;
        private bool _isAttacking;
        private bool _isRunning;
        private bool _isFalling;

        private float _horizontal;
        private float _vertical;
        private Vector3 _platformOffset;

        private int _coinAmount;

        private Vector3 _savePoint;

        public StateMachine<PlayerBlackboard> _playerStateMachine;

        #endregion
        
        #region INHERITED-FUNCTIONS

        public override void OnInit()
        {
            base.OnInit();
            _playerStateMachine = new StateMachine<PlayerBlackboard>();
            if (playerBB == null)
            {
                playerBB = gameObject.AddComponent<PlayerBlackboard>();
            }
            playerBB.InitializeStates(_playerStateMachine);
            
            _playerStateMachine.InitializeStateMachine(playerBB.playerIdleState, playerBB);
            playerBB.SetSavePoint(transform.position);
            transform.position = playerBB.savePoint;
        }

        #endregion

        #region UNITY-FUNCTIONS

        private void Update()
        {
            playerBB.isGrounded = CheckIfGrounded();
            _playerStateMachine.CurrentState.StateUpdate();
        }

        private void FixedUpdate()
        {
            _playerStateMachine.CurrentState.StateFixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Coin"))
            {
                _coinAmount++;
                Destroy(collision.gameObject);
            }

            if (collision.CompareTag("DeathZone"))
            {
                playerBB.isDead = true;
                _playerStateMachine.ChangeState(playerBB.playerDieState);
            }
        }


        private void OnDrawGizmos()
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.down * playerCollider.size.y / 2,
                playerBB.isGrounded ? Color.green : Color.red);
        }

        #endregion

        #region CUSTOM-FUNCTIONS

        private bool CheckIfGrounded()
        {
            var colliderHeight = playerCollider.size.y;

            var hit = Physics2D.Raycast(transform.position, Vector2.down, colliderHeight / 2 + 0.5f, groundLayer);

            if (hit.collider == null)
            {
                playerBB.currentMovingPlatform = null;
                return false;
            }

            if (hit.collider.gameObject.TryGetComponent(out IMovingPlatform movingPlatform))
            {
                playerBB.currentMovingPlatform = movingPlatform;
                _platformOffset = transform.position - movingPlatform.Position;
            }

            return true;
        }

        #endregion
    }
}