using AosSdk.Core.PlayerModule;
using AosSdk.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangableGrabbableLamp : GrabbableScenarioObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LampPosition pos))
        {
            OnActionWithObject?.Invoke();
            Player.Instance.DropObject(0);
            OnUnGrabbed(pos.NewLampPosition());
        }
    }
}
