using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class AmperButton : BaseButton
{
    [SerializeField] protected Transform _amperPosition;
    private bool _amper = false;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        if (!_amper)
        {
            _amper = true;
            Debug.Log(_amper + " in if");
            InstanceHandler.Instance.MeasureButtonsActivator.ActivateButtonsWithList();
        }
        else
        {
            _amper = false;
            Debug.Log(_amper + " in  else if");
            DisableMeasureButtons();
        }
       InstanceHandler.Instance.AmperMetr.EnableAmper(_amperPosition);
 
    }
    private void DisableMeasureButtons()
    {
        InstanceHandler.Instance.ShupController.OnResetShupPosition();
        InstanceHandler.Instance.MeasureButtonsActivator.DeactivateAllButtons();
        InstanceHandler.Instance.PointerDevice.SetValue(1);
    }
}

