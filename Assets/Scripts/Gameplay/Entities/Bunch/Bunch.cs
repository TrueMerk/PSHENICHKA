using System.Collections;
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

        public void SellBlocs(Transform transform, Ambar.Ambar ambar)
        {
            StartCoroutine(SellerCoroutine(ambar,Blocks.Count));
            foreach (var block in Blocks)
            {
                block.EnableObjectForPool();
                block.SetShotDestination(transform, this,true);
                block.transform.SetParent(null);
                block.OnBlockLifeEnd();
            }
            
            Blocks.Clear();
 
            foreach (var block in _blocksTower)
            {
                block.gameObject.SetActive(false); 
            }
            
        }

        private IEnumerator SellerCoroutine(Ambar.Ambar ambar, int count)
        {
            while (true)
            {
                for (int i = 0; i < count ; i++)
                {
                    ambar.CreateToken();
                    yield return new WaitForSeconds(0.5f);
                }
                break;
            }
            
        }
    }
}
