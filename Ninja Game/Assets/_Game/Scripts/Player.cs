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
        [SerializeField] private PlayerBlackboard playerBB;

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

        private StateMachine<PlayerBlackboard> _playerStateMachine;

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
            SetSavePoint(transform.position);
            transform.position = _savePoint;
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
                /*
                ChangeAnim("die");
                */

                Invoke(nameof(OnInit), 1f);
            }
        }


        private void OnDrawGizmos()
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.down * playerCollider.size.y / 2,
                playerBB.isGrounded ? Color.green : Color.red);
        }

        #endregion

        #region CUSTOM-FUNCTIONS

        /*private void PlayerUpdate()
        {
            _isGrounded = CheckIfGrounded();

            //jump
            if (Input.GetKeyDown(KeyCode.Space)) _isJumping = true;
            //attack
            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J))
            {
                if (!_isGrounded) return;
                Attack();
            }
        }*/

        /*private void PlayerFixedUpdate()
        {
            if (_isDead) return;

            //check if player is on moving platform
            if (_currentMovingPlatform != null && rb.velocity.magnitude <= 0.1f)
            {
                var newPosition = _currentMovingPlatform.Position + _platformOffset;
                transform.position = newPosition;
            }

            rb.gravityScale = _isFalling ? 2.5f : 1.5f;

            //jump
            if (_isJumping && _isGrounded) Jump();
            if (!_isGrounded && rb.velocity.y < 0)
            {
                _isFalling = true;
                ChangeAnim("fall");
                _isJumping = false;
            }
            else
            {
                _isFalling = false;
            }

            _horizontal = Input.GetAxisRaw("Horizontal");

            //Moving / run
            if (_isAttacking || _isFalling) return;
            if (Mathf.Abs(_horizontal) > 0.1f)
            {
                ChangeAnim("run");
                rb.velocity = new Vector2(_horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
                transform.rotation = Quaternion.Euler(new Vector3(0, _horizontal > 0 ? 0 : 180, 0));
            }
            else if (_isGrounded) //idle
            {
                ChangeAnim("idle");
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }*/

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

        // ReSharper disable Unity.PerformanceAnalysis
        /*private void Attack()
        {
            rb.velocity = Vector2.zero;
            if (_isAttacking) return;
            _isAttacking = true;
            ChangeAnim("attack");
            //reset attack
            Invoke(nameof(ResetAttack), 0.5f);
        }*/

        /*private void ResetAttack()
        {
            _isAttacking = false;
            ChangeAnim("idle");
        }*/

        /*private void Throw()
        {
            ChangeAnim("throw");
        }*/

        /*private void Jump()
        {
            ChangeAnim("jump");
            rb.AddForce(jumpForce * Vector2.up);
            _isJumping = false;
        }*/

        public void SetSavePoint(Vector3 savePoint)
        {
            _savePoint = savePoint;
        }

        #endregion
    }
}