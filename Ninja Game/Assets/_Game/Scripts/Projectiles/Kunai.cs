using System;
using _Game.Scripts.StateMachine.PlayerSM;
using Unity.VisualScripting;
using UnityEngine;
using Update = UnityEngine.PlayerLoop.Update;

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
            //If the projectile travels more than max distance, return to the pool
            if (Vector3.Distance(_spawnPosition, transform.position) > maxDistance)
            {
                ReturnToPool();
            }
        }

        private void FixedUpdate()
        {
            Vector3 newPosition = transform.position + _direction * speed * Time.deltaTime;
            _rigidbody.MovePosition(newPosition);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Character>().OnHit(30f);
                ReturnToPool();
            }
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction.normalized;
        }
    }
}