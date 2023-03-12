using System;
using SarrrGames.GoldenRush.Gameplay.Entities.Token;
using UnityEngine;
using Zenject;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Grows
{
    public class BlockOfGrow : MonoBehaviour
    {
         [SerializeField] private BlockMover _blockMover;
         

         public Action BlockDeadAction;
         private TokenProgressModel _token;


         [Inject]
         public void Construct(TokenProgressModel token)
         {
             _token = token;
         }
        
        public void SetShotDestination(Transform shotDestination)
        {
            _blockMover.SetTarget(shotDestination);
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

        private void OnBlockLifeEnd()
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(null);
            BlockDeadAction?.Invoke();
            _token.Soft.SetValue(_token.Soft.GetValue()+15);
        }
    }
}
