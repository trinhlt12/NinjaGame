using System.Collections.Generic;
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
            if (playerCollider == null) return;

            var colliderHeight = playerCollider.size.y;
            var colliderWidth = playerCollider.size.x;

            Vector2 originMiddle = transform.position;
            Vector2 originLeft = originMiddle + Vector2.left * (colliderWidth / 2) * 0.5f;
            Vector2 originRight = originMiddle + Vector2.right * (colliderWidth / 2) * 0.5f;

            float rayLength = colliderHeight / 2;
    

            /*Debug.DrawLine(originMiddle, originMiddle + Vector2.down * rayLength, 
                playerBB.isGrounded ? Color.green : Color.red);*/
            Debug.DrawLine(originLeft, originLeft + Vector2.down * rayLength, 
                playerBB.isGrounded ? Color.green : Color.red);
            Debug.DrawLine(originRight, originRight + Vector2.down * rayLength,
                playerBB.isGrounded ? Color.green : Color.red);
            
        }


        #endregion

        #region CUSTOM-FUNCTIONS

        private bool CheckIfGrounded()
        {
            var colliderHeight = playerCollider.size.y;
            var colliderWidth = playerCollider.size.x;
            
            Vector2 originMiddle = transform.position;
            Vector2 originLeft = originMiddle + Vector2.left * ((colliderWidth / 2) * 0.5f);
            Vector2 originRight = originMiddle + Vector2.right * ((colliderWidth / 2) * 0.5f);

            /*
            var hitMiddle = Physics2D.Raycast(transform.position, Vector2.down, colliderHeight / 2, groundLayer);
            */
            var hitLeft = Physics2D.Raycast(originLeft, Vector2.down, colliderHeight / 2, groundLayer);
            var hitRight = Physics2D.Raycast(originRight, Vector2.down, colliderHeight / 2, groundLayer);
            
            List<RaycastHit2D> hits = new List<RaycastHit2D>() { hitLeft, hitRight};

            foreach (var hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.TryGetComponent(out IMovingPlatform movingPlatform))
                    {
                        playerBB.currentMovingPlatform = movingPlatform;
                        _platformOffset = transform.position - movingPlatform.Position;
                    }

                    return true;
                }
            }
            playerBB.currentMovingPlatform = null;
            return false;
        }

        #endregion
    }
}