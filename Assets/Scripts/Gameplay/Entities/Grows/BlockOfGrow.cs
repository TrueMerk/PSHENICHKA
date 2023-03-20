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
         private Bunch.Bunch _bunch;
         
         
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
            var ambar = other.GetComponent<Ambar.Ambar>();
            if (ambar != null)
            {
                OnBlockLifeEnd();
            }
        }

        private void OnDisable()
        {
            _colider.enabled = true;
            if (_bunch != null)
                _bunch.Blocks.Remove(this);
        }

        public void OnBlockLifeEnd()
        {
            gameObject.transform.SetParent(null);
            BlockDeadAction?.Invoke();
            //gameObject.SetActive(false);

        }
        
        public void SetShotDestination(Transform shotDestination, Bunch.Bunch bunch, bool sell)
        {
            _bunch = bunch;
            _blockMover.SetTarget(shotDestination,bunch,this,sell);
        }

        public void DisableObjectForPool()
        {
            _meshRenderer.enabled = false;
            _colider.enabled = false;
            _token.BloxCount.SetValue(_token.BloxCount.GetValue()+1);
        }

        public void EnableObjectForPool()
        {
            _meshRenderer.enabled = true;
        }
        
        
    }
}
