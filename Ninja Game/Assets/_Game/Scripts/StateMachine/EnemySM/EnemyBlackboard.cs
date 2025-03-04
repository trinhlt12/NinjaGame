using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.StateMachine
{
    public class EnemyBlackboard : Blackboard
    {
        public float attackRange;
        public float moveSpeed;
        public bool isRight = true;
        public Character target;
        
        public bool isTargetInAttackRange;

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
    }
}