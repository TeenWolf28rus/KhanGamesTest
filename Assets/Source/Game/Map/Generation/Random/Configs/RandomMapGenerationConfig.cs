using System.Collections.Generic;
using Source.Common.CustomZenject.ConfigsIntalling;
using Source.Common.Utils.Data;
using Source.Game.Map.Data;
using UnityEngine;

namespace Source.Game.Map.Generation.Random.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/MapGen/" + nameof(RandomMapGenerationConfig),
        fileName = nameof(RandomMapGenerationConfig))]
    public class RandomMapGenerationConfig : BaseInjectableConfig
    {
        [SerializeField] private Vector2Int mapSize = new(5, 5);
        [SerializeField] private List<WeightedData<EMapTileType>> tilesData = new();


        public Vector2Int MapSize => mapSize;
        public List<WeightedData<EMapTileType>> TilesData => tilesData;
    }
}