using SarrrGames.GoldenRush.Gameplay.Entities.Player;
using SarrrGames.GoldenRush.Gameplay.Entities.Token;
using SarrrGames.GoldenRush.Gameplay.ObjectsPool;
using Zenject;

namespace SarrrGames.GoldenRush.Core.Context
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerProgressModel>().AsSingle().NonLazy();
            Container.Bind<TokenProgressModel>().AsSingle().NonLazy();
        }
    }
}
