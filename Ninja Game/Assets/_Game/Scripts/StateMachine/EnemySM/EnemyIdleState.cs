using System;
using _Game.Scripts.StateMachine.EnemySM;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.StateMachine
{
    public class EnemyIdleState : EnemyState
    {
        #region VARIABLES

        private float _timer;
        private float _randomTime;
        
        #endregion
        
        #region INHERITED METHODS
        
        public EnemyIdleState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackBoard, string animationName) : base(stateMachine, blackBoard, animationName)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            _timer = 0;
            _randomTime = Random.Range(2.5f, 4f);
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
        }

        public override UpdateStateResult StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;
            if(_timer > _randomTime)
            {
                stateMachine.ChangeState(BlackBoard.enemyRunState);
                return UpdateStateResult.HasChangedState;
            }

            if (BlackBoard.enemy.IsTargetInRange() && !BlackBoard.isAttacking)
            {
                stateMachine.ChangeState(BlackBoard.enemyAttackState);
                return UpdateStateResult.HasChangedState;
            }

            return UpdateStateResult.Running;
        }
        
        public override UpdateStateResult StateFixedUpdate()
        {
            return base.StateFixedUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        #endregion
        
    }
}