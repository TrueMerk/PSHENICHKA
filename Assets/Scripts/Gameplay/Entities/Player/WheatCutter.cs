using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Player
{
    public class WheatCutter : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var wheat = other.GetComponent<Wheat>();
        
            if (wheat != null)
            {
                var o = other.gameObject;
                var localScale = o.transform.localScale;
                localScale =
                    new Vector3(localScale.x/2, localScale.y/2, localScale.z/2);
                o.transform.localScale = localScale;
                wheat.HasBeenCut();
            }
        }
    }
}
