using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerJumpState : AirState
    {
        private bool _hasJumped;
        public PlayerJumpState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Jump();
            _hasJumped = false;
            
        }

        public override UpdateStateResult StateUpdate()
        {
            return base.StateUpdate();
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            return base.StateFixedUpdate();
            
        }

        private void Jump()
        {
            BlackBoard.rigidbody2D.AddForce(BlackBoard.jumpForce * Vector2.up, ForceMode2D.Impulse);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}