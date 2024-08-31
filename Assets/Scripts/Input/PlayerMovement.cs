using Zenject;

namespace Input
{
    public class PlayerMovement : ITickable
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
            var movementInput = _inputService.MovementInput;
            _playerController.Move(movementInput);
            _playerController.Rotate(movementInput);
        }
    }
}