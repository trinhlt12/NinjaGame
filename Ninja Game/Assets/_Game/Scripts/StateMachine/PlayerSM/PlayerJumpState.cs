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
            base.StateFixedUpdate();
            
            BlackBoard.horizontal = Input.GetAxisRaw("Horizontal");
            
            if (BlackBoard.horizontal != 0)
            {
                BlackBoard.isFacingRight = BlackBoard.horizontal > 0;
                BlackBoard.player.transform.localScale = new Vector3(BlackBoard.isFacingRight ? 1 : -1, 1, 1);

                BlackBoard.rigidbody2D.AddForce(Vector2.right * (BlackBoard.airSpeed * BlackBoard.horizontal), ForceMode2D.Force);
            }

            return UpdateStateResult.Running;
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