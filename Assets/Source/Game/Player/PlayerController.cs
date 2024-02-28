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
        }

        public void Reset()
        {
        }

        public void Dispose()
        {
            _inputController.OnClick -= ProcessInputClick;
        }

        private void ResetPoints()
        {
            _model.SetMovePoints(_config.DefaultMovePoints);
        }

        private void ProcessInputClick(Vector2 position)
        {
            if (!_mapController.TryGetIndexesBy(position, out Vector2Int tileIndex)) return;
        }
    }
}