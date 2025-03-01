using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class EnemyPatrolState : EnemyState
    {
        #region VARIABLES

        private float _randomTime;
        private float _timer;
        
        #endregion
        
        #region INHERITED METHODS

        public EnemyPatrolState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackboard, string animationName) : base(stateMachine, blackboard, animationName)
        {
            
        }

        public void OnEnter(Enemy enemy, IAnimationHandler animationHandler)
        {
            _randomTime = Random.Range(2.5f, 4f);
            enemy.StopMoving();
            _timer = 0;
        }
        

        public void OnExecute(Enemy enemy)
        {
            _timer += Time.deltaTime;

            //if the player is within the enemy's sight
            if (enemy.Target != null)
            {
                if (enemy.IsTargetInRange())
                {
                    stateMachine.ChangeState(new AttackState(stateMachine, blackboard, "Attack"));
                }
                
                enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
                enemy.Moving();
            }
            else
            {
                //if the player is not within the enemy's sight
                if (_timer < _randomTime)
                {
                    enemy.Moving();
                }
                else
                {
                    stateMachine.ChangeState(new EnemyIdleState(stateMachine,blackboard, "Idle"));
                }
            }
        }

        public void OnExit(Enemy enemy)
        {
            
        }

        #endregion
        
    }
}