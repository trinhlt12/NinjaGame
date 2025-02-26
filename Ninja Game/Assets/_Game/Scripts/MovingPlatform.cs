using System;
using UnityEngine;

namespace _Game.Scripts
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform aPoint, bPoint;
        [SerializeField] private float speed;
    
        private Vector3 _target;
        private Vector3 _previousPosition;
        private Vector2 _platformVelocity;
        private GameObject target = null;
        private Vector3 _offset;
        private void Start()
        {
            transform.position = aPoint.position;
            _target = bPoint.position;
            _previousPosition = this.transform.position;
        }

        private void MovePlatform()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
            
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
            
            if(target == null) return;
            target.transform.position = transform.position + _offset;
            
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                target = collision.gameObject;
                _offset = target.transform.position - transform.position;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if(this.gameObject == null) return;
                target = null;
            }
        }

        /*private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb == null) return;
            rb.velocity += new Vector2(_platformVelocity.x, _platformVelocity.y);
        }
        
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            if(collision.transform == null) return;
            if(this.gameObject == null) return;
            collision.transform.SetParent(null);
        }*/
    }
}
