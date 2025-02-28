using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class BaseState<TBlackboard> where TBlackboard : Blackboard
    {
        #region VARIABLES
        
        protected readonly string animationName;
        protected bool isExitingState;
        protected bool isAnimationFinished;
        protected float startTime;
        protected readonly TBlackboard blackboard;
        
        #endregion

        public BaseState(TBlackboard blackboard, string animationName)
        {
            this.blackboard = blackboard;
            this.animationName = animationName;
        }
        
        
        public virtual void Enter()
        {
            isAnimationFinished = false;
            isExitingState = false;
            startTime = Time.time;
            blackboard.animator.SetTrigger(animationName);
        }

        public virtual void Exit()
        {
            isExitingState = true;
            if(!isAnimationFinished) isAnimationFinished = true;
            blackboard.animator.ResetTrigger(animationName);
        }

        public virtual void StateUpdate()
        {
            
        }
        
        public virtual void StateFixedUpdate()
        {
            
        }

        public void TransitionChecks()
        {
            
        }
        
        public virtual void AnimationTrigger()
        {
            isAnimationFinished = true;
        }
    }
}