using System;
using System.Collections;
using UnityEngine;

namespace SarrrGames.GoldenRush
{
    public class Grower : MonoBehaviour
    {
    
        [SerializeField] private float _maxTime;
        [SerializeField] private float _speed;
        [SerializeField] private float _growth;
        [SerializeField] private Wheat _wheat;
        private bool _max;

        public Action Growed;
    
        private void Start()
        {
            StartCoroutine(GroveRoutine());
            _wheat.ZeroHealth += NewGrower;
        }


        private void NewGrower()
        {
            _max = false;
            _growth = 0;
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            StopAllCoroutines();
            StartCoroutine(GroveRoutine());
        }
        
        private IEnumerator GroveRoutine()
        {
            while (!_max)
            {   
                _growth += 1;
                gameObject.transform.localScale +=
                    new Vector3(_speed * Time.deltaTime, _speed * Time.deltaTime, _speed * Time.deltaTime);
                
                if (_growth >= _maxTime)
                {
                    _max = true;
                    Growed?.Invoke();
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
