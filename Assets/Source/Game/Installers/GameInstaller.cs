using Source.Game.Configs;
using Source.Game.Input;
using Source.Game.Map.Generation.Data;
using Source.Game.Map.Generation.Interfaces;
using Source.Game.Map.Generation.Random;
using Source.Game.Player.Signals;
using UnityEngine;
using Zenject;

namespace Source.Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSignalBus();
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
                        "Prepared generation not working now. Please select random in GameConfig for correct work. Now setted random for no stop game");
                    //todo added prepared map generator and other if need
                    Container.Bind<IMapGenerator>().To<RandomMapGenerator>().AsSingle();
                    break;
                }
            }
        }

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
        }

        private void BindSignalBus()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<UpdateMovePointsSignal>();
        }
    }
}