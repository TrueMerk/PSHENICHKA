using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Token
{
    public class TokenMover : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.Translate(20,20,20);
        }
    }
}
