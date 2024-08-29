using UnityEngine;
using Zenject;

namespace Input
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour, ITickable
    {
        private IInputService _inputService;
        private IPlayerController _playerController;

        [Inject]
        public void Construct(IInputService inputService, IPlayerController playerController)
        {
            _inputService = inputService;
            _playerController = playerController;
        }

        public void Tick()
        {
            if (_inputService == null || _playerController == null)
            {
                Debug.LogError("Dependencies are not injected properly.");
                return;
            }

            var movementInput = _inputService.MovementInput;
            _playerController.Move(movementInput);
            _playerController.Rotate(movementInput);
        }
    }
}