using UnityEngine;

namespace _Game.Scripts.StateMachine.EnemySM
{
    public class EnemyDieState: EnemyState
    {
        public EnemyDieState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackBoard, string animationName) : base(stateMachine, blackBoard, animationName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
        }

        public override UpdateStateResult StateUpdate()
        {
            base.StateUpdate();

            if (IsAnimationFinished())
            {
                Die();
            }

            return UpdateStateResult.HasChangedState;
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            return base.StateFixedUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void Die()
        {
            BlackBoard.EnemyGameObject.SetActive(false);
        }
    }
}