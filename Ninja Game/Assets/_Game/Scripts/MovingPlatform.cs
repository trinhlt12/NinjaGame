using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class MovingPlatform : MonoBehaviour, IMovingPlatform
    {
        public Transform aPoint, bPoint;
        
        [SerializeField] private float speed;
        
        public Vector2 Velocity 
            => _platformVelocity;
    
        private Vector3 _target;
        private Vector3 _previousPosition;
        private Vector2 _platformVelocity;
        private Vector3 _currentPosition;
        
        
        private void Start()
        {
            transform.position = aPoint.position;
            _target = bPoint.position;
            _previousPosition = this.transform.position;
        }

        private void MovePlatform()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
            _currentPosition = this.transform.position;
            
            if(Vector2.Distance(transform.position, aPoint.position) < 0.1f)
            {
                _target = bPoint.position;
            }
            else if(Vector2.Distance(transform.position, bPoint.position) < 0.1f)
            {
                _target = aPoint.position;
            }
        }
        
        private void LateUpdate()
        {
            /*if(target == null) return;
            target.transform.position = transform.position + _offset;*/
        }

        private void FixedUpdate()
        {
            MovePlatform();
            
            var currentPosition = this.transform.position;
            _platformVelocity = (currentPosition - _previousPosition) / Time.fixedDeltaTime;
            _previousPosition = currentPosition;
            
        }

        public Vector3 Position => _currentPosition;
    }
}
