using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerState : BaseState<PlayerBlackboard>
    {
        private float _lastAttackTime;
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
            base.StateUpdate();
            
            if ((Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J)) && Time.time >= _lastAttackTime + BlackBoard.attackCooldown)
            {
                _lastAttackTime = Time.time;
                BlackBoard.canAttack = true;
            }

            return UpdateStateResult.Running;
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