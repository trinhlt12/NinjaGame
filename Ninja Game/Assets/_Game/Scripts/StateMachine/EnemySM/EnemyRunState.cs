using _Game.Scripts.StateMachine.EnemySM;
using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class EnemyRunState : EnemyState
    {
        #region VARIABLES

        [SerializeField] private float moveSpeed = 2.5f;

        private float _randomTime;
        private float _timer;
        private bool _isRight = true;

        #endregion
        
        #region INHERITED METHODS

        public EnemyRunState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackBoard, string animationName) : base(stateMachine, blackBoard, animationName)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            _randomTime = Random.Range(2.5f, 4f);
            
            //Stop the enemy from moving
            StopMove();
            
            _timer = 0;
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            _timer += Time.deltaTime;

            //if the player is within the enemy's sight
            if (BlackBoard.Target != null)
            {
                if (BlackBoard.enemy.IsTargetInRange())
                {
                    stateMachine.ChangeState(BlackBoard.enemyAttackState);
                }
                
                BlackBoard.enemy.ChangeDirection(BlackBoard.Target.transform.position.x > BlackBoard.transform.position.x);
                Move();
            }
            else
            {
                //if the player is not within the enemy's sight
                if (_timer < _randomTime)
                {
                    Move();
                }
                else
                {
                    stateMachine.ChangeState(BlackBoard.enemyIdleState);
                }
            }
        }

        public void OnExit(Enemy enemy)
        {
        }

        #endregion

        #region CUSTOM-FUNCTIONS

        private void Move()
        {
            BlackBoard.rigidbody2D.velocity = BlackBoard.enemy.transform.right * moveSpeed;
        }
        
        private void StopMove()
        {
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
        }
        

        #endregion
        
    }
}