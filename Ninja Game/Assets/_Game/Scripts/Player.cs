using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private CapsuleCollider2D playerCollider;
        [SerializeField] private Transform checkGroundPoint;
    
        private bool _isGrounded;
        private bool _isJumping;
        private bool _isAttacking;
        private bool _isRunning;
        private bool _isFalling;
        private bool _isDead = false;
    
        private float _horizontal;
        private float _vertical;
    
        private string _currentAnimName;
        
        private int _coinAmount = 0;

        private Vector3 _savePoint;

        private void Start()
        {
            SetSavePoint(transform.position);
            OnInit();
        }

        private void Update()
        {
            
            if (!_isGrounded) return;   
            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {                
                _isJumping = true;
            }
            //attack
            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J))
            {
                if(!_isGrounded) return;
                Attack();
            }
        }

        private void FixedUpdate()
        {
            if(_isDead) return;
            
            _isGrounded = CheckIfGrounded();

            rb.gravityScale = _isFalling ? 2.5f : 1.5f;

            //jump
            if (_isJumping)
            {                
                Jump();
            }
            
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

            if (_isGrounded)
            {
                //change anim run
                if (Mathf.Abs(_horizontal) > 0.1f && !_isAttacking)
                {
                    ChangeAnim("run");
                }
                
            }
            
            //Moving
            if(_isAttacking) return;
            if (Mathf.Abs(_horizontal) > 0.1f)
            {
                rb.velocity = new Vector2(_horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
                transform.rotation = Quaternion.Euler(new Vector3(0, _horizontal > 0 ? 0 : 180, 0));
            }else if (_isGrounded && !_isJumping)
            {
                ChangeAnim("idle");
                rb.velocity = Vector2.zero;
            }
        }

        public void OnInit()
        {
            _isDead = false;
            _isAttacking = false;
            _isFalling = false;
            _isJumping = false;
            
            transform.position = _savePoint;
            
            ChangeAnim("idle");
        }

        private bool CheckIfGrounded()
        {
            /*
            Debug.Log(rb.velocity.y);
            */
            Vector3 pos = transform.position ;
            
            float colliderHeight = playerCollider.size.y;
            Debug.DrawLine(pos, pos + Vector3.down * (colliderHeight/2 + 0.1f),  _isGrounded ? Color.green : Color.red);

            if (rb.velocity.y <= 0.01f)
            {
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, colliderHeight/2 + 0.1f,groundLayer);
                return hit.collider != null;

            }
            return false;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Attack()
        {
            rb.velocity = Vector2.zero;
            if(_isAttacking) return;
            _isAttacking = true;
            ChangeAnim("attack");
            //reset attack
            Invoke(nameof(ResetAttack), 0.5f);
        }
          
        private void ResetAttack()
        {
            _isAttacking = false;
            ChangeAnim("idle");
        }

        private void Throw()
        {
            ChangeAnim("throw");
        }

        private void Jump()
        {
            ChangeAnim("jump");
            rb.AddForce(jumpForce * Vector2.up);
            _isJumping = false;
        }

        private void ChangeAnim(string animName)
        {
            if (_currentAnimName == animName) return;
            animator.ResetTrigger(animName);
            _currentAnimName = animName;
            animator.SetTrigger(_currentAnimName);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Coin"))
            {
                _coinAmount++;
                Destroy(collision.gameObject);
            }

            if (collision.CompareTag("DeathZone"))
            {
                _isDead = true;
                ChangeAnim("die");
                
                Invoke(nameof(OnInit), 1f);
            }
        }


        public void SetSavePoint(Vector3 savePoint)
        {
            _savePoint = savePoint;
        }
    }
}
