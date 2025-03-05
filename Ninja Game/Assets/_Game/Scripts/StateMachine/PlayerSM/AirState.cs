namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class AirState : PlayerState
    {
        public AirState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }
    }
}