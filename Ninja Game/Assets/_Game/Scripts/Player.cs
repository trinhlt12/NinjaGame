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
    
        private bool _isGrounded;
        private bool _isJumping;
        private bool _isAttacking;
        private bool _isRunning;
    
        private float _horizontal;
        private float _vertical;
    
        private string _currentAnimName;
        void Start()
        {
        
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
                _isAttacking = true;
            }
        }

        void FixedUpdate()
        {
            _isGrounded = CheckIfGrounded();

            //jump
            if (_isJumping)
            {                
                Jump();
            }
            
            if (!_isGrounded && rb.velocity.y < 0)
            {
                ChangeAnim("fall");
                _isJumping = false;
            }
            
            _horizontal = Input.GetAxisRaw("Horizontal");

            if (_isGrounded)
            {
                //change anim run
                if (Mathf.Abs(_horizontal) > 0.1f && !_isAttacking)
                {
                    ChangeAnim("run");
                }
                
                //attack
                if (_isAttacking)
                {
                    Attack();
                }
                /*//throw
                Throw();*/
                
            }
            
            //Moving
            if (Mathf.Abs(_horizontal) > 0.1f)
            {
                rb.velocity = new Vector2(_horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
                transform.rotation = Quaternion.Euler(new Vector3(0, _horizontal > 0 ? 0 : 180, 0));
            }else if (_isGrounded)
            {
                ChangeAnim("idle");
                rb.velocity = Vector2.zero;
            }
        }

        private bool CheckIfGrounded()
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.2f, _isGrounded ? Color.green : Color.red);
        
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, groundLayer);
            /*if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }*/
            return hit.collider != null;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Attack()
        {
            ChangeAnim("attack");
            //reset attack
            float attackAnimLength = animator.GetCurrentAnimatorStateInfo(0).length;
            Invoke(nameof(ResetAttack), 0.01f);
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
    }
}
