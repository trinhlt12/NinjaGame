using UnityEngine;

namespace _Game.Scripts.StateMachine.PlayerSM
{
    public class PlayerBlackboard : Blackboard
    {
        public Player player;
        public LayerMask groundLayer;
        public float speed;
        public float jumpForce;
        public CapsuleCollider2D playerCollider;        
        public IMovingPlatform currentMovingPlatform;
        public float horizontal;
        public bool isFacingRight;
        public bool isGrounded;
        public bool isDead;
        
        public PlayerBlackboard(Player player)
        {
            this.player = player;
            this.rigidbody2D = player.GetComponent<Rigidbody2D>();
            this.animator = player.GetComponent<Animator>();
        }
    }
}