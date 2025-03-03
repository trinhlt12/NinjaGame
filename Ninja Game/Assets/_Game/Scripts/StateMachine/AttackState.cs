using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class AttackState: EnemyState
    {
        #region VARIABLES

        private float _timer;

        #endregion
        
        #region INHERITED METHODS

        public AttackState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard enemyBb, string animationName) : base(stateMachine, enemyBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _timer = 0;
            if(EnemyBb.enemy.Target != null)
            {
                //rotate enemy to face the player
                EnemyBb.enemy.ChangeDirection(EnemyBb.enemy.Target.transform.position.x > EnemyBb.enemy.transform.position.x);
                EnemyBb.rigidbody2D.velocity = Vector2.zero;
                EnemyBb.enemy.Attack();
            }
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;
            if (_timer >= 1.5f)
            {
                stateMachine.ChangeState(new EnemyRunState(stateMachine, EnemyBb, "Patrol"));
            }
        }

        public void OnExit(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        
    }
}