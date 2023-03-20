using SarrrGames.GoldenRush.Gameplay.Components;
using SarrrGames.GoldenRush.Gameplay.Components.Input;
using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private MovementComponent _movementComponent;
        [SerializeField] private InputComponent _inputComponent;
        [SerializeField] private AnimationComponent _animationComponent;
        [SerializeField] private AttackComponent _attackComponent;
        [SerializeField] private GameObject _kocherga;

        public void Update()
        {
            var direction = _inputComponent.GetMovementDirection();
            var rotation = _inputComponent.GetRotation();
            if (rotation != Quaternion.Euler(0,0,0))
            {
                _movementComponent.Move(direction);
                _movementComponent.Rotate(rotation);
            }
            
        
            var isAttack = _inputComponent.IsAttacking();
            var canAttack = _attackComponent.CanAttack;

            if (direction != Vector3.zero) 
            {
                _animationComponent.PlayRunningAnimation();
                _kocherga.SetActive(false);
            }
        
            else if (!canAttack || !isAttack)
            {
                _animationComponent.PlayIdleAnimation();
                _kocherga.SetActive(false);
            }
        
            if(canAttack && isAttack)
            {
                _kocherga.SetActive(true);
                _animationComponent.PlayAttackAnimation();
                _attackComponent.Attack();
            }
        
        }
    }
}
