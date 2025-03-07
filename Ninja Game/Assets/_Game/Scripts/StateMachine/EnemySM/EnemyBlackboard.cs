using _Game.Scripts.StateMachine.EnemySM;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.StateMachine
{
    public class EnemyBlackboard : Blackboard
    {
        public GameObject EnemyGameObject;
        public Enemy enemy;
        public Character target;
        
        public float attackRange;
        public float moveSpeed;
        public float attackCooldown = 1.5f;
        private float lastAttackTime;
        
        public bool isTargetInAttackRange;
        public bool isAttacking = false;
        public bool isRight = true;
        public bool isDead;
        
        public EnemyAttackState enemyAttackState { get; private set; }
        public EnemyRunState enemyRunState { get; private set; }
        public EnemyIdleState enemyIdleState { get; private set; }
        
        public EnemyDieState enemyDieState { get; private set; }

        public Character Target
        {
            get => target;
            set => target = value;
        }

        public EnemyBlackboard(Enemy enemy)
        {
            this.enemy = enemy;
            this.rigidbody2D = enemy.GetComponent<Rigidbody2D>();
            this.animator = enemy.GetComponent<Animator>();
        }

        public override void InitializeStates<T>(StateMachine<T> stateMachine)
        {
            base.InitializeStates(stateMachine);
            if(stateMachine is StateMachine<EnemyBlackboard> enemyStateMachine)
            {
                enemyAttackState = new EnemyAttackState(enemyStateMachine, this, "attack");
                enemyRunState = new EnemyRunState(enemyStateMachine, this, "run");
                enemyIdleState = new EnemyIdleState(enemyStateMachine, this, "idle");
                enemyDieState = new EnemyDieState(enemyStateMachine, this, "die");
            }
        }
    }
}