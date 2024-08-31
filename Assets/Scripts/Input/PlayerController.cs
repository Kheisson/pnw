using Player;
using UnityEngine;
using Zenject;

namespace Input
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private const float INPUT_THRESHOLD = 0.01f;

        private PlayerSettings _settings;
        private CharacterController _characterController;
        private Vector2 _smoothMovementInput;
        private Vector2 _smoothMovementInputVelocity;

        [Inject]
        public void Construct(PlayerSettings settings)
        {
            _settings = settings;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void Move(Vector2 direction)
        {
            var isometricDirection = ConvertToIsometric(direction);
            _smoothMovementInput = Vector2.SmoothDamp(_smoothMovementInput, isometricDirection, ref _smoothMovementInputVelocity, _settings.SmoothTime);
            
            var move = new Vector3(_smoothMovementInput.x, 0, _smoothMovementInput.y) * _settings.MoveSpeed;
            _characterController.Move(move * Time.deltaTime);
        }

        public void Rotate(Vector2 direction)
        {
            if (!(direction.sqrMagnitude > INPUT_THRESHOLD)) return;

            var isometricDirection = ConvertToIsometric(direction);
            var targetDirection = new Vector3(isometricDirection.x, 0, isometricDirection.y);
            var targetRotation = Quaternion.LookRotation(targetDirection);
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _settings.RotationSpeed * Time.deltaTime);
        }

        private Vector2 ConvertToIsometric(Vector2 input)
        {
            return new Vector2(
                input.x + input.y, 
                input.y - input.x  
            );
        }
    }
}
