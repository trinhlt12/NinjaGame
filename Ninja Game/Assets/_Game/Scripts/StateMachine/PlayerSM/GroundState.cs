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

        public override UpdateStateResult StateUpdate()
        {
            base.StateUpdate();
            if(BlackBoard.isGrounded || !BlackBoard.isAttacking)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    stateMachine.ChangeState(BlackBoard.playerJumpState);
                    return UpdateStateResult.HasChangedState;
                }

                if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J))
                {
                    stateMachine.ChangeState(BlackBoard.playerAttackState);
                    return UpdateStateResult.HasChangedState;
                }

                BlackBoard.horizontal = Input.GetAxisRaw("Horizontal");
                if (Mathf.Abs(BlackBoard.horizontal) > 0.1f && stateMachine.CurrentState is not PlayerRunState
                    && stateMachine.CurrentState is not PlayerJumpState)
                {
                    stateMachine.ChangeState(BlackBoard.playerRunState);
                    return UpdateStateResult.HasChangedState;
                }
            }

            return UpdateStateResult.Running;
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            return base.StateFixedUpdate();
        }
    }
}