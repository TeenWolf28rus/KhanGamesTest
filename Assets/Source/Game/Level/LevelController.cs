using System;
using Source.Game.Input;
using Source.Game.Map.MapGameLogic;
using Source.Game.Player;
using Zenject;

namespace Source.Game.Level
{
    public class LevelController : IInitializable, IDisposable
    {
        private readonly MapController _mapController;
        private readonly InputController _inputController;
        private readonly PlayerController _playerController;

        public LevelController(MapController mapController, InputController inputController,
            PlayerController playerController)
        {
            _mapController = mapController;
            _inputController = inputController;
            _playerController = playerController;
        }

        public void Initialize()
        {
            _mapController.CreateMap();
            _playerController.StartGame();
            _inputController.SetEnable(true);
        }

        public void Dispose()
        {
        }

        public void EndTurn()
        {
            _playerController.EndTurn();
        }

        public void Restart()
        {
            _mapController.CreateMap();
            _playerController.StartGame();
        }
    }
}