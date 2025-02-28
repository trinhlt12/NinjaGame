using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class PatrolState : IState
    {
        #region VARIABLES

        private float _randomTime;
        private float _timer;
        
        #endregion
        
        #region INHERITED METHODS

        public void OnEnter(Enemy enemy)
        {
            _randomTime = Random.Range(2.5f, 4f);
            enemy.StopMoving();
            _timer = 0;
        }

        public void OnExecute(Enemy enemy)
        {
            _timer += Time.deltaTime;

            //if the player is within the enemy's sight
            if (enemy.Target != null)
            {
                enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
                enemy.Moving();
            }
            else
            {
                //if the player is not within the enemy's sight
                if (_timer < _randomTime)
                {
                    enemy.Moving();
                }
                else
                {
                    enemy.ChangeState(new IdleState());
                }
            }
        }

        public void OnExit(Enemy enemy)
        {
            
        }

        #endregion
        
    }
}