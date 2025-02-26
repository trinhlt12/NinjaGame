using UnityEngine;

namespace _Game.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 offset;

        private Transform _target;
        
        private void Start()
        {
            _target = FindObjectOfType<Player>().transform;
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + offset, Time.deltaTime * speed);
        }
    }
}
