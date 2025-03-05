namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerState : BaseState<PlayerBlackboard>
    {
        public PlayerState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override UpdateStateResult StateUpdate()
        {
            return base.StateUpdate();
        }
        
        public override UpdateStateResult StateFixedUpdate()
        {
            base.StateFixedUpdate();
            if (!BlackBoard.isGrounded && BlackBoard.rigidbody2D.velocity.y < 0)
            {
                stateMachine.ChangeState(BlackBoard.playerFallState);
                return UpdateStateResult.HasChangedState;
            }
            return UpdateStateResult.Running;
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();
        }
    }
}