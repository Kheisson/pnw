using UnityEngine;
using Zenject;

namespace Input
{
    public class InputService : IInputService, ITickable
    {
        private readonly PlayerInputs _playerInputs;
        private Vector2 _movementInput;

        public Vector2 MovementInput => _movementInput;

        public InputService()
        {
            _playerInputs = new PlayerInputs();
            _playerInputs.Player.Move.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
            _playerInputs.Player.Move.canceled += ctx => _movementInput = Vector2.zero;
            _playerInputs.Enable();
        }

        public void Tick()
        {
        }
    }
}