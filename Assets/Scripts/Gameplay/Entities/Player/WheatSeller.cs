using SarrrGames.GoldenRush.Gameplay.Entities.Grows;
using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Player
{
    public class WheatSeller : MonoBehaviour
    {
        [SerializeField] private Bunch _bunch;
        
        private void OnTriggerEnter(Collider other)
        {
            var ambar = other.GetComponent<Ambar>();
        
            if (ambar != null && _bunch._block.Count>0)
            {
                var o = other.gameObject;

                foreach (var BlockOfGrow in _bunch._block)
                {
                    BlockOfGrow.SetShotDestination(other.gameObject.transform);
                    
                }
            }
        }

    }
}
