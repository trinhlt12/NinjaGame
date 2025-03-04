using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class GroundState : PlayerState
    {
        #region VARIABLES
        
        private Vector3 _platformOffset;

        #endregion
        public GroundState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            if(!BlackBoard.isGrounded) return;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.ChangeState(new PlayerJumpState(stateMachine, BlackBoard, "jump"));
            }

            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J))
            {
                stateMachine.ChangeState(new PlayerAttackState(stateMachine, BlackBoard, "attack"));
            }
            
            BlackBoard.horizontal = Input.GetAxisRaw("Horizontal");
            if (Mathf.Abs(BlackBoard.horizontal) > 0.1f && stateMachine.CurrentState is not PlayerRunState)
            {
                stateMachine.ChangeState(new PlayerRunState(stateMachine, BlackBoard, "run"));
            }
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            if (!BlackBoard.isGrounded && BlackBoard.rigidbody2D.velocity.y < 0)
            {
                stateMachine.ChangeState(new PlayerFallState(stateMachine, BlackBoard, "fall"));
            }
        }
    }
}