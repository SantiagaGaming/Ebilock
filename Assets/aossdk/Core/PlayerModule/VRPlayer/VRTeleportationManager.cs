using AosSdk.Core.Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Core.PlayerModule.VRPlayer
{
    public class VRTeleportationManager : TeleportationManager
    {
        [SerializeField] private TeleportationManager anotherHandTeleportationManager;

        protected override void TeleportationActivateActionOnPerformed(InputAction.CallbackContext obj)
        {
            if (anotherHandTeleportationManager && anotherHandTeleportationManager.IsTeleportActive ||
                !Player.Instance.CanMove)
            {
                return;
            }

            IsTeleportActive = true;
            teleportArcManager.ToggleDisplay(true);
        }
    }
}