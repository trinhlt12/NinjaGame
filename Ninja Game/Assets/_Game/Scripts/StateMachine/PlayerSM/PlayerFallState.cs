namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerFallState : PlayerState
    {
        public PlayerFallState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            BlackBoard.rigidbody2D.gravityScale = 2.5f;
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            if (BlackBoard.isGrounded)
            {
                stateMachine.ChangeState(BlackBoard.playerIdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            BlackBoard.rigidbody2D.gravityScale = 1;
        }
    }
}