using System;
using SarrrGames.GoldenRush.Gameplay.Entities.Token;
using UnityEngine;
using Zenject;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Grows
{
    public class BlockOfGrow : MonoBehaviour
    {
         [SerializeField] private BlockMover _blockMover;
         [SerializeField] private MeshRenderer _meshRenderer;
         [SerializeField] private BoxCollider _colider;
         
         private TokenProgressModel _token;
         public Action BlockDeadAction;
         public int countMoneyUnBlock;

         
         [Inject]
         public void Construct(TokenProgressModel token)
         {
             _token = token;
         }
         
        private void OnTriggerEnter(Collider other)
        {
            var ambar = other.GetComponent<Ambar>();
            if (ambar != null)
            {
                OnBlockLifeEnd();
                ambar.GetComponent<TokenPool>().CreateToken(ambar.transform);
            }
        }

        private void OnDisable()
        {
            _colider.enabled = true;
        }

        public void OnBlockLifeEnd()
        {
            gameObject.transform.SetParent(null);
            BlockDeadAction?.Invoke();
            _token.Soft.SetValue(_token.Soft.GetValue()+15);
        }
        
        public void SetShotDestination(Transform shotDestination, Bunch.Bunch bunch, bool sell)
        {
            _blockMover.SetTarget(shotDestination,bunch,this,sell);
        }

        public void DisableObjectForPool()
        {
            _meshRenderer.enabled = false;
            _colider.enabled = false;
        }

        public void EnableObjectForPool()
        {
            _meshRenderer.enabled = true;
        }
        
        
    }
}
