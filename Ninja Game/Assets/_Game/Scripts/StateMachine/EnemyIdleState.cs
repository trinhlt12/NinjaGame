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
        
        public EnemyIdleState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackboard, string animationName) : base(stateMachine, blackboard, animationName)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            _timer = 0;
            _randomTime = Random.Range(2.5f, 4f);
            blackboard.enemy.StopMoving();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;
            if(_timer > _randomTime)
            {
                stateMachine.ChangeState(new EnemyPatrolState(stateMachine, blackboard, "Patrol"));
            }
        }
        
        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
        }

        /*public override void LogicUpdate()
        {
            base.LogicUpdate();
            _timer += Time.deltaTime;
            
            if (_timer > _randomTime)
            {
                blackboard.StateMachine.ChangeState(new EnemyPatrolState(blackboard, "Patrol"));
            }
        }*/

        public override void Exit()
        {
            base.Exit();
        }

        #endregion
        
    }
}