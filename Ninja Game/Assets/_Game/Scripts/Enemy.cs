using System;
using _Game.Scripts.StateMachine;
using Unity.VisualScripting;
using UnityEngine;
using IState = _Game.Scripts.StateMachine.IState;

namespace _Game.Scripts
{
    public class Enemy : Character
    {
        #region VARIABLES
        [SerializeField] private float attackRange;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Rigidbody2D rb;
        
        private IState _currentState;
        private bool _isRight = true;
        private Character _target;

        public Character Target => _target;

        #endregion
        
        #region UNITY CALLBACKS

        private void Update()
        {
            _currentState?.OnExecute(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("EnemyWall"))
            {
                ChangeState(new IdleState());
                ChangeDirection(!_isRight);
            }
        }

        #endregion
        
        #region INHERITED FUNCTIONS
        
        public override void OnInit()
        {
            base.OnInit();
            ChangeState(new IdleState());
        }

        protected override void OnDespawn()
        {
            base.OnDespawn();
        }
        
        protected override void ChangeAnim(string animName)
        {
            base.ChangeAnim(animName);
        }

        protected override void OnDeath()
        {
            base.OnDeath();
        }

        #endregion

        #region CUSTOM FUNCTIONS
        
        //Movements

        public void Moving()
        {
            ChangeAnim("run");
            
            rb.velocity = transform.right * moveSpeed;
        }

        public void StopMoving()
        {
            ChangeAnim("idle");
            rb.velocity = Vector2.zero;
        }

        public void ChangeDirection(bool isRight)
        {
            this._isRight = isRight;
            transform.rotation = isRight ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
        }
        
        //Actions
        
        public void Attack()
        {
            
        }

        public bool IsTargetInRange()
        {
            if (_target == null) return false;
            return Vector2.Distance(_target.transform.position, this.transform.position) < attackRange;
        }
        
        internal void SetTarget(Character target)
        {
            this._target = target;
            if (IsTargetInRange())
            {
                ChangeState(new AttackState());
            }else if(_target != null)
            {
                ChangeState(new PatrolState());
            }
            else
            {
                ChangeState(new IdleState());
            }
        }
        
        #endregion
        

        public void ChangeState(IState newState)
        {
            _currentState?.OnExit(this);
            _currentState = newState;
            _currentState.OnEnter(this);
        }
        
    }
}
