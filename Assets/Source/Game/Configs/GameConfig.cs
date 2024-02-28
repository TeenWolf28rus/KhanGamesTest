using Source.Common.CustomZenject.ConfigsIntalling;
using Source.Game.Map.Generation.Data;
using UnityEngine;

namespace Source.Game.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/" + nameof(GameConfig), fileName = nameof(GameConfig))]
    public class GameConfig : BaseInjectableConfig
    {
        [SerializeField] private EMapGenerationType _mapGenerationType = EMapGenerationType.Random;

        public EMapGenerationType MapGenerationType => _mapGenerationType;
    }
}