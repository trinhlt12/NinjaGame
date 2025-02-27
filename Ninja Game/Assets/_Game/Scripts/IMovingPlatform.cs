using UnityEngine;

namespace _Game.Scripts
{
    public interface IMovingPlatform
    {
        public Vector3 Position { get; }
        
        public Vector2 Velocity { get; }
    }
}