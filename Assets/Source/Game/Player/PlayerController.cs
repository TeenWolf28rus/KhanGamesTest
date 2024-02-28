using System;
using Source.Game.Input;
using Source.Game.Map.MapGameLogic;
using Source.Game.Player.Configs;
using UnityEngine;
using Zenject;

namespace Source.Game.Player
{
    public class PlayerController : IInitializable, IDisposable
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;
        private readonly PlayerConfig _config;
        private readonly InputController _inputController;
        private readonly MapController _mapController;

        public PlayerController(PlayerModel model, PlayerView playerView, PlayerConfig config,
            InputController inputController, MapController mapController)
        {
            _model = model;
            _view = playerView;
            _config = config;
            _inputController = inputController;
            _mapController = mapController;
        }

        public void Initialize()
        {
            _inputController.OnClick += ProcessInputClick;
        }

        public void EndTurn()
        {
            ResetPoints();
        }

        public void StartGame()
        {
            ResetPoints();

            var startMapIndexes = _mapController.GetStartedIndexes();
            _model.SetCurrentInMapIndexes(startMapIndexes);

            if (_mapController.TryGetPositionBy(_model.CurrentInMapIndexes, out Vector2 position))
            {
                _view.ChangePosition(position);
            }
        }

        public void Dispose()
        {
            _inputController.OnClick -= ProcessInputClick;
        }

        private void ResetPoints()
        {
            _model.SetMovePoints(_config.DefaultMovePoints);
        }

        private void ProcessInputClick(Vector2 inputPosition)
        {
            if (!_mapController.TryGetIndexesBy(inputPosition, out Vector2Int tileIndex)) return;

            if (tileIndex == _model.CurrentInMapIndexes) return;
            if (tileIndex.x != _model.CurrentInMapIndexes.x && tileIndex.y != _model.CurrentInMapIndexes.y) return;
    
            //correcting for no use in calc current indexed tile
            var firstStepIdx = new Vector2Int(_model.CurrentInMapIndexes.x, _model.CurrentInMapIndexes.y);
            if (firstStepIdx.x < tileIndex.x)
            {
                firstStepIdx.x += 1;
            }
            else if (firstStepIdx.x > tileIndex.x)
            {
                firstStepIdx.x -= 1;
            }

            if (firstStepIdx.y < tileIndex.y)
            {
                firstStepIdx.y += 1;
            }
            else if (firstStepIdx.y > tileIndex.y)
            {
                firstStepIdx.y -= 1;
            }

            if (_mapController.HasObstacleOn(firstStepIdx, tileIndex)) return;

            var pathCost = _mapController.CalculateCosts(firstStepIdx, tileIndex);
            if (pathCost > _model.MovePoints) return;

            _model.SetCurrentInMapIndexes(tileIndex);
            _model.SetMovePoints(_model.MovePoints - pathCost);
            if (_mapController.TryGetPositionBy(_model.CurrentInMapIndexes, out Vector2 newPosition))
            {
                _view.ChangePosition(newPosition);
            }
        }
    }
}