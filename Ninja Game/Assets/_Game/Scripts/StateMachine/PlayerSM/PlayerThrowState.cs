using _Game.Scripts.Projectiles;
using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerThrowState : GroundState
    {
        public PlayerThrowState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override UpdateStateResult StateUpdate()
        {
            base.StateUpdate();
            
            ThrowKunai();
            
            if (IsAnimationFinished())
            {
                stateMachine.ChangeState(BlackBoard.playerIdleState);
                return UpdateStateResult.HasChangedState;
            }
            return UpdateStateResult.Running;
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            base.StateFixedUpdate();
            BlackBoard.rigidbody2D.velocity = Vector2.zero;
            return UpdateStateResult.Running;
        }

        private void ThrowKunai()
        {
            float direction = Mathf.Sign(BlackBoard.player.transform.localScale.x); // 1 (right) or -1 (left)
            
            Vector3 spawnPosition = BlackBoard.player.transform.position + new Vector3(direction, 0, 0);
            Quaternion spawnRotation = Quaternion.identity;
            Kunai kunai = BlackBoard.kunaiPool.Spawn(spawnPosition, spawnRotation);
            kunai.SetDirection(new Vector3(direction, 0, 0));
            
        }
    }
}