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
            BlackBoard.isAttacking = true;
            _timer = 0;

            if(BlackBoard.Target != null)
            {
                //rotate enemy to face the player
                BlackBoard.enemy.ChangeDirection(BlackBoard.Target.transform.position.x > BlackBoard.enemy.transform.position.x);
                /*
                Attack();
            */
            }
        }

        public override UpdateStateResult StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;
            if (BlackBoard.target == null)
            {
                if (_timer >= 1.5f)
                {
                    stateMachine.ChangeState(BlackBoard.enemyRunState);
                    return UpdateStateResult.HasChangedState;
                }
            }
              
            if(IsAnimationFinished())
            {
                BlackBoard.isAttacking = false;
                stateMachine.ChangeState(BlackBoard.enemyIdleState);
                return UpdateStateResult.HasChangedState;
            }

            return UpdateStateResult.Running;
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            base.StateFixedUpdate();
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
            return UpdateStateResult.Running;
        }

        public override void Exit()
        {
            base.Exit();
            BlackBoard.attackArea.SetActive(false);
        }

        #endregion

        #region CUSTOM METHODS

        private void Attack()
        {
            BlackBoard.attackArea.SetActive(true);
        }

        #endregion
    }
}