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
            InstanceHandler.Instance.MeasureButtonsActivator.ActivateButtonsWithList();
        }
        else
        {
            _amper = false;
            StartCoroutine(DisableButtonsDelay());
        }
       InstanceHandler.Instance.AmperMetr.EnableAmper(_amperPosition);
 
    }
    private void DisableMeasureButtons()
    {
        _amper = false;
        InstanceHandler.Instance.ShupController.OnResetShupPosition();
        InstanceHandler.Instance.MeasureButtonsActivator.DeactivateAllButtons();
        InstanceHandler.Instance.PointerDevice.SetValue(1);
    }
    private IEnumerator DisableButtonsDelay()
    {
        yield return new WaitForSeconds(0.3f);
        DisableMeasureButtons();
    }
}

