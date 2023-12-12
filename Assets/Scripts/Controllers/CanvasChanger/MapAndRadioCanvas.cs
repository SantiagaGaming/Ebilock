using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MapAndRadioCanvas : MonoBehaviour
{
    [SerializeField]private GameObject _canvasObject;
    [SerializeField] private GameObject _radioObjects;
    [SerializeField] private GameObject _mapObjects;
    [SerializeField] private CursorManager _cursormanager;
    [SerializeField] private CloseCanvasButton _closeCanvasButton;
    [SerializeField] private CloseCanvasButton _closeCanvasButton2;
    [SerializeField] private EscButton _escButton;
    [SerializeField] private Zoom _zoom;

    private void Start()
    {
        RadioButton.RadioButtonClickEvent += OnRadioButtonClickEvent;
        EnableImageButton.MapButtonClickEvent += OnMapButtonClickEvent;
        _escButton.EscClickEvent += OnEscClick;
        _closeCanvasButton.BackButtonClickEvent += OnCloseCanvas;
        _closeCanvasButton2.BackButtonClickEvent += OnCloseCanvas;
    }
    private void OnEscClick()
    {
        DisableAllObjects();
    }
    private void OnCloseCanvas()
    {
        DisableAllObjects();
        _cursormanager.EnableCursor(false);
    }
    private void DisableAllObjects()
    {
        _canvasObject.SetActive(false);
        _mapObjects.SetActive(false);
        _radioObjects.SetActive(false);
    }

    private void OnRadioButtonClickEvent()
    {
        HelpTextController helptext = FindObjectOfType<HelpTextController>();
        if(helptext!=null)
        {
            helptext.HideHelperText();
            helptext.HideReactionText();
        }
        _canvasObject.SetActive(true);
        _radioObjects.SetActive(true);
        _cursormanager.EnableCursor(true);
    }
    private void OnMapButtonClickEvent()
    {
        _canvasObject.SetActive(true);
        _mapObjects.SetActive(true);
        _cursormanager.EnableCursor(true);
    }
}
