using System;
using _Game.Scripts.StateMachine.PlayerSM;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.StateMachine
{
    public class Blackboard : MonoBehaviour
    {
        public Animator animator;
        public Rigidbody2D rigidbody2D;
        public Transform transform;
        public Collider2D collider2D;
        public GameObject attackArea;

        public virtual void InitializeStates<T>(StateMachine<T> stateMachine) where T : Blackboard
        {
        }

        protected virtual void Awake()
        {
            attackArea.SetActive(false);
        }
    }
}