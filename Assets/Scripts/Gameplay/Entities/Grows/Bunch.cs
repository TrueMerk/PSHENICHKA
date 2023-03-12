using System;
using System.Collections.Generic;
using SarrrGames.GoldenRush.Gameplay.Entities.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Grows
{
    public class Bunch : MonoBehaviour
    {
        [SerializeField] private WheatPickUper _wheatPickUper;

        [SerializeField] private Transform _startPos;
        [SerializeField] private Transform _nextTransform;
        [SerializeField] public List<Transform> _blocsTower;
        public List<BlockOfGrow> _block = new List<BlockOfGrow>();
        private int count;


        private void Start()
        {
            _nextTransform.position = _startPos.position;
            count = 0;

            foreach (var BlockOfGrow in _block)
            {
                BlockOfGrow.BlockDeadAction += RemoveFromList;
            }
        }

        private void RemoveFromList()
        {
            _block.Clear();
        }


        public void SetPosForBlocks(BlockOfGrow wheat)
        {
            _block.Add(wheat);
            wheat.BlockDeadAction += RemoveFromList;
            wheat.transform.SetParent(_blocsTower[count].transform);
            wheat.transform.position = wheat.transform.parent.position;
            
            if (count<7)
            {
                count++;
            }
            
        }
    }
}
