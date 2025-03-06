using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerAttackState : GroundState
    {
        public PlayerAttackState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            BlackBoard.isAttacking = true;
            
            Attack();
        }

        public override UpdateStateResult StateUpdate()
        {
            base.StateUpdate();
            if (IsAnimationFinished())
            {
                BlackBoard.isAttacking = false;
                BlackBoard.canAttack = true;
                stateMachine.ChangeState(BlackBoard.playerIdleState);
                return UpdateStateResult.HasChangedState;
            }
            else
            {
                return UpdateStateResult.Running;
            }
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            base.StateFixedUpdate();
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
            return UpdateStateResult.Running;
        }

        public override void Exit()
        {
            base.Exit();
        }
        

        private void Attack()
        {
            
        }
    }
}