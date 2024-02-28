using Source.Game.Map.Generation.Interfaces;

namespace Source.Game.Map.MapGameLogic
{
    public class MapModel
    {
        private readonly IMapGenerator _mapGenerator;
        private int[,] _mapMatrix;

        public int[,] MapMatrix => _mapMatrix;

        public MapModel(IMapGenerator mapGenerator)
        {
            _mapGenerator = mapGenerator;
        }

        public void RecreateMap()
        {
            _mapMatrix = _mapGenerator.Generate();
        }
    }
}