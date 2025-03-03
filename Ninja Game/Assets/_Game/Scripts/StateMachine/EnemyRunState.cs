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

        public EnemyRunState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard enemyBb, string animationName) : base(stateMachine, enemyBb, animationName)
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
            if (EnemyBb.Target != null)
            {
                if (EnemyBb.enemy.IsTargetInRange())
                {
                    stateMachine.ChangeState(new AttackState(stateMachine, EnemyBb, "attack"));
                }
                
                EnemyBb.enemy.ChangeDirection(EnemyBb.Target.transform.position.x > EnemyBb.transform.position.x);
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
                    stateMachine.ChangeState(new EnemyIdleState(stateMachine,EnemyBb, "idle"));
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
            EnemyBb.rigidbody2D.velocity = EnemyBb.enemy.transform.right * moveSpeed;
        }
        
        private void StopMove()
        {
            EnemyBb.rigidbody2D.velocity = Vector2.zero;
        }
        
        

        #endregion
        
    }
}