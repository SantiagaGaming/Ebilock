using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAosButton :BaseButton
{
    [SerializeField] private ButtonActionInvoker _buttonActionInvoker;
    public override void OnClicked(InteractHand interactHand)
    {
        if (_buttonActionInvoker != null)
            _buttonActionInvoker.InvokeOnClick();
    }
}
