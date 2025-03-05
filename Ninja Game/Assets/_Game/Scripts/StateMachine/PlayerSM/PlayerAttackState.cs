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

        public override void StateUpdate()
        {
            base.StateUpdate();
            if (IsAnimationFinished())
            {
                BlackBoard.isAttacking = false;
                stateMachine.ChangeState(BlackBoard.playerIdleState);
                return;
            }
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
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