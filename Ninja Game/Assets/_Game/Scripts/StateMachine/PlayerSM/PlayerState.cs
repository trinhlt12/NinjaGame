using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerState : BaseState<PlayerBlackboard>
    {
        private float _lastAttackTime;
        protected float ElapsedTime;
        public PlayerState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            ElapsedTime = 0f; //Reset the elapsed time
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override UpdateStateResult StateUpdate()
        {
            base.StateUpdate();
            
            ElapsedTime += Time.deltaTime;
            
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