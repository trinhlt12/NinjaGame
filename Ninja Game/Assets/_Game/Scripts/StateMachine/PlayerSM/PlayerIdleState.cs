using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerIdleState : GroundState
    {

        #region VARIABLES
        
        #endregion
        
        public PlayerIdleState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        #region INHERITED_METHODS

        public override void Enter()
        {
            base.Enter();
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            base.StateFixedUpdate();
            
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
            
            BlackBoard.player.transform.localScale = new Vector3(BlackBoard.isFacingRight ? 1 : -1, 1, 1);

            return UpdateStateResult.Running;
        }

        public override void Exit()
        {
            base.Exit();
        }

        #endregion
    }
}