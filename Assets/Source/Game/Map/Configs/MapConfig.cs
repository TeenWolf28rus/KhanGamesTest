using System.Collections.Generic;
using Source.Common.CustomZenject.ConfigsIntalling;
using Source.Game.Map.Data;
using UnityEngine;

namespace Source.Game.Map.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/" + nameof(MapConfig), fileName = nameof(MapConfig))]
    public class MapConfig : BaseInjectableConfig
    {
        [SerializeField] private MapTileData[] _tilesData;


        private Dictionary<EMapTileType, MapTileData> _cachedTileData = null;

        public MapTileData? GetTileData(EMapTileType type)
        {
            if (_cachedTileData == null)
            {
                _cachedTileData = new Dictionary<EMapTileType, MapTileData>();
                for (int i = 0; i < _tilesData.Length; i++)
                {
                    var data = _tilesData[i];
                    _cachedTileData.Add(data.TileType, data);
                }
            }

            if (_cachedTileData.TryGetValue(type, out var tileData))
            {
                return tileData;
            }

            return null;
        }
    }
}