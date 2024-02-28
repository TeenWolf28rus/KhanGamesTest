using UnityEngine;

namespace Source.Game.Player
{
    public class PlayerModel
    {
        private int _movePoints = 0;
        private Vector2 _position = new();


        public int MovePoints => _movePoints;

        public Vector2 Position => _position;

        public void SetMovePoints(int points)
        {
            _movePoints = points;
        }
    }
}