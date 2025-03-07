using _Game.Scripts.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts
{
    public class Character : MonoBehaviour
    {
        #region VARIABLES
    
        [SerializeField] private Animator animator;
        
        public float maxHp = 100;
        
        public float currentHp;
        
        private string _currentAnimName;

        #endregion


        private void Start()
        {
            OnInit();
        }

        public virtual void OnInit()
        {
            currentHp = maxHp;
        }

        protected virtual void OnDespawn()
        {
        
        }
    
        protected virtual void OnDeath()
        {
        
        }
        

        public virtual void OnHit(float damage)
        {
            currentHp -= damage;
        }
    
    }
}
