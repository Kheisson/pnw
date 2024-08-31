using UnityEngine;

namespace Input
{
    public class InputService : IInputService
    {
        private readonly PlayerInputs _playerInputs;
        private Vector2 _movementInput;

        public Vector2 MovementInput => _movementInput;

        public InputService()
        {
            _playerInputs = new PlayerInputs();
            OnMovePerformed();
            OnMoveCanceled();
            _playerInputs.Enable();
        }

        private void OnMoveCanceled()
        {
            _playerInputs.Player.Move.canceled += ctx => _movementInput = Vector2.zero;
        }

        private void OnMovePerformed()
        {
            _playerInputs.Player.Move.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
        }
    }
}