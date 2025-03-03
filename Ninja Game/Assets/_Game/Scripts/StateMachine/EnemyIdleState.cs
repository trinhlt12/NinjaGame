using System;
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
        
        public EnemyIdleState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard enemyBb, string animationName) : base(stateMachine, enemyBb, animationName)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            _timer = 0;
            _randomTime = Random.Range(2.5f, 4f);
            EnemyBb.rigidbody2D.velocity = Vector2.zero;
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;
            if(_timer > _randomTime)
            {
                stateMachine.ChangeState(new EnemyRunState(stateMachine, EnemyBb, "run"));
            }
        }
        
        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        #endregion
        
    }
}