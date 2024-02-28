using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Source.Game.Input
{
    public class InputController : IInitializable, ITickable, IDisposable
    {
        public event Action<Vector2> OnClick = delegate { };

        private EventSystem _eventSystem = null;
        private bool _enabled = false;

        public void SetEnable(bool enable)
        {
            _enabled = enable;
        }

        public void Initialize()
        {
            UnityEngine.Input.simulateMouseWithTouches = true;
            UnityEngine.Input.multiTouchEnabled = false;
            _eventSystem = EventSystem.current;

            if (_eventSystem == null)
            {
                var eventSystemGo = new GameObject("EventSys");
                _eventSystem = eventSystemGo.AddComponent<EventSystem>();
            }
        }


        public void Tick()
        {
            if (!_enabled) return;
            if (!UnityEngine.Input.GetMouseButtonUp(0)) return;
            if (Camera.main == null) return;
            if (IsPointerOverUiElement()) return;

            var worldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            OnClick.Invoke(worldPosition);
        }

        public void Dispose()
        {
            OnClick = delegate { };
        }

        private EventSystem GetCurrentEventSystem() => _eventSystem == null ? EventSystem.current : _eventSystem;
        private bool IsPointerOverUiElement() => IsPointerOverUIElement(GetEventSystemRaycastResults());

        private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
        {
            for (int i = 0; i < eventSystemRaycastResults.Count; ++i)
            {
                var result = eventSystemRaycastResults[i];
                var layer = result.gameObject.layer;
                if (layer == LayerMask.NameToLayer("UI")) return true;
            }

            return false;
        }

        private List<RaycastResult> GetEventSystemRaycastResults()
        {
            var eventData = new PointerEventData(GetCurrentEventSystem())
                { position = UnityEngine.Input.mousePosition };
            var results = new List<RaycastResult>();
            GetCurrentEventSystem().RaycastAll(eventData, results);
            return results;
        }
    }
}