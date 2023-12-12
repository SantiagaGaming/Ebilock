using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using System;
public class BackButton : BaseButton
{
    public static Action OnBackButtonClick;
    [SerializeField] private bool _trigger;
    protected override void Start()
    {
        base.Start();
        if(!_trigger)
        transform.parent = null;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        API.Instance.OnInvokeNavAction(InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke);
        InstanceHandler.Instance.PlayCloseAnimationForAllObjects();
        InstanceHandler.Instance.BackButtonsActivator.SetCurrentBackButton(null);
        InstanceHandler.Instance.BackTriggersHoler.EnableCurrentTrigger(false);
        InstanceHandler.Instance.ReactionInfoWindow.SetTransfromAndText(null,null);
        InstanceHandler.Instance.MeasureButtonsActivator.DeactivateAllButtons();
        OnBackButtonClick?.Invoke();

    }
}