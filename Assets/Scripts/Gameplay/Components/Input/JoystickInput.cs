using UnityEngine;

namespace SarrrGames.GoldenRush.Gameplay.Components.Input
{
    public class JoystickInput : InputComponent
    {
        [SerializeField] private Joystick _joystick;
    
    
        public override Vector3 GetMovementDirection()
        {
            return Vector3.forward * _joystick.Vertical ;
        }

        public override Quaternion GetRotation()
        {
            return  Quaternion.identity;
        }

        public override bool IsAttacking()
        {
            return true;
        }
    }
}
