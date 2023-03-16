using System.Collections;
using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Grows
{
    public class BlockMover : MonoBehaviour
    {
        [SerializeField] private float _animationTime;
        [SerializeField] private AnimationCurve _xCurve;
        [SerializeField] private AnimationCurve _yCurve;
        [SerializeField] private AnimationCurve _zCurve;
        
        private Transform _target;
        private Bunch.Bunch _bunch;
        private BlockOfGrow _wheat;
        private bool _sell;
        
        private IEnumerator MoveToTarget(bool sell)
        {
            var time = 0f;
            var d = _animationTime - Time.deltaTime;
            
            var initX = transform.position.x;
            var initY = transform.position.y;
            var initZ = transform.position.z;
            
            var xDiff = _target.position.x - transform.position.x;
            var yDiff = _target.position.y - transform.position.y;
            var zDiff = _target.position.z - transform.position.z;
            
            while (time <_animationTime)
            {
                var t = time / _animationTime;
                
                var x = xDiff * _xCurve.Evaluate(t) + initX;
                var y = yDiff * _yCurve.Evaluate(t) + initY;
                var z = zDiff * _zCurve.Evaluate(t) + initZ;

                transform.position = new Vector3(x, y, z);
               
                yield return null;
                time += Time.deltaTime;
            }

            if (!sell)
            {
                _bunch.SetPosForBlocks(_wheat);
            }
            else
            {
                _wheat.gameObject.SetActive(false);
            }
            
        }
        
        public void SetTarget(Transform target, Bunch.Bunch bunch, BlockOfGrow wheat,bool sell)
        {
            _target = target;
            _bunch = bunch;
            _wheat = wheat;
            StartCoroutine(MoveToTarget(sell));
        }
    }
}
