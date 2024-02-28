using Source.Game.MapLogic.Generation.Configs;
using Source.Game.MapLogic.Generation.Interfaces;

namespace Source.Game.MapLogic.Generation
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
            var mapMatrix = new int[_generationConfig.MapSize.x, _generationConfig.MapSize.y];

            return mapMatrix;
        }
    }
}