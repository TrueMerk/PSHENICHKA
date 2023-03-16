using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Components
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 3;
        [SerializeField] private int _rotationSpeed = 50;
    
        public void Move(float horizontal, float vertical)
        {
            transform.Translate(horizontal/100*_movementSpeed,0,vertical/100*_movementSpeed);
        }

        public void Rotate(Quaternion target)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * _rotationSpeed);
        }
    }
}
