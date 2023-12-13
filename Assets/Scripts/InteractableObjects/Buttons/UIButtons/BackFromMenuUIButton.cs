using System;
using UnityEngine;

public class BackFromMenuUIButton : BaseUIButton
{
    public static Action BackButtonClickEvent;
    [SerializeField] private bool _event;
    protected override void Click()
    {
        if(_event)
       API.Instance.OnInvokeNavAction(InstanceHandler.Instance.ActionToInvoke);
        BackButtonClickEvent?.Invoke();
    }
}
