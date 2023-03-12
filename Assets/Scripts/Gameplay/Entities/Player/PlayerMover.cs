using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private PlayerAnimationController _animator;

        private bool isAttacking = false;
        
        void Update()
        {
            float h = UnityEngine.Input.GetAxis("Horizontal");
            float v = UnityEngine.Input.GetAxis("Vertical");
            
            if (h!=0 || v != 0)
            {
                _animator.PlayRunningAnimation();
            }
            
            else if (UnityEngine.Input.GetButtonDown("Jump"))
            {
                _animator.PlayAttackAnimation();
                isAttacking = true;
            }
            
            else if (h==0 && v == 0) 
            {
                _animator.PlayIdleAnimation();
                 
            }

            
            transform.Translate(h/100*_speed,0,v/100*_speed);
            
        }
    }
}
