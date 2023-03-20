using SarrrGames.GoldenRush.Gameplay.Entities.Token;
using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Ambar
{
    public class Ambar : MonoBehaviour
    {
        [SerializeField] private TokenPool _tokenPool;

        public void CreateToken()
        {
            _tokenPool.CreateToken(transform);
        }
    }
}
