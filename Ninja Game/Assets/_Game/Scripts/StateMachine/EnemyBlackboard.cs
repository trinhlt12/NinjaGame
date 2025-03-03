using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.StateMachine
{
    public class EnemyBlackboard : Blackboard
    {
        public float attackRange;
        public float moveSpeed;
        [FormerlySerializedAs("_isRight")] public bool isRight = true;
        [FormerlySerializedAs("_target")] public Character target;

        public Character Target => target;
        public EnemyBlackboard(Enemy enemy)
        {
            this.enemy = enemy;
            this.rigidbody2D = enemy.GetComponent<Rigidbody2D>();
            this.animator = enemy.GetComponent<Animator>();
        }
    }
}