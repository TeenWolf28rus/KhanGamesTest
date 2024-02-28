using System;
using System.Threading.Tasks;
using Source.Game.Level;
using Source.Game.Player.Signals;
using Zenject;

namespace Source.Game.NewHUD
{
    public class NewHUDController : IDisposable
    {
        private readonly NewHUDView _view;
        private readonly SignalBus _signalBus;
        private readonly LevelController _levelController;

        public NewHUDController(NewHUDView view, SignalBus signalBus, LevelController levelController)
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

        private async void ProcessClickEndTurn()
        {
            _levelController.EndTurn();
            _view.ShowNewTurn();
            await Task.Delay(2000);
            _view.HideNewTurn();
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