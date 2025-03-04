using UnityEditor.Timeline.Actions;

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
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            //TODO: Check normalized time of die animation
            // or count 1 second and then change state (?)
            // spawn to save point
            // split logic in player's script
            
        }

        public override void StateFixedUpdate()
        {
            base.StateFixedUpdate();
        }
        
        public override void Exit()
        {
            base.Exit();
        }
    }
}