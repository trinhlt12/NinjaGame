using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class EnemyAttackState: EnemyState
    {
        #region VARIABLES

        private float _timer;

        #endregion
        
        #region INHERITED METHODS

        public EnemyAttackState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard enemyBb, string animationName) : base(stateMachine, enemyBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _timer = 0;

            if(EnemyBb.Target != null)
            {
                //rotate enemy to face the player
                EnemyBb.enemy.ChangeDirection(EnemyBb.Target.transform.position.x > EnemyBb.enemy.transform.position.x);
                EnemyBb.rigidbody2D.velocity = Vector2.zero;
                Attack();
            }
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;
            if (_timer >= 1.5f)
            {
                stateMachine.ChangeState(new EnemyRunState(stateMachine, EnemyBb, "run"));
            }
            
            if(EnemyBb.animator.GetCurrentAnimatorStateInfo(0).IsName("attack") && EnemyBb.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                stateMachine.ChangeState(new EnemyIdleState(stateMachine, EnemyBb, "idle"));
            }
        }

        public void OnExit(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region CUSTOM METHODS

        private void Attack()
        {
            
        }

        #endregion
    }
}