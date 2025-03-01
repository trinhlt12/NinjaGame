using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class AttackState: EnemyState
    {
        #region VARIABLES

        private float _timer;

        #endregion
        
        #region INHERITED METHODS

        public AttackState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackboard, string animationName) : base(stateMachine, blackboard, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _timer = 0;
            if(blackboard.enemy.Target != null)
            {
                //rotate enemy to face the player
                blackboard.enemy.ChangeDirection(blackboard.enemy.Target.transform.position.x > blackboard.enemy.transform.position.x);
                blackboard.enemy.StopMoving();
                blackboard.enemy.Attack();
            }
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;
            if (_timer >= 1.5f)
            {
                stateMachine.ChangeState(new EnemyPatrolState(stateMachine, blackboard, "Patrol"));
            }
        }

        public void OnExit(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        
    }
}