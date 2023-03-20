using System;
using SarrrGames.GoldenRush.Gameplay.Entities.Grows;
using UnityEngine;


namespace SarrrGames.GoldenRush.Gameplay.Entities.Player
{
    public class WheatPickUper : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Bunch.Bunch _bunch;

        
        private void OnTriggerEnter(Collider other)
        {
            var wheat = other.GetComponent<BlockOfGrow>();
            if (wheat != null && _bunch.Blocks.Count<40)
            {
                _bunch.Blocks.Add(wheat);
                wheat.SetShotDestination(_bunch.transform, _bunch,false);
            }
        }

        
        
    }
}