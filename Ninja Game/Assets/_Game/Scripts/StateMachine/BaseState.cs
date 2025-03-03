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
        protected readonly TBlackboard EnemyBb;
        protected readonly StateMachine<TBlackboard> stateMachine;
        
        #endregion

        public BaseState(StateMachine<TBlackboard> stateMachine, TBlackboard enemyBb, string animationName)
        {
            this.stateMachine = stateMachine;
            this.EnemyBb = enemyBb;
            this.animationName = animationName;
        }
        
        
        public virtual void Enter()
        {
            isAnimationFinished = false;
            isExitingState = false;
            startTime = Time.time;
            EnemyBb.animator.SetTrigger(animationName);
        }

        public virtual void Exit()
        {
            isExitingState = true;
            if(!isAnimationFinished) isAnimationFinished = true;
            EnemyBb.animator.ResetTrigger(animationName);
        }

        public virtual void StateUpdate()
        {
            TransitionChecks();
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