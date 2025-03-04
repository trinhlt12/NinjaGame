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
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            if (BlackBoard.isGrounded)
            {
                stateMachine.ChangeState(new PlayerIdleState(stateMachine, BlackBoard, "idle"));
            }
        }
    }
}