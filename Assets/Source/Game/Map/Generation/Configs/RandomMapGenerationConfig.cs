using Source.Common.CustomZenject.ConfigsIntalling;
using UnityEngine;

namespace Source.Game.MapLogic.Generation.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/MapGen/" + nameof(RandomMapGenerationConfig),
        fileName = nameof(RandomMapGenerationConfig))]
    public class RandomMapGenerationConfig : BaseInjectableConfig
    {
        [SerializeField] private Vector2Int mapSize = new(5, 5);

        public Vector2Int MapSize => mapSize;
    }
}