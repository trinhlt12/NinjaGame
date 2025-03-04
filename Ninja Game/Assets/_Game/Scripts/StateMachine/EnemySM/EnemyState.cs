using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class EnemyState : BaseState<EnemyBlackboard>
    {
        public EnemyState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard enemyBB, string animationName) : base(stateMachine, enemyBB, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }
        
        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();
        }
    }
}