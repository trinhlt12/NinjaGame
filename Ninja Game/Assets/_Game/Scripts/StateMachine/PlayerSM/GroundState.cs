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
                stateMachine.ChangeState(BlackBoard.playerJumpState);
                return;
            }

            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J))
            {
                stateMachine.ChangeState(BlackBoard.playerAttackState);
                return;
            }
            
            BlackBoard.horizontal = Input.GetAxisRaw("Horizontal");
            if (Mathf.Abs(BlackBoard.horizontal) > 0.1f && stateMachine.CurrentState is not PlayerRunState)
            {
                stateMachine.ChangeState(BlackBoard.playerRunState);
                return;
            }
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            if (!BlackBoard.isGrounded && BlackBoard.rigidbody2D.velocity.y < 0)
            {
                stateMachine.ChangeState(BlackBoard.playerFallState);
                return;
            }
        }
    }
}