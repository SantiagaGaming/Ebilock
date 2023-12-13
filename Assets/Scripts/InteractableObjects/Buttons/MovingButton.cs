using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEngine;
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

public class MovingButton : BaseButton
{
    public Action<ButtonActionName> ButtonClickEvent;
    public Action<Transform,string> ButtonHoverEvent;
    [SerializeField] private ButtonActionName _currentAction;
    [SerializeField] private string _actionText;
    public ButtonActionName ButtonActionName => _currentAction;
    public override void OnHoverIn(InteractHand interactHand)
    {
        transform.localScale *= 1.5f;
        if (HelperPos != null)
            ButtonHoverEvent?.Invoke(HelperPos, _actionText);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        transform.localScale /= 1.5f;
        if (HelperPos != null)
            ButtonHoverEvent?.Invoke(null, null);
    }
    public override void OnClicked(InteractHand interactHand)
    {
        ButtonClickEvent?.Invoke(_currentAction);
    }
    public void ChangeButtonPosistion(float y)
    {
        transform.localPosition = new Vector3(0, y, 0);
    }
    public void SetActionText(string text)
    {
        _actionText = text;
    }
}
