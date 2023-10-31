using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private ConnectionChecker _connectionChecker;

    private void OnEnable()
    {
        _connectionChecker.OnConnectionReady += OnSetLocationAfterConnection;
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
        _connectionChecker.OnConnectionReady -= OnSetLocationAfterConnection;
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
    private void OnDeactivateColliders()
    {
        InstanceHandler.Instance.AOSColliderActivator.DeactivateAllColliders();
    }
    private void OnResetMesaureButtons()
    {
        InstanceHandler.Instance.MeasureButtonsActivator.ResetCurrentButtonsList();
    }
    private void OnShowReactionWindow(string reactionText)
    {
        InstanceHandler.Instance.ReactionInfoWindow.ShowWindowWithText(reactionText);
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
        InstanceHandler.Instance.LocationController.SetLocation(location);
    }
    private void OnSetLocationAfterConnection()
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
        InstanceHandler.Instance.TimerView.ShowTimerText(timerText);
    }
    private void OnActivaneBackButton(string actionName)
    {
        InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke = actionName;
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(true);
    }
    private void OnAddButtonToMeasureButtonsList(string buttonName)
    {
        InstanceHandler.Instance.MeasureButtonsActivator.AddButtonToList(buttonName);
    }
    private void OnActivateSceneObjectByName(string id, string name)
    {
        InstanceHandler.Instance.AOSColliderActivator.ActivateColliders(id, name);
    }
    private void OnSetLastScreenText(string headertext, string commentText)
    {
        InstanceHandler.Instance.MainMenuCanvas.ShowCanvasByName("LastWindow");
        InstanceHandler.Instance.MainMenuCanvas.SetText(headertext, commentText);
    }
    private void OnSetResultScreenText(string headertext, string commentText, string evalText)
    {
        InstanceHandler.Instance.Teleporter.TeleportToMenu();
        InstanceHandler.Instance.MainMenuCanvas.ShowCanvasByName("LastWindow");
        InstanceHandler.Instance.MainMenuCanvas.SetText(headertext, commentText, evalText);
    }
    private void OnSetExitText(string exitText, string warntext)
    {
        InstanceHandler.Instance.MainMenuCanvas.SetExitText(exitText, warntext);
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
        InstanceHandler.Instance.MainMenuCanvas.SetMenuText(headText, commentText, exitSureText);
    }
    private void OnSetStartText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        InstanceHandler.Instance.CanvasChanger.EnableStartScreen(headerText, commentText, buttonText, state);
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