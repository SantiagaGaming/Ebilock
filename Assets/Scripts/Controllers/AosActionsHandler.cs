using System;
using System.Linq;
using UnityEngine;

public class AosActionsHandler : MonoBehaviour
{
    public Action ButtonsPositionChanged;
    [HideInInspector] public string ObjectHelperName { get; set; }
    [HideInInspector] public string ObjectName { get; set; }

    [SerializeField] private MovingButton[] _actionButtons;
    [SerializeField] private HelpTextController _helpTextController;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    public IHandObject HandObject { get; set; }
    public IToolObject ToolObject { get; set; }

    private const float Y = 0f;
    private float _step = 3.06f;
    private float _y;
    private void Start()
    {
        foreach (var actionButton in _actionButtons)
        {
            actionButton.ButtonClickEvent += OnHandleClick;
            actionButton.ButtonHoverEvent += OnHandleHover;
        }
        ObjectWithButton.ObjectWithButtonClickedEvent += OnObjectClicked;
        _mainMenuCanvas.LastScreenEvent += OnDisableTeleport;
    }
    private void OnObjectClicked(ObjectWithButton obj)
    {
        _helpTextController.HideReactionText();
        ObjectHelperName = obj.HelperName;
        HandObject = null;
        ToolObject = null;
        HideAllButtons();
        if (obj.DisabableObject != null)
            HandObject = obj.DisabableObject;
        if (obj.HandRotationObject != null)
            HandObject = obj.HandRotationObject;
        if (obj.RepairableObject != null)
            ToolObject = obj.RepairableObject;
    }
    private void OnHandleClick(ButtonActionName buttonName)
    {
        var btnToShow = GetButtonByEnumName(buttonName);
        if (btnToShow == null)
            return;
        InstanceHandler.Instance.SceneAosObject.ActionWithObject(GetStringFromEnum(btnToShow.ButtonActionName));
    }
    private void OnHandleHover(Transform pos, string name)
    {
        if (pos == null || name == null)
            _helpTextController.HideHelperText();
        else
            _helpTextController.ShowHelperText(pos, name);
    }

    public void ShowMovingButtonWithText(string name, string text)
    {
        ButtonActionName actionName;
        Enum.TryParse<ButtonActionName>(name, out actionName);
        if (actionName == null)
            return;
        var btnToShow = GetButtonByEnumName(actionName);
        if (btnToShow == null)
            return;
        btnToShow.EnableObject(true);
        btnToShow.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(btnToShow);
    }

    public void HideAllButtons()
    {
        foreach (var actionButton in _actionButtons)
            actionButton.EnableObject(false);
        ButtonsPositionChanged?.Invoke();
        _y = Y;
    }
    private MovingButton GetButtonByEnumName(ButtonActionName name)
    {
        var btnToShow = _actionButtons.FirstOrDefault(b => name == b.ButtonActionName);
        if (btnToShow == null)
            return null;
        return btnToShow;

    }
    public void StartHandAction()
    {
        if (HandObject != null)
            HandObject.HandAction();
    }
    public void StartToolAction()
    {
        if (ToolObject != null)
            ToolObject.ToolAction();
    }
    private void ChangeYValue(MovingButton btn)
    {
        btn.ChangeButtonPosistion(_y);
        _y += _step;
    }
    private string GetStringFromEnum(Enum enumName)
    {
        return enumName.ToString().ToLower();
    }
    private void OnDisableTeleport()
    {
        _teleporter.CanTeleport = false;
    }

}
