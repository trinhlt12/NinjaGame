using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Projectiles
{
    public class ProjectileFactoryPool<T> where T : Projectile
    {
        private Queue<T> _projectilePool = new();
        private T _projectilePrefab;
        private Transform _projectileParent;
        public ProjectileFactoryPool(T prefab, int initialSize = 10, Transform projectileParent = null)
        {
            this._projectilePrefab = prefab;
            this._projectileParent = projectileParent;

            for (int i = 0; i < initialSize; i++)
            {
                T instance = Object.Instantiate(this._projectilePrefab, this._projectileParent);
                //Reset prefab transform to 0,0,0 to prevent it from spawning in the wrong position
                instance.transform.position = Vector3.zero;
                
                instance.gameObject.SetActive(false);
                _projectilePool.Enqueue(instance);
            }
        }

        public T Spawn(Vector3 position, Quaternion rotation)
        {
            T instance;

            if (_projectilePool.Count > 0)
            {
                instance = _projectilePool.Dequeue();
            }
            else
            {
                instance = Object.Instantiate(this._projectilePrefab, _projectileParent);
            }
            
            instance.transform.SetPositionAndRotation(position, rotation);
            instance.gameObject.SetActive(true);
            instance.Initialize((() => ReturnToPool(instance)));

            return instance;
        }

        private void ReturnToPool(T instance)
        {
            instance.gameObject.SetActive(false);
            _projectilePool.Enqueue(instance);
        }
    }
}