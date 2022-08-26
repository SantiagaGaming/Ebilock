using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepairButton : MovingButton
{
    [SerializeField] private AosButtonsHandler _buttonsHandler;
    public override void OnClicked(InteractHand interactHand)
    {
        _buttonsHandler.RepairClicked(MovingButtonsController.Instance.ObjectName);
    }
}
