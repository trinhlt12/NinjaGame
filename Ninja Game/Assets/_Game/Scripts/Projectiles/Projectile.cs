using UnityEngine;

namespace _Game.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public float maxDistance;
        
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