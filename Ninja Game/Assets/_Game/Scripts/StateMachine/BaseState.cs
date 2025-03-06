using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class BaseState<TBlackboard> where TBlackboard : Blackboard
    {
        #region VARIABLES
        
        protected readonly string animationName;
        protected bool isExitingState;
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
            BlackBoard.animator.ResetTrigger(animationName);
        }

        public virtual UpdateStateResult StateUpdate()
        {
            return UpdateStateResult.Running;
        }
        
        public virtual UpdateStateResult StateFixedUpdate()
        {
            return UpdateStateResult.Running;
        }

        protected bool IsAnimationFinished()
        {
            AnimatorStateInfo stateInfo = BlackBoard.animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.normalizedTime >= 1f;
        }
        
        public virtual void AnimationTrigger()
        {
        }

    }

    public enum UpdateStateResult
    { 
        HasChangedState = 0,
        Running = 1,
    }
}