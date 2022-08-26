using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class BackButtonObject : BaseButton
{
    public UnityAction BackButtonClickEvent;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        MovingButtonsController.Instance.HideAllButtons();
        BackButtonClickEvent?.Invoke();
        ShupController shup = FindObjectOfType<ShupController>();
        shup.ResetShupPosition();
    }
}
