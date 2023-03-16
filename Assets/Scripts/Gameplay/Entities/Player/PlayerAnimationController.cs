using System;
using System.Collections.Generic;
using SarrrGames.GoldenRush.Gameplay.Entities.Bunch;
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
        [SerializeField] private BunchAnimator _bunchAnimator;
        
        private AnimatorState _animatorState = AnimatorState.Idle;
        
        public Action MovingAction;
        public bool IsRunnning;
    
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

            _bunchAnimator.StopAnimation();
            _animator.Play(_idleAnimationName);
            _animatorState = AnimatorState.Idle;
        }

        public void PlayRunningAnimation()
        {
            if (_animatorState == AnimatorState.Running)
            {
                return;
            }
            _bunchAnimator.enabled = true;
            _bunchAnimator.AnimateBench();
            _animator.Play(_runningAnimationName);
            _animatorState = AnimatorState.Running;
            //MovingAction?.Invoke();
        }
   
        private enum AnimatorState
        {
            Attack,
            Running,
            Idle
        }
    }
}
