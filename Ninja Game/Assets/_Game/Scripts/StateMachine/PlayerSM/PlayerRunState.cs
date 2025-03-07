using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerRunState : GroundState
    {
        public PlayerRunState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
        }

        public override UpdateStateResult StateUpdate()
        {
            return base.StateUpdate();
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            var stateResult = base.StateFixedUpdate();
            
            if (stateResult == UpdateStateResult.HasChangedState)
            {
                return UpdateStateResult.HasChangedState;
            }
            
            Run();
            
            if (BlackBoard.horizontal != 0)
            {
                BlackBoard.isFacingRight = BlackBoard.horizontal > 0;
            }

            BlackBoard.player.transform.localScale = new Vector3(BlackBoard.isFacingRight ? 1 : -1, 1, 1);

            
            if (Mathf.Abs(BlackBoard.horizontal) <= 0.1f)
            {
                stateMachine.ChangeState(BlackBoard.playerIdleState);
                return UpdateStateResult.HasChangedState;
            }

            return UpdateStateResult.Running;
        }

        private void Run()
        {
            BlackBoard.rigidbody2D.velocity = new Vector2(BlackBoard.horizontal * Time.fixedDeltaTime * BlackBoard.speed, 
                BlackBoard.rigidbody2D.velocity.y);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}