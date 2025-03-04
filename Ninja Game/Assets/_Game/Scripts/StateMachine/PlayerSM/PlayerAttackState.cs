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
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
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
    }
}