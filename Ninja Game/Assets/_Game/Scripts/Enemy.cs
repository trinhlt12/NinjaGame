using System;
using _Game.Scripts.StateMachine;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts
{
    public class Enemy : Character
    {
        #region VARIABLES
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private EnemyBlackboard enemyBB;

        public float attackRange;
        
        private bool _isRight = true;
        private StateMachine<EnemyBlackboard> _enemyStateMachine;
        
        #endregion
        
        #region UNITY CALLBACKS

        private void Update()
        {
            _enemyStateMachine.CurrentState.StateUpdate();
        }
        
        private void FixedUpdate()
        {
            _enemyStateMachine.CurrentState.StateFixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("EnemyWall"))
            {
                /*
                ChangeState(new EnemyIdleState());
                */
                ChangeDirection(!_isRight);
            }
        }

        #endregion
        
        #region INHERITED FUNCTIONS

        public override void OnInit()
        {
            base.OnInit();

            _enemyStateMachine = new StateMachine<EnemyBlackboard>();
            _enemyStateMachine.InitializeStateMachine(new EnemyIdleState(_enemyStateMachine, enemyBB, "idle"));
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

        /*public void Moving()
        {
            ChangeAnim("run");
            
            rb.velocity = transform.right * moveSpeed;
        }*/

        /*public void StopMoving()
        {
            ChangeAnim("idle");
            rb.velocity = Vector2.zero;
        }*/

        public void ChangeDirection(bool isRight)
        {
            this._isRight = isRight;
            transform.rotation = isRight ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
        }
        
        public bool IsTargetInRange()
        {
            if (enemyBB.Target == null) return false;
            return Vector2.Distance(enemyBB.Target.transform.position, this.transform.position) < attackRange;
        }
        
        internal void SetTarget(Character target)
        {
            enemyBB.Target = target;
            if (IsTargetInRange())
            {
                enemyBB.isTargetInAttackRange = true;
            }else if(enemyBB.Target != null)
            {
                enemyBB.isTargetInAttackRange = false;
            }
        }
        
        #endregion

        public void PlayAnimation(string animationName)
        {
            
            
        }
    }
}
