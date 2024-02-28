using Source.Game.HUD;
using Source.Game.Map.MapGameLogic;
using Source.Game.Player;
using UnityEngine;
using Zenject;

namespace Source.Game.Level.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private MapView _mapView;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private HUDView _hudView;

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
            Container.BindInterfacesAndSelfTo<HUDController>().AsSingle().WithArguments(_hudView);
        }
    }
}