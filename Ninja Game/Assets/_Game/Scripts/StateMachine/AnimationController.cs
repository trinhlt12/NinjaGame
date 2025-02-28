using UnityEngine;

namespace _Game.Scripts.StateMachine
{
    public class AnimationController : MonoBehaviour, IAnimationHandler
    {
        [SerializeField] private Animator animator;
        
        private string _currentAnimName;
        
        public void PlayAnimation(string animationName)
        {
            if(animator == null) return;
            if(_currentAnimName == animationName) return;
            animator.ResetTrigger(animationName);
            _currentAnimName = animationName;
            animator.SetTrigger(_currentAnimName);
        }
    }
}