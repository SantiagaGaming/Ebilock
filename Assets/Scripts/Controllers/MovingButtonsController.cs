using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static BackFromMenuUIButton;

public class MovingButtonsController : MonoBehaviour
{
    public UnityAction ButtonsPositionChanged;
    [HideInInspector] public string ObjectHelperName { get; set; }
    [HideInInspector] public string ObjectName { get; set; }

    public SceneObject CurrentBaseObject { get; set; }
    public IHandObject HandObject { get; set; }
    public IToolObject ToolObject { get; set; }

    [SerializeField] private GameObject _eyeButton;
    [SerializeField] private GameObject _toolButton;
    [SerializeField] private GameObject _toolButton_1;
    [SerializeField] private GameObject _handButton;
    [SerializeField] private GameObject _handButton_1;
    [SerializeField] private GameObject _handButton_2;
    [SerializeField] private GameObject _handButton_3;
    [SerializeField] private GameObject _handButton_4;
    [SerializeField] private GameObject _penButton;
    [SerializeField] private GameObject _penButton_1;

    private const float Y = 0f;
    private float _step = 3.06f;
    private float _y;

    public void SetCurrentBaseObjectAndMovingButtonsPosition(Vector3 position, SceneObject obj)
    {
        HideAllButtons();
        transform.position = position;
        CurrentBaseObject = obj;
    }
    public void ShowWatchButton()
    {
        _eyeButton.SetActive(true);
    }
    public void ShowToolButton()
    {
        _toolButton.SetActive(true);
    }
    public void ShowTool1Button()
    {
        _toolButton_1.SetActive(true);
    }
    public void ShowHandButton()
    {
        _handButton.SetActive(true);
    }
    public void ShowHand1Button()
    {
        _handButton_1.SetActive(true);
    }
    public void ShowHand2Button()
    {
        _handButton_2.SetActive(true);
    }
    public void ShowHand3Button()
    {
        _handButton_3.SetActive(true);
    }
    public void ShowHand4Button()
    {
        _handButton_4.SetActive(true);
    }
    public void ShowPenButton()
    {
        _penButton.SetActive(true);
    }
    public void ShowPen1Button()
    {
        _penButton_1.SetActive(true);
    }
    public void HideAllButtons()
    {
        _eyeButton.SetActive(false);
        _toolButton.SetActive(false);
        _handButton.SetActive(false);
        _handButton_1.SetActive(false);
        _handButton_2.SetActive(false);
        _handButton_3.SetActive(false);
        _handButton_4.SetActive(false);
        _penButton.SetActive(false);
        _penButton_1.SetActive(false);
        _toolButton_1.SetActive(false);
        ButtonsPositionChanged?.Invoke();
        _y = Y;
    }
    public void SetWatchButtonText(string text)
    {
        _eyeButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetToolButtonText(string text)
    {
        _toolButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetTool1ButtonText(string text)
    {
        _toolButton_1.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetHandButtonText(string text)
    {
        _handButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetHand1ButtonText(string text)
    {
        _handButton_1.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetHand2ButtonText(string text)
    {
        _handButton_2.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetHand3ButtonText(string text)
    {
        _handButton_3.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetHand4ButtonText(string text)
    {
        _handButton_4.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetPenButtonText(string text)
    {
        _penButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
    }
    public void SetPen1ButtonText(string text)
    {
        _penButton_1.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
        ChangeYValue(movingButton);
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
}
