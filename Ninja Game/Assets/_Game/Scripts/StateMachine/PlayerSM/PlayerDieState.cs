using System.Collections;
using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerDieState : PlayerState
    {
        public PlayerDieState(StateMachine<PlayerBlackboard> stateMachine, PlayerBlackboard playerBb, string animationName) : base(stateMachine, playerBb, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            //disable movement
            BlackBoard.player.enabled = false;
            BlackBoard.rigidbody2D.velocity = Vector2.zero;

            BlackBoard.player.StartCoroutine(Respawn());
        }

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(1f);

            BlackBoard.player.transform.position = BlackBoard.savePoint;
            
            BlackBoard.isDead = false;
            
            BlackBoard.player.enabled = true;
            
            BlackBoard.player.currentHp = BlackBoard.player.maxHp;
            
            stateMachine.ChangeState(BlackBoard.playerIdleState);
        }

        public override UpdateStateResult StateUpdate()
        {
            return base.StateUpdate();
        }

        public override UpdateStateResult StateFixedUpdate()
        {
            return base.StateFixedUpdate();
        }
        
        public override void Exit()
        {
            base.Exit();
            //Stop coroutine
            BlackBoard.player.StopAllCoroutines();
        }
    }
}