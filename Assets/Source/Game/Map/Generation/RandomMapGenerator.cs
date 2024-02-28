using System;
using System.Linq;
using Source.Game.Map.Data;
using Source.Game.Map.Generation.Configs;
using Source.Game.Map.Generation.Interfaces;

namespace Source.Game.Map.Generation
{
    public class RandomMapGenerator : IMapGenerator
    {
        private readonly RandomMapGenerationConfig _generationConfig;

        public RandomMapGenerator(RandomMapGenerationConfig generationConfig)
        {
            _generationConfig = generationConfig;
        }

        public int[,] Generate()
        {
            var rows = _generationConfig.MapSize.y;
            var columns = _generationConfig.MapSize.x;
            var mapMatrix = new int[rows, columns];

            var types = Enum.GetValues(typeof(EMapTileType)).Cast<EMapTileType>().ToList();

            var rnd = new Random();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    mapMatrix[r, c] = (int)types[rnd.Next(0, types.Count)];
                }
            }

            return mapMatrix;
        }
    }
}