using System;
using UnityEngine;

namespace Source.Game.Map.Data
{
    [Serializable]
    public struct MapTileData
    {
        public EMapTileType TileType;
        public Color Color;
        public int Cost;
    }
}