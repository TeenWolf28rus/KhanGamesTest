using Source.Game.Configs;
using Source.Game.MapLogic.Generation;
using Source.Game.MapLogic.Generation.Data;
using Source.Game.MapLogic.Generation.Interfaces;
using UnityEngine;
using Zenject;

namespace Source.Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMapGeneration();
        }

        private void BindMapGeneration()
        {
            var gameConfig = Container.Resolve<GameConfig>();

            switch (gameConfig.MapGenerationType)
            {
                case EMapGenerationType.Random:
                {
                    Container.Bind<IMapGenerator>().To<RandomMapGenerator>().AsSingle();
                    break;
                }
                default:
                {
                    Debug.LogError(
                        "Prepared generation not working now. Please select random in GameConfig for correct work");
                    //todo added prepared map generator and other if need
                    break;
                }
            }
        }
    }
}