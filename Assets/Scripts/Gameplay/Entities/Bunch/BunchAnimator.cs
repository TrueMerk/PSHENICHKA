using System;
using System.Collections;
using DG.Tweening;
using SarrrGames.GoldenRush.Gameplay.Entities.Player;
using UnityEngine;
using Zenject;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Bunch
{
    public class BunchAnimator : MonoBehaviour
    {
        private PlayerUnit _player;
        private PlayerAnimationController _playerAnimation;
        private bool _isAnimated = false;
        public int loop = 0;

        [Inject]
        public void Construct(PlayerUnit player)
        {
            _player = player;
            _playerAnimation = _player.gameObject.GetComponent<PlayerAnimationController>();
        }

      
        public void StopAnimation()
        {
            DOTween.PauseAll();
        }
        public void AnimateBench()
        {
            if (!_isAnimated)
            {
                loop = -1;
                DOTween.Sequence()
                    .Append(transform.DORotate(new Vector3(0, 0, 8), 0.5f))
                    .AppendInterval(0.5f)
                    .Append(transform.DORotate(new Vector3(0, 0, 0), 0.5f))
                    .AppendInterval(0.5f)
                    .Append(transform.DORotate(new Vector3(0, 0, -8), 0.5f))
                    .AppendInterval(0.5f)
                    .Append(transform.DORotate(new Vector3(0, 0, 0), 0.5f))
                    .SetLoops(loop);
            }
            
        }
        
    }
}
