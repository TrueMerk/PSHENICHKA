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
        private AnimationComponent _animation;
        private bool _isAnimated = false;
        public int loop = 0;

        [Inject]
        public void Construct(PlayerUnit player)
        {
            _player = player;
            _animation = _player.gameObject.GetComponent<AnimationComponent>();
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
                    .Append(transform.DORotate(new Vector3(0, 0, 8), 1))
                    .AppendInterval(0.1f)
                    .Append(transform.DORotate(new Vector3(0, 0, 0), 1))
                    .AppendInterval(0.1f)
                    .Append(transform.DORotate(new Vector3(0, 0, -8), 1))
                    .AppendInterval(0.1f)
                    .Append(transform.DORotate(new Vector3(0, 0, 0), 1))
                    .SetLoops(loop);
            }
            
        }
        
    }
}
