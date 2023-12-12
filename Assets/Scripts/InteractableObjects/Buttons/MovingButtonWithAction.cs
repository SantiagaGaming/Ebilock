using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEngine;
using UnityEngine.Events;
public enum ButtonActionName
{
    Hand,
    Hand_1,
    Hand_2,
    Hand_3,
    Hand_4,
    Eye,
    Tool,
    Tool_1,
    Pen,
    Pen_1
}
public class MovingButtonWithAction : MovingButton
{
    public Action<ButtonActionName> ButtonActionEvent;
    [SerializeField] private ButtonActionName _currentAction;

    public override void OnClicked(InteractHand interactHand)
    {
        InstanceHandler.Instance.SceneAosObject.ActionWithObject(GetStringFromEnum(_currentAction));
        ButtonActionEvent?.Invoke(_currentAction);
    }
    private string GetStringFromEnum(Enum enumName)
    {
        return enumName.ToString().ToLower();
    }
}
