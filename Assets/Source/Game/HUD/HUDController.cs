using System;
using Source.Game.Level;
using Source.Game.Player.Signals;
using Zenject;

namespace Source.Game.HUD
{
    public class HUDController : IDisposable
    {
        private readonly HUDView _view;
        private readonly SignalBus _signalBus;
        private readonly LevelController _levelController;

        public HUDController(HUDView view, SignalBus signalBus, LevelController levelController)
        {
            _view = view;
            _signalBus = signalBus;
            _levelController = levelController;

            _signalBus.Subscribe<UpdateMovePointsSignal>(ProcessUpdateMovePointsSignal);
            _view.OnClickEndTurn += ProcessClickEndTurn;
            _view.OnClickRestart += ProcessClickRestart;
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<UpdateMovePointsSignal>(ProcessUpdateMovePointsSignal);
            _view.OnClickEndTurn -= ProcessClickEndTurn;
            _view.OnClickRestart -= ProcessClickRestart;
        }

        private void ProcessClickEndTurn()
        {
            _levelController.EndTurn();
        }

        private void ProcessClickRestart()
        {
            _levelController.Restart();
        }

        private void ProcessUpdateMovePointsSignal(UpdateMovePointsSignal signal)
        {
            _view.UpdateMovePoints(signal.MovePoints);
        }
    }
}