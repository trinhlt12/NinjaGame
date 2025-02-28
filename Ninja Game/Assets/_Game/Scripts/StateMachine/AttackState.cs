using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class AttackState: IState
    {
        #region VARIABLES

        private float _timer;

        #endregion
        
        #region INHERITED METHODS

        public void OnEnter(Enemy enemy)
        {
            _timer = 0;
            if(enemy.Target != null)
            {
                //rotate enemy to face the player
                enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
                enemy.StopMoving();
                enemy.Attack();
            }
        }

        public void OnExecute(Enemy enemy)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1.5f)
            {
                enemy.ChangeState(new PatrolState());
            }
        }

        public void OnExit(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        
    }
}