using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class EnemyState : BaseState<EnemyBlackboard>
    {
        #region VARIABLES
        
        protected string animationName;
        protected bool isExitingState;
        protected bool isAnimationFinished;
        protected float startTime;
        #endregion
        

        public EnemyState(EnemyBlackboard blackboard, string animationName) : base(blackboard, animationName)
        {
            this.animationName = animationName;
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