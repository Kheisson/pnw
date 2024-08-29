using Input;
using Player;
using UnityEngine;
using Zenject;

namespace Infra.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSettings playerSettings;

        public override void InstallBindings()
        {
            Container.Bind<PlayerSettings>().FromInstance(playerSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.Bind<IPlayerController>().To<PlayerController>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        }
    }
}