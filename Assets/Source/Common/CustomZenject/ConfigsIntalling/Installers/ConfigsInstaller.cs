using UnityEngine;
using Zenject;

namespace Source.Common.CustomZenject.ConfigsIntalling.Installers
{
    [CreateAssetMenu(menuName = "Game/CustomZenject/" + nameof(ConfigsInstaller), fileName = nameof(ConfigsInstaller))]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField] private BaseInjectableConfig[] _configs;

        public override void InstallBindings()
        {
            for (int i = 0; i < _configs.Length; i++)
            {
                if (_configs[i] == null)
                {
                    Debug.LogError($"Config at {i} index doesn't exist, please fix it!", this);
                }

                Container.Bind(_configs[i].GetType()).FromInstance(_configs[i]).AsSingle().NonLazy();
            }
        }
    }
}