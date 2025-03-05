using _Game.Scripts.StateMachine.EnemySM;
using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class EnemyAttackState: EnemyState
    {
        #region VARIABLES

        private float _timer;

        #endregion
        
        #region INHERITED METHODS

        public EnemyAttackState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackBoard, string animationName) : base(stateMachine, blackBoard, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _timer = 0;

            if(BlackBoard.Target != null)
            {
                //rotate enemy to face the player
                BlackBoard.enemy.ChangeDirection(BlackBoard.Target.transform.position.x > BlackBoard.enemy.transform.position.x);
                Attack();
            }
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;
            if (BlackBoard.target == null)
            {
                if (_timer >= 1.5f)
                {
                    stateMachine.ChangeState(BlackBoard.enemyRunState);
                    return;
                }
            }
              
            if(IsAnimationFinished())
            {
                stateMachine.ChangeState(BlackBoard.enemyIdleState);
                return;
            }
            
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
        }

        #endregion

        #region CUSTOM METHODS

        private void Attack()
        {
            
        }

        #endregion
    }
}