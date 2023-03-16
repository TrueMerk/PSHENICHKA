using SarrrGames.GoldenRush.Gameplay.Entities.Grows;
using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Player
{
    public class WheatSeller : MonoBehaviour
    {
        [SerializeField] private Bunch.Bunch _bunch;
        
        private void OnTriggerEnter(Collider other)
        {
            var ambar = other.GetComponent<Ambar>();
        
            if (ambar != null && _bunch.Blocks.Count>0)
            {
                _bunch.SellBlocs(other.transform);
            }
        }

    }
}
