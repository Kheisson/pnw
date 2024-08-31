using Input;
using Zenject;

namespace Infra.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMovement>().AsSingle();
            Container.Bind<IPlayerController>().To<PlayerController>().FromComponentInHierarchy().AsSingle();
        }
    }
}