using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.PlayerModule;
using UnityEngine;
using System;

public class NextButton : BaseButton
{
    public Action<string> NextButtonPressedEvent;
    [HideInInspector] public NextButtonState CurrentState;
    public override void OnClicked(InteractHand interactHand)
    {
        if (CurrentState == NextButtonState.Start)
        {
            API.Instance.OnInvokeNavAction("next");
            NextButtonPressedEvent?.Invoke("next");
            Player.Instance.CanMove = false;
        }
        else if (CurrentState == NextButtonState.Fault)
        {
            API.Instance.OnInvokeNavAction("start");
            NextButtonPressedEvent?.Invoke("start");
            Player.Instance.CanMove = true;
        }
    }
}
