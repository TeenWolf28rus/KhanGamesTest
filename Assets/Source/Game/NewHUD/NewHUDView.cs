using Source.Game.HUD;
using UnityEngine;

namespace Source.Game.NewHUD
{
    public class NewHUDView : HUDView
    {
        [SerializeField] private GameObject _newTurnGO;

        public void ShowNewTurn()
        {
            _newTurnGO.SetActive(true);
        }

        public void HideNewTurn()
        {
            _newTurnGO.SetActive(false);
        }
    }
}