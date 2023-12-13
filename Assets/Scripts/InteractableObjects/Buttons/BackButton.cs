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

        OnBackButtonClick?.Invoke();

    }
}