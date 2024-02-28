using Source.Common.Utils;
using Source.Game.Map.Generation.Interfaces;
using Source.Game.Map.Generation.Random.Configs;

namespace Source.Game.Map.Generation.Random
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


            var tilesGenerationData = _generationConfig.TilesData;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    mapMatrix[r, c] = (int)Utils.GetRandomIndexBy(tilesGenerationData);
                }
            }

            return mapMatrix;
        }
    }
}