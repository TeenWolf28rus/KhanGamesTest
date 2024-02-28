using Source.Game.Player.Signals;
using UnityEngine;
using Zenject;

namespace Source.Game.Player
{
    public class PlayerModel
    {
        private readonly SignalBus _signalBus;

        private int _movePoints = 0;
        private Vector2Int _currentInMapIndexes = new();
        private UpdateMovePointsSignal _updateMovePointsSignal = new();

        public int MovePoints => _movePoints;
        public Vector2Int CurrentInMapIndexes => _currentInMapIndexes;

        public PlayerModel(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void SetMovePoints(int points)
        {
            _movePoints = points;

            _updateMovePointsSignal.MovePoints = _movePoints;
            _signalBus.TryFire(_updateMovePointsSignal);
        }

        public void SetCurrentInMapIndexes(Vector2Int mapIndexes)
        {
            _currentInMapIndexes = mapIndexes;
        }
    }
}