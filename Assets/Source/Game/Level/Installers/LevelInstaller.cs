using Source.Game.Map.MapGameLogic;
using UnityEngine;
using Zenject;

namespace Source.Game.Level.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelView _levelView;
        [SerializeField] private MapView _mapView;

        public override void InstallBindings()
        {
            BindMap();
            BindLevel();
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
    }
}