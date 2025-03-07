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
                    if (!BlackBoard.isAttacking)
                    {
                        stateMachine.ChangeState(BlackBoard.playerAttackState);
                        return UpdateStateResult.HasChangedState;
                    }
                    return UpdateStateResult.Running;

                }
                
                if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.V))
                {
                    if (!BlackBoard.isThrowing)
                    {
                        stateMachine.ChangeState(BlackBoard.playerThrowState);
                        return UpdateStateResult.HasChangedState;
                    }

                    return UpdateStateResult.Running;

                }

                BlackBoard.horizontal = Input.GetAxisRaw("Horizontal");
                if (Mathf.Abs(BlackBoard.horizontal) > 0.1f && stateMachine.CurrentState != BlackBoard.playerRunState
                    && stateMachine.CurrentState != BlackBoard.playerJumpState
                    && stateMachine.CurrentState != BlackBoard.playerAttackState
                    && stateMachine.CurrentState != BlackBoard.playerThrowState)
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