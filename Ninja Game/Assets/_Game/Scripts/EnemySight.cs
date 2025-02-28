using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class EnemySight : MonoBehaviour
    {
        #region VARIABLES

        public Enemy enemy;

        #endregion

        #region UNITY CALLBACKS

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                enemy.SetTarget(other.GetComponent<Character>());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                enemy.SetTarget(null);
            }
        }

        #endregion
    }
}
