using SarrrGames.GoldenRush.Gameplay.Entities.Player;
using SarrrGames.GoldenRush.Gameplay.ObjectsPool;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace SarrrGames.GoldenRush.Gameplay.Context.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
         [SerializeField] private PlayerUnit playerUnit;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerUnit>().FromInstance(playerUnit).AsSingle();
            Container.Bind<Pool>().AsTransient().Lazy();    
        }
    }
}
