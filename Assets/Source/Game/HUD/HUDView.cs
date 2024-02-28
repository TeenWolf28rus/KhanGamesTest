using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Game.HUD
{
    public class HUDView : MonoBehaviour
    {
        [SerializeField] private Button _endTurnBtn;
        [SerializeField] private Button _restartBtn;
        [SerializeField] private TextMeshProUGUI _movePointsLabel;
        [SerializeField] private string _movePointsLabelFormat = "{0}";

        public event Action OnClickEndTurn = delegate { };
        public event Action OnClickRestart = delegate { };

        private void Awake()
        {
            _endTurnBtn.onClick.AddListener(ProcessClickEndTurn);
            _restartBtn.onClick.AddListener(ProcessClickRestart);
        }

        private void OnDestroy()
        {
            _endTurnBtn.onClick.RemoveListener(ProcessClickEndTurn);
            _restartBtn.onClick.RemoveListener(ProcessClickRestart);
            OnClickEndTurn = delegate { };
            OnClickRestart = delegate { };
        }

        private void ProcessClickEndTurn()
        {
            OnClickEndTurn?.Invoke();
        }

        private void ProcessClickRestart()
        {
            OnClickRestart?.Invoke();
        }

        public void UpdateMovePoints(int movePoints)
        {
            _movePointsLabel.text = string.Format(_movePointsLabelFormat, movePoints);
        }
    }
}