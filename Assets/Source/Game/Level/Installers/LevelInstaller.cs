using Source.Game.Map.MapGameLogic;
using Source.Game.NewHUD;
using Source.Game.Player;
using UnityEngine;
using Zenject;

namespace Source.Game.Level.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private MapView _mapView;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private NewHUDView _hudView;

        public override void InstallBindings()
        {
            BindMap();
            BindLevel();
            BindPlayer();
            BindHUD();
        }

        private void BindMap()
        {
            Container.Bind<MapModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<MapController>().AsSingle().WithArguments(_mapView);
        }

        private void BindLevel()
        {
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle().NonLazy();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().WithArguments(_playerView);
        }

        private void BindHUD()
        {
            Container.BindInterfacesAndSelfTo<NewHUDController>().AsSingle().WithArguments(_hudView);
        }
    }
}