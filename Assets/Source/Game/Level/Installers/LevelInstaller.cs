using Source.Game.Map.MapGameLogic;
using Source.Game.Player;
using UnityEngine;
using Zenject;

namespace Source.Game.Level.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelView _levelView;
        [SerializeField] private MapView _mapView;
        [SerializeField] private PlayerView _playerView;

        public override void InstallBindings()
        {
            BindMap();
            BindLevel();
            BindPlayer();
        }

        private void BindMap()
        {
            Container.Bind<MapModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<MapController>().AsSingle().WithArguments(_mapView);
        }

        private void BindLevel()
        {
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle().WithArguments(_levelView).NonLazy();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().WithArguments(_playerView);
        }
    }
}