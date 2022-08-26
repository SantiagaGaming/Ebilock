using System;
using System.Collections.Generic;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace AosSdk.Core.Interaction.UIInteraction
{
    public class VrUiCursor : UiCursor
    {
        [SerializeField] private InputActionReference _triggerAction;
        [SerializeField] private AosSDKSettings _sdkSettings;

        private Vector3 CurrentHitPosition { get; set; }

        private Transform _thisTransform;

        [SerializeField] private bool _isOverInteractableCanvas;

        private void Start()
        {
            _thisTransform = transform;
        }

        protected override void UpdateMouseState()
        {
            if (!_isOverInteractableCanvas)
            {
                return;
            }

            InputState.Change(VirtualMouse.position, Player.Instance.EventCamera.WorldToScreenPoint(CurrentHitPosition));

            VirtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, _triggerAction.action.ReadValue<float>() > 0f);
            InputState.Change(VirtualMouse, mouseState);
        }

        private void LateUpdate()
        {
            GetCurrentHitPosition();
        }

        private void GetCurrentHitPosition()
        {
            _isOverInteractableCanvas = false;

            var hits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(transform.position, transform.TransformDirection(Vector3.forward), hits, _sdkSettings.vrInteractDistance * 100,
                ~LayerMask.NameToLayer("UI"));

            if (hitCount == 0)
            {
                return;
            }

            var (candidateHit, isHitValid) = GetValidHit(hits);

            if (!isHitValid)
            {
                return;
            }

            _isOverInteractableCanvas = true;

            CurrentHitPosition = candidateHit.point;

            Debug.DrawLine(_thisTransform.position, CurrentHitPosition, Color.cyan);
        }

        private static (RaycastHit, bool) GetValidHit(IEnumerable<RaycastHit> hits)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.GetComponent<InteractableCanvas>())
                {
                    return (hit, true);
                }
            }

            return new ValueTuple<RaycastHit, bool>(new RaycastHit(), false);
        }
    }
}