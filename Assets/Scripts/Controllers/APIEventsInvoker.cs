using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private ConnectionToClient _connectionChecker;
    [SerializeField] private AOSObjectsHolder _aosObjectsActivator;
    [SerializeField] private MeasureButtonsActivator _measureButtonsActivator;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private AosActionsHandler _movinButtonsController;
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
    [SerializeField] private HelpTextController _helpTextController;
    [SerializeField] private CanvasMode _canvasMode;
    [SerializeField] private BackTriggersHolder _backTriggerHoler;

    private void OnEnable()
    {
        API.Instance.ShowPlaceEvent += OnDeactivateColliders;
        API.Instance.ReactionEvent += OnShowReactionWindow;
        API.Instance.ResetMeasureButtonsEvent += OnResetMesaureButtons;
        API.Instance.TeleportStartEvent += OnSetLocationToTeleport;
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
        API.Instance.TeleportStartEvent -= OnSetLocationToTeleport;
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
    private void OnSetLocationToTeleport(string location)
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
        if (buttonType == null)
            _movinButtonsController.HideAllButtons();
        _movinButtonsController.ShowMovingButtonWithText(buttonType, buttonText);
    }
    private void OnSetTimerText(string timerText)
    {
        _canvasMode.SetTimeText(timerText);
    }
    private void OnActivaneBackButton(string actionName)
    {
        InstanceHandler.Instance.ActionToInvoke = actionName;
        InstanceHandler.Instance.EnableCurrentBackButton(true);
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