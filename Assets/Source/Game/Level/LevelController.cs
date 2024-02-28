using System;
using Source.Game.Map.MapGameLogic;
using Zenject;

namespace Source.Game.Level
{
    public class LevelController : IInitializable, IDisposable
    {
        private readonly LevelView _view;
        private readonly MapController _mapController;

        public LevelController(LevelView view, MapController mapController)
        {
            _view = view;
            _mapController = mapController;
        }

        public void Initialize()
        {   
            _mapController.CreateMap(_view.MapContainer);
        }

        public void Dispose()
        {
        }
    }
}