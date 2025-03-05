using System;
using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class StateMachine<T>  where T : Blackboard
    {
        public BaseState<T> CurrentState { get; set; }
        public BaseState<T> PreviousState { get; set; }

        public void InitializeStateMachine(BaseState<T> initialState, T blackboard)
        {
            if (initialState == null) throw new ArgumentNullException(nameof(initialState));
            if (blackboard == null) throw new ArgumentNullException(nameof(blackboard));

            blackboard.InitializeStates(this);
            CurrentState = initialState;
            PreviousState = null;
            CurrentState.Enter();
        }
        
        public void ChangeState(BaseState<T> newState)
        {
            if (newState == null)
            {
                Debug.LogError("New state is null");
                return;
            };

            if (CurrentState != null)
            {
                PreviousState = CurrentState;
                CurrentState.Exit();
            }
            
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void RevertToPreviousState()
        {
            if(PreviousState != null)
            {
                ChangeState(PreviousState);
            }
            else
            {
                Debug.LogWarning("No previous state");
            }
        }
    }
}