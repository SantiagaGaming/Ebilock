using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private ConnectionToClient _connectionChecker;
    [SerializeField] private AOSObjectsHolder _aosObjectsActivator;
    [SerializeField] private BackButtonsActivator _backButtonsActivator;
    [SerializeField] private MeasureButtonsActivator _measureButtonsActivator;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private MovingButtonsController _movinButtonsController;
    [SerializeField] private MovingTextWindow _objectsInfoWindow;
    [SerializeField] private MovingTextWindow _reactionInfoWindow;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    [SerializeField] private Diet _diet;
    [SerializeField] private ShupPositionChanger _shupPositionChanger;
    [SerializeField] private Ampermetr _ampermetr;
    [SerializeField] private ShupController _shupController;
    [SerializeField] private PointerDevice _pointerDevice;
    [SerializeField] private MeasureController _measureController;
    [SerializeField] private MapImageButton _mapImageButton;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private HelpTextController _helpTextController;
    [SerializeField] private CanvasMode _canvasMode;
    [SerializeField] private BackTriggersHoler _backTriggerHoler;

    private void OnEnable()
    {
       API.Instance.ShowPlaceEvent += OnDeactivateColliders;
        API.Instance.ReactionEvent += OnShowReactionWindow;
        API.Instance.ResetMeasureButtonsEvent += OnResetMesaureButtons;
        API.Instance.TeleportStartEvent += OnSetLoationToTeleport;
        API.Instance.SetNewLocationTextEvent += OnSetLocationTextToLocationController;
        API.Instance.SetLocationEvent += OnSetLocationToLocationController;
        API.Instance.SetLocationForFieldCollidersEvent += OnActivateStreetColliders;
        API.Instance.EnableDietButtonsEvent += OnEnableDietButton;
        API.Instance.EnableMovingButtonEvent += OnEnableMovingButton;
        API.Instance.SetTimerTextEvent += OnSetTimerText;
        API.Instance.AddMeasureButtonEvent += OnAddButtonToMeasureButtonsList;
        API.Instance.ActivateByNameEvent += OnActivateSceneObjectByName;
        API.Instance.SetMessageTextEvent += OnSetLastScreenText;
        API.Instance.SetResultTextEvent += OnSetResultScreenText;
        API.Instance.ShowExitTextEvent += OnSetExitText;
        API.Instance.ShowMenuTextEvent += OnSetMenuText;
        API.Instance.SetStartTextEvent += OnSetStartText;
        API.Instance.SetMeasureValueEvent += OnSetMeasureValue;
        API.Instance.ActivateBackButtonEvent += OnActivaneBackButton;
        API.Instance.PointEvent += OnActivatePointObjectByName;
        API.Instance.DialogHeaderEvent += OnEnableDialogHeader;
        API.Instance.DialogEvent += OnEnableDialog;
        API.Instance.AddTextObjectUiButtonEvent += OnAddTextObjectUiButton;
        API.Instance.AddTextObjectUiEvent += OnAddTextObjectUi;
        API.Instance.ActivatePointByNameEvent += OnActivateSceneArmPointByName;
        API.Instance.StartUpdatePlaceEvent += OnDeactivateUiButtons;

    }

    private void OnDisable()
    {
        API.Instance.ShowPlaceEvent -= OnDeactivateColliders;
        API.Instance.ReactionEvent -= OnShowReactionWindow;
        API.Instance.ResetMeasureButtonsEvent -= OnResetMesaureButtons;
        API.Instance.TeleportStartEvent -= OnSetLoationToTeleport;
        API.Instance.SetNewLocationTextEvent -= OnSetLocationTextToLocationController;
        API.Instance.SetLocationEvent -= OnSetLocationToLocationController;
        API.Instance.SetLocationForFieldCollidersEvent -= OnActivateStreetColliders;
        API.Instance.EnableDietButtonsEvent -= OnEnableDietButton;
        API.Instance.EnableMovingButtonEvent -= OnEnableMovingButton;
        API.Instance.SetTimerTextEvent -= OnSetTimerText;
        API.Instance.AddMeasureButtonEvent -= OnAddButtonToMeasureButtonsList;
        API.Instance.ActivateByNameEvent -= OnActivateSceneObjectByName;
        API.Instance.SetMessageTextEvent -= OnSetLastScreenText;
        API.Instance.SetResultTextEvent -= OnSetResultScreenText;
        API.Instance.ShowExitTextEvent -= OnSetExitText;
        API.Instance.ShowMenuTextEvent -= OnSetMenuText;
        API.Instance.SetStartTextEvent -= OnSetStartText;
        API.Instance.SetMeasureValueEvent -= OnSetMeasureValue;
        API.Instance.ActivateBackButtonEvent -= OnActivaneBackButton;
        API.Instance.PointEvent -= OnActivatePointObjectByName;
        API.Instance.DialogHeaderEvent -= OnEnableDialogHeader;
        API.Instance.DialogEvent -= OnEnableDialog;
        API.Instance.AddTextObjectUiButtonEvent -= OnAddTextObjectUiButton;
        API.Instance.AddTextObjectUiEvent -= OnAddTextObjectUi;
        API.Instance.ActivatePointByNameEvent -= OnActivateSceneArmPointByName;
        API.Instance.StartUpdatePlaceEvent -= OnDeactivateUiButtons;
    }
    private void OnDeactivateUiButtons()
    {
        _aosObjectsActivator.DeactivateAllArmUIPoints();
    }
    private void OnEnableDialog(string text)
    {
        _canvasMode.EnableDialogCanvas(text);
    }
    private void OnAddTextObjectUiButton(string id, string name)
    {
        _canvasMode.AddTextObjectUiButton(id, name);
    }
    private void OnAddTextObjectUi(string text, DialogRole role)
    {
        _canvasMode.AddTextObjectUi(text, role);
    }
    private void OnEnableDialogHeader(string text)
    {
        _canvasMode.SetDialogHeaderText(text);
    }
    private void OnDeactivateColliders()
    {
        _aosObjectsActivator.DeactivateAllColliders();
    }
    private void OnResetMesaureButtons()
    {
        _measureButtonsActivator.ResetCurrentButtonsList();
    }
    private void OnShowReactionWindow(string reactionText)
    {
        _helpTextController.SetReactionText(reactionText);
    }
    private void OnSetLoationToTeleport(string location)
    {
        _teleporter.Teleport(location);
    }
    private void OnSetLocationTextToLocationController(string location)
    {
        _locationController.SetLocationtext(location);
    }
    private void OnSetLocationToLocationController(string location)
    {
        _backTriggerHoler.SetTrigger(location);
        _locationController.SetLocation(location);
    }

    private void OnEnableDietButton(string buttonName, string buttonText)
    {
        if (buttonName == null || buttonText == null)
            _diet.DisableAllButtons();
        else
            _diet.EnableDietButtons(buttonName, buttonText);
    }
    private void OnEnableMovingButton(string buttonType, string buttonText)
    {
        if (buttonType == "eye")
        {
            _movinButtonsController.ShowWatchButton();
            _movinButtonsController.SetWatchButtonText(buttonText);
        }
        else if (buttonType == "hand")
        {
            _movinButtonsController.ShowHandButton();
            _movinButtonsController.SetHandButtonText(buttonText);
        }
        else if (buttonType == "hand_1")
        {
            _movinButtonsController.ShowHand1Button();
            _movinButtonsController.SetHand1ButtonText(buttonText);
        }
        else if (buttonType == "hand_2")
        {
            _movinButtonsController.ShowHand2Button();
            _movinButtonsController.SetHand2ButtonText(buttonText);
        }
        else if (buttonType == "hand_3")
        {
            _movinButtonsController.ShowHand3Button();
            _movinButtonsController.SetHand3ButtonText(buttonText);
        }
        else if (buttonType == "hand_4")
        {
            _movinButtonsController.ShowHand4Button();
            _movinButtonsController.SetHand4ButtonText(buttonText);
        }
        else if (buttonType == "tool")
        {
            _movinButtonsController.ShowToolButton();
            _movinButtonsController.SetToolButtonText(buttonText);
        }
        else if (buttonType == "tool_1")
        {
            _movinButtonsController.ShowTool1Button();
            _movinButtonsController.SetTool1ButtonText(buttonText);
        }
        else if (buttonType == "pen")
        {
            _movinButtonsController.ShowPenButton();
            _movinButtonsController.SetPenButtonText(buttonText);
        }
        else if (buttonType == "pen_1")
        {
            _movinButtonsController.ShowPen1Button();
            _movinButtonsController.SetPen1ButtonText(buttonText);
        }

        else if (buttonType == null)
            _movinButtonsController.HideAllButtons();
    }
    private void OnSetTimerText(string timerText)
    {
        _canvasMode.SetTimeText(timerText);
    }
    private void OnActivaneBackButton(string actionName)
    {
        _backButtonsActivator.ActionToInvoke = actionName;
        _backButtonsActivator.EnableCurrentBackButton(true);
    }
    private void OnActivateSceneObjectByName(string id, string name)
    {
        _aosObjectsActivator.ActivateColliders(id, name);
    }
    private void OnActivateSceneArmPointByName(string id, string name)
    {
        _aosObjectsActivator.ActivateArmUIpoints(id, name);
    }
    private void OnAddButtonToMeasureButtonsList(string buttonName)
    {
        _measureButtonsActivator.AddButtonToList(buttonName);
    }
    private void OnActivatePointObjectByName(string id, string name)
    {
        _aosObjectsActivator.ActivatePoints(id, name);
    }

    private void OnSetLastScreenText(string headertext, string commentText)
    {
        _canvasMode.SetLastScreenText(headertext, commentText);
    }
    private void OnSetResultScreenText(string headertext, string commentText, string evalText)
    {
      _canvasMode.SetResultScreenText(headertext, commentText, evalText);
    }
    private void OnSetExitText(string exitText, string warntext)
    {
        _canvasMode.SetExitText(exitText, warntext);
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
       _canvasMode.SetMenuText(headText, commentText, exitSureText);
    }
    private void OnSetStartText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        _canvasMode.SetStartScreenText(headerText, commentText, buttonText, state);
    }
    private void OnSetMeasureValue(float value)
    {
        _measureController.SetDeviceValue(value);
    }
    private void OnActivateStreetColliders(string locationName)
    {
        //StreetCollidersActivator.Instance.ActivateColliders(locationName);
    }
}