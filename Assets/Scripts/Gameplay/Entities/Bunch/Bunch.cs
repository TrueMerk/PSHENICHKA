using System.Collections.Generic;
using SarrrGames.GoldenRush.Gameplay.Entities.Grows;
using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Bunch
{
    public class Bunch : MonoBehaviour
    {
        [SerializeField] private Transform _startPos;
        [SerializeField] private List<BlockOfGrow> _blocksTower = new List<BlockOfGrow>();
        
         public List<BlockOfGrow> Blocks;
         
        public void SetPosForBlocks(BlockOfGrow wheat)
        {
            Blocks.Add(wheat);
            wheat.transform.SetParent(_startPos);
            wheat.DisableObjectForPool();
            if (Blocks.Count<10)
            {
                _blocksTower[0].gameObject.SetActive(true);
            }
            
            else if (Blocks.Count<20)
            {
                _blocksTower[1].gameObject.SetActive(true);
            }
            
            else
            {
                _blocksTower[2].gameObject.SetActive(true);
            }
        }

        public void SellBlocs(Transform transform)
        {
            foreach (var BlockOfGrow in Blocks)
            {
                BlockOfGrow.EnableObjectForPool();
                BlockOfGrow.SetShotDestination(transform, this,true);
                BlockOfGrow.transform.SetParent(null);
                BlockOfGrow.OnBlockLifeEnd();
            }
            
            Blocks.Clear();
            
            foreach (var block in _blocksTower)
            {
                block.gameObject.SetActive(false); 
            }
        }
    }
}
