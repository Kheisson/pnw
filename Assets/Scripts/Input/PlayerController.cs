using Player;
using UnityEngine;
using Zenject;

namespace Input
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private const float INPUT_THRESHOLD = 0.01f;

        private CharacterController _characterController;
        private Vector2 _smoothMovementInput;
        private Vector2 _smoothMovementInputVelocity;
        private float _moveSpeed;
        private float _rotationSpeed;
        private float _smoothTime;

        [Inject]
        public void Construct(PlayerSettings settings)
        {
            _moveSpeed = settings.MoveSpeed;
            _rotationSpeed = settings.RotationSpeed;
            _smoothTime = settings.SmoothTime;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void Move(Vector2 direction)
        {
            _smoothMovementInput = Vector2.SmoothDamp(_smoothMovementInput, direction, ref _smoothMovementInputVelocity, _smoothTime);
            var move = new Vector3(_smoothMovementInput.x, 0, _smoothMovementInput.y) * _moveSpeed;
            _characterController.Move(move * Time.deltaTime);
        }

        public void Rotate(Vector2 direction)
        {
            if (!(direction.sqrMagnitude > INPUT_THRESHOLD)) return;
        
            var targetDirection = new Vector3(direction.x, 0, direction.y);
            var targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}