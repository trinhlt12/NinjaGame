using UnityEngine;

namespace _Game.Scripts.StateMachine.EnemySM
{
    public class EnemyState : BaseState<EnemyBlackboard>
    {
        protected float ElapsedTime;
        public EnemyState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackBoard, string animationName) : base(stateMachine, blackBoard, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            ElapsedTime = 0f; //Reset the elapsed time
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override UpdateStateResult StateUpdate()
        {
            base.StateUpdate();
            
            ElapsedTime += Time.deltaTime;

            if (BlackBoard.isDead && stateMachine.CurrentState != BlackBoard.enemyDieState)
            {
                stateMachine.ChangeState(BlackBoard.enemyDieState);
                return UpdateStateResult.HasChangedState;
            }
            
            if (BlackBoard.target != null && !BlackBoard.enemy.IsTargetInRange() 
                && stateMachine.CurrentState != BlackBoard.enemyRunState)
            {
                stateMachine.ChangeState(BlackBoard.enemyRunState);
                return UpdateStateResult.HasChangedState;
            }
            return UpdateStateResult.Running;
        }
        
        public override UpdateStateResult StateFixedUpdate()
        {
            return base.StateFixedUpdate();
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();
        }
    }
}