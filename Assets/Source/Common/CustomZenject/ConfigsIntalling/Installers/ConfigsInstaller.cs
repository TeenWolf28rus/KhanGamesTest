using UnityEngine;
using Zenject;

namespace Source.Common.CustomZenject.ConfigsIntalling.Installers
{
    [CreateAssetMenu(menuName = "Game/CustomZenject/" + nameof(ConfigsInstaller), fileName = nameof(ConfigsInstaller))]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField] private BaseInjectableConfig[] configs;

        public override void InstallBindings()
        {
            for (int i = 0; i < configs.Length; i++)
            {
                if (configs[i] == null)
                {
                    Debug.LogError($"Config at {i} index doesn't exist, please fix it!", this);
                }

                Container.Bind(configs[i].GetType()).FromInstance(configs[i]).AsSingle().NonLazy();
            }
        }
    }
}