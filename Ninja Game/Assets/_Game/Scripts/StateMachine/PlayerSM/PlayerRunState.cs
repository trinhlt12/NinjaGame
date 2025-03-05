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

        public override void StateUpdate()
        {
            base.StateUpdate();
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            
            BlackBoard.rigidbody2D.velocity = new Vector2(BlackBoard.horizontal * Time.fixedDeltaTime * BlackBoard.speed, 
                BlackBoard.rigidbody2D.velocity.y);
            
            BlackBoard.lastXVelocity = BlackBoard.rigidbody2D.velocity.x;
            
            if (BlackBoard.horizontal != 0)
            {
                BlackBoard.isFacingRight = BlackBoard.horizontal > 0;
            }

            BlackBoard.player.transform.localScale = new Vector3(BlackBoard.isFacingRight ? 1 : -1, 1, 1);

            
            if (Mathf.Abs(BlackBoard.horizontal) <= 0.1f)
            {
                stateMachine.ChangeState(BlackBoard.playerIdleState);
                return;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}