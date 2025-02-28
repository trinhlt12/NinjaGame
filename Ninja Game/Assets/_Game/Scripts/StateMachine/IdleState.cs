using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Scripts.StateMachine
{
    public class IdleState : IState
    {
        #region VARIABLES

        private float _timer;
        private float _randomTime;
        
        #endregion
        
        #region INHERITED METHODS

        public void OnEnter(Enemy enemy)
        {
            _timer = 0;
            _randomTime = Random.Range(2.5f, 4f);
            enemy.StopMoving();
        }

        public void OnExecute(Enemy enemy)
        {
            _timer += Time.deltaTime;
            
            if (_timer > _randomTime)
            {
                enemy.ChangeState(new PatrolState());
            }
        }

        public void OnExit(Enemy enemy)
        {
        }

        #endregion
        
    }
}