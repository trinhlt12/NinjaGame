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

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            
            BlackBoard.player.transform.localScale = new Vector3(BlackBoard.isFacingRight ? 1 : -1, 1, 1);
        }

        public override void Exit()
        {
            base.Exit();
        }

        #endregion
    }
}