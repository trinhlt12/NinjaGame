using System;
using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class StateMachine<T>  where T : Blackboard
    {
        public BaseState<T> CurrentState { get; set; }

        public void InitializeStateMachine(BaseState<T> initialState, T blackboard)
        {
            if (initialState == null) throw new ArgumentNullException(nameof(initialState));
            if (blackboard == null) throw new ArgumentNullException(nameof(blackboard));

            CurrentState = initialState;
            blackboard.InitializeStates(this);
            CurrentState.Enter();
        }
        
        public void ChangeState(BaseState<T> newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}