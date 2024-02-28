using Source.Game.Map.MapGameLogic;
using UnityEngine;
using Zenject;

namespace Source.Game.Level.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelView _levelView;
        public override void InstallBindings()
        {
            BindMap();
            BindLevel();
        }

        private void BindMap()
        {
            Container.BindInterfacesAndSelfTo<MapController>().AsSingle();
        }

        private void BindLevel()
        {
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle().WithArguments(_levelView).NonLazy();
        }
    }
}