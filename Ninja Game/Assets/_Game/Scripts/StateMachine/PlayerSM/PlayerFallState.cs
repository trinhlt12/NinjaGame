// ReSharper disable All
namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerFallState : AirState
    {
        public PlayerFallState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            BlackBoard.rigidbody2D.gravityScale = 2.5f;
        }

        public override UpdateStateResult StateUpdate()
        {
            return base.StateUpdate();
            
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            base.StateFixedUpdate();
            /*if (BlackBoard.isGrounded)
            {
                stateMachine.ChangeState(BlackBoard.playerIdleState);
                return UpdateStateResult.HasChangedState;
            }*/
            return UpdateStateResult.Running;
        }

        public override void Exit()
        {
            base.Exit();
            BlackBoard.rigidbody2D.gravityScale = 1;
        }
    }
}