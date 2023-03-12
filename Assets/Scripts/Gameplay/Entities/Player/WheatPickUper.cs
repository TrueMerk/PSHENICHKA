using System;
using System.Collections;
using SarrrGames.GoldenRush.Gameplay.Entities.Grows;
using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Player
{
    public class WheatPickUper : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Bunch _bunch;

        public Action WheatInBox;
        
        private void OnTriggerEnter(Collider other)
        {
            var wheat = other.GetComponent<BlockOfGrow>();
        
            if (wheat != null && _bunch._block.Count<7)
            {
                var o = other.gameObject;
                wheat.SetShotDestination(_bunch._blocsTower[5].transform);
                _bunch.SetPosForBlocks(wheat);
                WheatInBox?.Invoke();
            }
        }

        
        
    }
}