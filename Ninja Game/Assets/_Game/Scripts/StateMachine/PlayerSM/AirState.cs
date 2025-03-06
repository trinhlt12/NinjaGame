using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class AirState : PlayerState
    {
        public AirState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            BlackBoard.rigidbody2D.gravityScale = 1.5f;
        }

        public override UpdateStateResult StateUpdate()
        {
            return base.StateUpdate();
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            base.StateFixedUpdate();

            if (BlackBoard.rigidbody2D.velocity.y <= 0f && BlackBoard.isGrounded)
            {
                stateMachine.ChangeState(BlackBoard.playerIdleState);
                return UpdateStateResult.HasChangedState;
            }
            
            
            float maxAirSpeed = 15f;
            BlackBoard.rigidbody2D.velocity = new Vector2(Mathf.Clamp(BlackBoard.rigidbody2D.velocity.x, -maxAirSpeed, maxAirSpeed), BlackBoard.rigidbody2D.velocity.y);

            BlackBoard.horizontal = Input.GetAxisRaw("Horizontal");
            
            BlackBoard.isFacingRight = BlackBoard.horizontal > 0;
            BlackBoard.player.transform.localScale = new Vector3(BlackBoard.isFacingRight ? 1 : -1, 1, 1);

            BlackBoard.rigidbody2D.AddForce(Vector2.right * (BlackBoard.airSpeed * BlackBoard.horizontal), ForceMode2D.Force);
            
            return UpdateStateResult.Running;
        }

        public override void Exit()
        {
            base.Exit();
            BlackBoard.rigidbody2D.gravityScale = 1;
        }
    }
}