using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields

        private const float INPUT_THRESHOLD = 0.01f;
        private CharacterController _characterController;
        private Vector2 _movementInput;

        //TODO: REMOVE PUBLIC FIELDS
        [SerializeField] public float moveSpeed = 5.0f;
        [SerializeField] public float rotationSpeed = 720f;
        
        #endregion

        #region Unity Methods

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            
            if (_characterController == null)
            {
                Debug.LogError("CharacterController component is missing on the player.");
            }
        }

        public void OnMove(InputValue value)
        {
            var input = value.Get<Vector2>();
    
            var swapped = new Vector2(input.y, -input.x);
            _movementInput = IsometricToCartesian(swapped);
        }
        private void Update()
        {
            MovePlayer();
            RotatePlayer();
        }

        #endregion

        #region Private Methods

        private Vector2 IsometricToCartesian(Vector2 isoDirection)
        {
            Vector2 cartDirection = new Vector2(
                0.5f * (isoDirection.x - isoDirection.y),
                0.5f * (isoDirection.x + isoDirection.y));

            return cartDirection;
        }

        private void MovePlayer()
        {
            var move = new Vector3(_movementInput.x, 0, _movementInput.y) * moveSpeed;
            _characterController.Move(move * Time.deltaTime);
        }

        private void RotatePlayer()
        {
            if (!(_movementInput.sqrMagnitude > INPUT_THRESHOLD)) return;
            
            var targetDirection = new Vector3(_movementInput.x, 0, _movementInput.y);
            var targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        #endregion
    }
}