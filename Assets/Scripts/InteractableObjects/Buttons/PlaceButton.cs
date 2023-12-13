using AosSdk.Core.PlayerModule.Pointer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlaceButtonActionState
{
    Back,
    Radio,
    Scheme,
    Amper
}
public class PlaceButton : BaseButton
{
    public static Action<PlaceButtonActionState> PlaceButtonClickedEvent;
    [SerializeField] private PlaceButtonActionState _currentState;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        PlaceButtonClickedEvent?.Invoke(_currentState);
    }
}
