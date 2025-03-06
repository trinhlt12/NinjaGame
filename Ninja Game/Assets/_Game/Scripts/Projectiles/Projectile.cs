using UnityEngine;

namespace _Game.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 5f;
        public float maxDistance = 20f;
        
        protected Vector3 _spawnPosition;
        protected System.Action _returnToPool;
        public void Initialize(System.Action returnToPool)
        {
            this._returnToPool = returnToPool;
        }

        protected void ReturnToPool()
        {
            _returnToPool?.Invoke();
        }
    }
}