using System;
using Source.Game.MapLogic.Generation.Interfaces;
using UnityEngine;
using Zenject;

namespace Source.Game.Map.MapGameLogic
{
    public class MapController : IInitializable, IDisposable
    {
        private readonly IMapGenerator _mapGenerator;

        public MapController(IMapGenerator mapGenerator)
        {
            _mapGenerator = mapGenerator;
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        public void CreateMap(Transform mapContainer)
        {
            var mapMatrix = _mapGenerator.Generate();
            Debug.Log(mapMatrix);
        }
    }
}