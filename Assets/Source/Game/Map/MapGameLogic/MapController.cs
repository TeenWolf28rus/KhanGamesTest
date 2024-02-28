using System;
using Source.Game.Map.Configs;
using UnityEngine;
using Zenject;

namespace Source.Game.Map.MapGameLogic
{
    public class MapController : IInitializable, IDisposable
    {
        private readonly MapView _view;
        private readonly MapModel _model;
        private readonly MapConfig _mapConfig;

        public MapController(MapView view, MapModel model, MapConfig mapConfig)
        {
            _view = view;
            _model = model;
            _mapConfig = mapConfig;

            _view.Init(_mapConfig);
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
            _view.Create(_model.MapMatrix);
        }

        public bool TryGetIndexesBy(Vector2 position, out Vector2Int indexes)
        {
            return _view.TryGetIndexesBy(position, out indexes);
        }
    }
}