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
        
        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            BlackBoard.rigidbody2D.velocity = new Vector2(BlackBoard.horizontal * Time.fixedDeltaTime * BlackBoard.speed, 
                BlackBoard.rigidbody2D.velocity.y);
            
            if (BlackBoard.horizontal > 0)
            {
                BlackBoard.isFacingRight = true;
            }
            else if (BlackBoard.horizontal < 0)
            {
                BlackBoard.isFacingRight = false;
            }
            BlackBoard.player.transform.localScale = new Vector3(BlackBoard.isFacingRight ? 1 : -1, 1, 1);

            
            if (Mathf.Abs(BlackBoard.horizontal) <= 0.1f)
            {
                stateMachine.ChangeState(new PlayerIdleState(stateMachine, BlackBoard, "idle"));
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}