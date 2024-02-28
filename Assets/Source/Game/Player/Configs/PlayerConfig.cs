using Source.Common.CustomZenject.ConfigsIntalling;
using UnityEngine;

namespace Source.Game.Player.Configs
{
    [CreateAssetMenu(menuName = "Game/Configs/" + nameof(PlayerConfig), fileName = nameof(PlayerConfig))]
    public class PlayerConfig : BaseInjectableConfig
    {
        [SerializeField] private int defaultMovePoints = 10;

        public int DefaultMovePoints => defaultMovePoints;
    }
}