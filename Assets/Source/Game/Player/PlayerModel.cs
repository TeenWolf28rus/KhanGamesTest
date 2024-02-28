using UnityEngine;

namespace Source.Game.Player
{
    public class PlayerModel
    {
        private int _movePoints = 0;
        private Vector2Int _currentInMapIndexes = new();

        public int MovePoints => _movePoints;
        public Vector2Int CurrentInMapIndexes => _currentInMapIndexes;

        public void SetMovePoints(int points)
        {
            _movePoints = points;
        }
        
        public void SetCurrentInMapIndexes(Vector2Int mapIndexes)
        {
            _currentInMapIndexes = mapIndexes;
        }
    }
}