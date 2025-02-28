using System;
using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class StateMachine<T> : MonoBehaviour where T : Blackboard
    {
        public BaseState<T> CurrentState { get; private set; }

        private void Start()
        {
            
        }

        private void Update()
        {
            CurrentState?.StateUpdate();
        }
        
        private void FixedUpdate()
        {
            CurrentState?.StateFixedUpdate();
        }

        public void InitializeStateMachine(BaseState<T> initialState)
        {
            CurrentState = initialState;
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