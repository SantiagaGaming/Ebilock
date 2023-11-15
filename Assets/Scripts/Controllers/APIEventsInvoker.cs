using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private ConnectionToClient _connectionChecker;

    private void OnEnable()
    {
        _connectionChecker.OnReadyToAction += OnSetLocationAfterConnection;
        _api.ShowPlaceEvent += OnDeactivateColliders;
        _api.ReactionEvent += OnShowReactionWindow;
        _api.ResetMeasureButtonsEvent += OnResetMesaureButtons;
        _api.SetTeleportLocationEvent += OnSetLoationToTeleport;
        _api.SetNewLocationTextEvent += OnSetLocationTextToLocationController;
        _api.SetLocationEvent += OnSetLocationToLocationController;
        _api.SetLocationForFieldCollidersEvent += OnActivateStreetColliders;
        _api.EnableDietButtonsEvent += OnEnableDietButton;
        _api.EnableMovingButtonEvent += OnEnableMovingButton;
        _api.SetTimerTextEvent += OnSetTimerText;
        _api.AddMeasureButtonEvent += OnAddButtonToMeasureButtonsList;
        _api.ActivateByNameEvent += OnActivateSceneObjectByName;
        _api.SetMessageTextEvent += OnSetLastScreenText;
        _api.SetResultTextEvent += OnSetResultScreenText;
        _api.ShowExitTextEvent += OnSetExitText;
        _api.ShowMenuTextEvent += OnSetMenuText;
        _api.SetStartTextEvent += OnSetStartText;
        _api.SetMeasureValueEvent += OnSetMeasureValue;
        _api.ActivateBackButtonEvent += OnActivaneBackButton;

    }

    private void OnDisable()
    {
        _connectionChecker.OnReadyToAction -= OnSetLocationAfterConnection;
        _api.ShowPlaceEvent -= OnDeactivateColliders;
        _api.ReactionEvent -= OnShowReactionWindow;
        _api.ResetMeasureButtonsEvent -= OnResetMesaureButtons;
        _api.SetTeleportLocationEvent -= OnSetLoationToTeleport;
        _api.SetNewLocationTextEvent -= OnSetLocationTextToLocationController;
        _api.SetLocationEvent -= OnSetLocationToLocationController;
        _api.SetLocationForFieldCollidersEvent -= OnActivateStreetColliders;
        _api.EnableDietButtonsEvent -= OnEnableDietButton;
        _api.EnableMovingButtonEvent -= OnEnableMovingButton;
        _api.SetTimerTextEvent -= OnSetTimerText;
        _api.AddMeasureButtonEvent -= OnAddButtonToMeasureButtonsList;
        _api.ActivateByNameEvent -= OnActivateSceneObjectByName;
        _api.SetMessageTextEvent -= OnSetLastScreenText;
        _api.SetResultTextEvent -= OnSetResultScreenText;
        _api.ShowExitTextEvent -= OnSetExitText;
        _api.ShowMenuTextEvent -= OnSetMenuText;
        _api.SetStartTextEvent -= OnSetStartText;
        _api.SetMeasureValueEvent -= OnSetMeasureValue;
        _api.ActivateBackButtonEvent -= OnActivaneBackButton;

    }
    private void OnDeactivateUiButtons()
    {
        InstanceHandler.Instance.AOSObjectsActivator.DeactivateAllArmUIPoints();
    }
    private void OnEnableDialog(string text)
    {
        InstanceHandler.Instance.CanvasMode.EnableDialogCanvas(text);
    }
    private void OnAddTextObjectUiButton(string id, string name)
    {
        InstanceHandler.Instance.CanvasMode.AddTextObjectUiButton(id, name);
    }
    private void OnAddTextObjectUi(string text, DialogRole role)
    {
        InstanceHandler.Instance.CanvasMode.AddTextObjectUi(text, role);
    }
    private void OnEnableDialogHeader(string text)
    {
        InstanceHandler.Instance.CanvasMode.SetDialogHeaderText(text);
    }
    private void OnDeactivateColliders()
    {
        InstanceHandler.Instance.AOSObjectsActivator.DeactivateAllColliders();
    }
    private void OnResetMesaureButtons()
    {
        InstanceHandler.Instance.MeasureButtonsActivator.ResetCurrentButtonsList();
    }
    private void OnShowReactionWindow(string reactionText)
    {
        InstanceHandler.Instance.HelpTextController.SetReactionText(reactionText);
    }
    private void OnSetLoationToTeleport(string location)
    {
        InstanceHandler.Instance.Teleporter.Teleport(location);
    }
    private void OnSetLocationTextToLocationController(string location)
    {
        InstanceHandler.Instance.LocationController.SetLocationtext(location);
    }
    private void OnSetLocationToLocationController(string location)
    {
        Debug.Log("LOCATION " + location);
        InstanceHandler.Instance.BackTriggersHoler.SetTrigger(location);
        InstanceHandler.Instance.LocationController.SetLocation(location);
    }
    private void OnSetLocationAfterConnection(object value)
    {
        InstanceHandler.Instance.LocationController.ConnectionEstablished();
    }
    private void OnEnableDietButton(string buttonName, string buttonText)
    {
        if (buttonName == null || buttonText == null)
            InstanceHandler.Instance.Diet.DisableAllButtons();
        else
        {
            InstanceHandler.Instance.Diet.EnableDietButtons(buttonName, buttonText);
            Debug.Log(buttonName + " From InstanceHandler");
        }
    
    }
    private void OnEnableMovingButton(string buttonType, string buttonText)
    {
        Debug.Log(buttonType + " Type" + buttonText + " Text");
        if (buttonType == "eye")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowWatchButton();
            InstanceHandler.Instance.MovingButtonsController.SetWatchButtonText(buttonText);
        }
        else if (buttonType == "hand")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHandButton();
            InstanceHandler.Instance.MovingButtonsController.SetHandButtonText(buttonText);
        }
        else if (buttonType == "hand_1")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHand1Button();
            InstanceHandler.Instance.MovingButtonsController.SetHand1ButtonText(buttonText);
        }
        else if (buttonType == "hand_2")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHand2Button();
            InstanceHandler.Instance.MovingButtonsController.SetHand2ButtonText(buttonText);
        }
        else if (buttonType == "hand_3")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHand3Button();
            InstanceHandler.Instance.MovingButtonsController.SetHand3ButtonText(buttonText);
        }
        else if (buttonType == "hand_4")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHand4Button();
            InstanceHandler.Instance.MovingButtonsController.SetHand4ButtonText(buttonText);
        }
        else if (buttonType == "tool")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowToolButton();
            InstanceHandler.Instance.MovingButtonsController.SetToolButtonText(buttonText);
        }
        else if (buttonType == "tool_1")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowTool1Button();
            InstanceHandler.Instance.MovingButtonsController.SetTool1ButtonText(buttonText);
        }
        else if (buttonType == "pen")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowPenButton();
            InstanceHandler.Instance.MovingButtonsController.SetPenButtonText(buttonText);
        }
        else if (buttonType == "pen_1")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowPen1Button();
            InstanceHandler.Instance.MovingButtonsController.SetPen1ButtonText(buttonText);
        }

        else if (buttonType == null)
            InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
    }
    private void OnSetTimerText(string timerText)
    {
        InstanceHandler.Instance.CanvasMode.SetTimeText(timerText);
    }
    private void OnActivaneBackButton(string actionName)
    {
        InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke = actionName;
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(true);
    }
    private void OnActivateSceneObjectByName(string id, string name)
    {
        InstanceHandler.Instance.AOSObjectsActivator.ActivateColliders(id, name);
    }
    private void OnActivateSceneArmPointByName(string id, string name)
    {
        InstanceHandler.Instance.AOSObjectsActivator.ActivateArmUIpoints(id, name);
    }
    private void OnAddButtonToMeasureButtonsList(string buttonName)
    {
        InstanceHandler.Instance.MeasureButtonsActivator.AddButtonToList(buttonName);
    }
    private void OnActivatePointObjectByName(string id, string name)
    {
        InstanceHandler.Instance.AOSObjectsActivator.ActivatePoints(id, name);
    }

    private void OnSetLastScreenText(string headertext, string commentText)
    {
        InstanceHandler.Instance.CanvasMode.SetLastScreenText(headertext, commentText);
    }
    private void OnSetResultScreenText(string headertext, string commentText, string evalText)
    {
        InstanceHandler.Instance.CanvasMode.SetResultScreenText(headertext, commentText, evalText);
    }
    private void OnSetExitText(string exitText, string warntext)
    {
        InstanceHandler.Instance.CanvasMode.SetExitText(exitText, warntext);
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
        InstanceHandler.Instance.CanvasMode.SetMenuText(headText, commentText, exitSureText);
    }
    private void OnSetStartText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        InstanceHandler.Instance.CanvasMode.SetStartScreenText(headerText, commentText, buttonText, state);
    }
    private void OnSetMeasureValue(float value)
    {
        InstanceHandler.Instance.MeasureController.SetDeviceValue(value);
        Debug.Log(value + "From Instance Handler");
    }
    private void OnActivateStreetColliders(string locationName)
    {
        //StreetCollidersActivator.Instance.ActivateColliders(locationName);
    }
}