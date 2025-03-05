namespace _Game.Scripts.StateMachine.EnemySM
{
    public class EnemyState : BaseState<EnemyBlackboard>
    {
        public EnemyState(StateMachine<EnemyBlackboard> stateMachine, EnemyBlackboard blackBoard, string animationName) : base(stateMachine, blackBoard, animationName)
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
            if (BlackBoard.target != null && !BlackBoard.enemy.IsTargetInRange())
            {
                stateMachine.ChangeState(BlackBoard.enemyRunState);
                return;
            }
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