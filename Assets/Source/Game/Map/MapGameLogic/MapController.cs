using System;
using Zenject;

namespace Source.Game.Map.MapGameLogic
{
    public class MapController : IInitializable, IDisposable
    {
        private readonly MapView _view;
        private readonly MapModel _model;

        public MapController(MapView view, MapModel model)
        {
            _view = view;
            _model = model;
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public void CreateMap()
        {
            _model.RecreateMap();
            _view.Display(_model.MapMatrix);
        }
    }
}