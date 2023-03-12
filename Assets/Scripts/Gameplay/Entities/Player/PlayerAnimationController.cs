using System.Collections.Generic;
using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _runningAnimationName = "Running";
        [SerializeField] private string _idleAnimationName = "Angry";
        [SerializeField] private string _attackAnimation = "Harvesting";
        [SerializeField] private bool _hasAttackAnimation;
        
        private AnimatorState _animatorState = AnimatorState.Idle;
    
        public void PlayAttackAnimation()
        {
            if (_animatorState == AnimatorState.Attack || !_hasAttackAnimation)
            {
                return;
            }
            _animator.Play(_attackAnimation);
            _animatorState = AnimatorState.Attack;
        }

        public void PlayIdleAnimation()
        {
            if (_animatorState == AnimatorState.Idle)
            {
                return;
            }
            _animator.Play(_idleAnimationName);
            _animatorState = AnimatorState.Idle;
        }

        public void PlayRunningAnimation()
        {
            if (_animatorState == AnimatorState.Running)
            {
                return;
            }
            
            _animator.Play(_runningAnimationName);
            _animatorState = AnimatorState.Running;
        }
   
        private enum AnimatorState
        {
            Attack,
            Running,
            Idle
        }
    }
}
