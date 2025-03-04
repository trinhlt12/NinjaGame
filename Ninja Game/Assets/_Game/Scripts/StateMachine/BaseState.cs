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
        protected readonly TBlackboard BlackBoard;
        protected readonly StateMachine<TBlackboard> stateMachine;
        
        #endregion

        public BaseState(StateMachine<TBlackboard> stateMachine, TBlackboard blackBoard, string animationName)
        {
            this.stateMachine = stateMachine;
            this.BlackBoard = blackBoard;
            this.animationName = animationName;
        }
        
        
        public virtual void Enter()
        {
            isAnimationFinished = false;
            isExitingState = false;
            startTime = Time.time;

            if (!BlackBoard.animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            {
                BlackBoard.animator.SetTrigger(animationName);
            }
        }

        public virtual void Exit()
        {
            isExitingState = true;
            if(!isAnimationFinished) isAnimationFinished = true;
            BlackBoard.animator.ResetTrigger(animationName);
        }

        public virtual void StateUpdate()
        {
            TransitionChecks();
        }
        
        public virtual void StateFixedUpdate()
        {
            
        }

        private void TransitionChecks()
        {
            
        }
        
        public virtual void AnimationTrigger()
        {
            isAnimationFinished = true;
        }
    }
}