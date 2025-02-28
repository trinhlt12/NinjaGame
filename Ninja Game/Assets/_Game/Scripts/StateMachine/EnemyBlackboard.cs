using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class EnemyBlackboard : Blackboard
    {
        public float attackRange;
        public float moveSpeed;
        public  Rigidbody2D rb;
        
        public IState _currentState;
        public bool _isRight = true;
        public Character _target;

        public Character Target => _target;
    }
}