namespace _Game.Scripts.StateMachine
{
    public class PlayerState : BaseState<PlayerBlackboard>
    {
        public PlayerState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard blackboard, string animationName) : base(stateMachine, blackboard, animationName)
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

        public override void StateUpdate()
        {
            base.StateUpdate();
        }
        
        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();
        }
    }
}