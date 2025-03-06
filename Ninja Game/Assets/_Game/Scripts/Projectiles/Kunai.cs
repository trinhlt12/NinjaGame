using System;
using _Game.Scripts.StateMachine.PlayerSM;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Projectiles
{
    public class Kunai : Projectile
    {
        public Rigidbody2D _rigidbody;
        private Vector3 _direction;

        private void OnEnable()
        {
            _spawnPosition = this.transform.position;
            if (_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
            _direction = this.transform.right;
        }

        private void Update()
        {
            Vector3 newPosition = transform.position + _direction * speed * Time.deltaTime;
            _rigidbody.MovePosition(newPosition);
            
            //If the projectile travels more than max distance, return to the pool
            if (Vector3.Distance(_spawnPosition, transform.position) > maxDistance)
            {
                ReturnToPool();
            }
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction.normalized;
        }
    }
}