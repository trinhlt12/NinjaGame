using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerJumpState : GroundState
    {
        private bool _hasJumped;
        public PlayerJumpState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _hasJumped = false;
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
            if (!_hasJumped)
            {
                Jump();
                _hasJumped = true;
            }
            
            BlackBoard.horizontal = Input.GetAxisRaw("Horizontal");
            
            Debug.Log(BlackBoard.horizontal.ToString());
            
            if (BlackBoard.horizontal != 0)
            {
                /*BlackBoard.rigidbody2D.velocity = new 
                    Vector2(BlackBoard.horizontal * BlackBoard.speed, 
                        BlackBoard.rigidbody2D.velocity.y);*/

                BlackBoard.isFacingRight = BlackBoard.horizontal > 0;
                BlackBoard.player.transform.localScale = new 
                    Vector3(BlackBoard.isFacingRight ? 1 : -1, 1, 1);
            }
        }

        private void Jump()
        {
            BlackBoard.rigidbody2D.AddForce(BlackBoard.jumpForce * Vector2.up);
        }
    }
}