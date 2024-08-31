using Player;
using UnityEngine;
using Zenject;

namespace Infra.Installers
{
    [CreateAssetMenu(menuName = "Game/Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        public PlayerSettings playerSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(playerSettings);
        }
    }
}