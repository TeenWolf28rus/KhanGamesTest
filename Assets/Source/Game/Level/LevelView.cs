using UnityEngine;

namespace Source.Game.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Transform _mapContainer;

        public Transform MapContainer => _mapContainer;
    }
}