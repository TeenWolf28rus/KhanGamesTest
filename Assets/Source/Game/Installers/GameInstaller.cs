using Source.Game.Configs;
using Source.Game.Input;
using Source.Game.Map.Generation.Data;
using Source.Game.Map.Generation.Interfaces;
using Source.Game.Map.Generation.Random;
using UnityEngine;
using Zenject;

namespace Source.Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
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

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
        }
    }
}