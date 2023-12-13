using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceButtonsEventHandler : MonoBehaviour
{
    [SerializeField] private AosActionsHandler _movingButtons;
    [SerializeField] private BackTriggersHolder _backtriggers;
    [SerializeField] private Ampermetr _amper;
    [SerializeField] private HelpTextController _helpTextController;
    private void Start()
    {
        PlaceButton.PlaceButtonClickedEvent += OnPlaceButtonClicked;
    }
    private void OnPlaceButtonClicked(PlaceButtonActionState state)
    {
        switch(state)
        {
            case PlaceButtonActionState.Back:
                API.Instance.OnInvokeNavAction(InstanceHandler.Instance.ActionToInvoke);
                InstanceHandler.Instance.PlayCloseAnimationForAllObjects();
                InstanceHandler.Instance.SetCurrentBackButton(null);
                _backtriggers.EnableCurrentTrigger(false);
                _helpTextController.HideReactionText();
                _amper.DisableAmper();
                break;
            case PlaceButtonActionState.Radio:
                break;
            case PlaceButtonActionState.Scheme:
                break;
            case PlaceButtonActionState.Amper:

                break;
        }
    }
}
